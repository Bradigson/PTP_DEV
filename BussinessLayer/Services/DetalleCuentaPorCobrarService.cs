using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Services.Contracts;
using DataLayer.Models;
using DataLayer.PDbContex;

namespace BussinessLayer.Services
{
    public class DetalleCuentaPorCobrarService:IDetalleCuentasPorCobrar
    {
        private PDbContext _context;

        public DetalleCuentaPorCobrarService()
        {
            _context= new PDbContext();
        }

        public async Task Add(DetalleCuentasPorCobrar entity)
        {
            try
            {
                CuentasPorCobrar
                    dc = await _context.CuentasPorCobrar.Where(x=>x.FacturacionId==entity.FacturacionId).SingleAsync();

                if (entity.Monto >= dc.MontoPendiente )
                {
                    dc.IsPaid = true;
                    dc.MontoPendiente = dc.MontoPendiente - entity.Monto;
                    _context.Entry(dc).State = EntityState.Modified;
                    _context.DetalleCuentasPorCobrar.Add(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    dc.MontoPendiente = dc.MontoPendiente - entity.Monto;
                    dc.FechaUltimoPago = DateTime.Now;
                    _context.Entry(dc).State = EntityState.Modified;
                    _context.DetalleCuentasPorCobrar.Add(entity);
                    await _context.SaveChangesAsync();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }




        //OJO CON ESTE METODO
        public async Task<IEnumerable<DetalleCuentasPorCobrar>> GetAllByCuentaPorCobrarId(int id) => await _context
            .DetalleCuentasPorCobrar.Where(x => x.Borrado != true && x.FacturacionId==id).ToListAsync();

    

        public async Task Edit(DetalleCuentasPorCobrar entity)
        {
            throw new NotImplementedException();
        }

        public async Task<DetalleCuentasPorCobrar> GetById(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<DetalleCuentasPorCobrar>> GetAll(long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }
    }
}
