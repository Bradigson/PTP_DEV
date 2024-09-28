using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Services.Contracts;
using DataLayer.Models;
using DataLayer.PDbContex;
using System.Data.Entity;
namespace BussinessLayer.Services
{
    public class DetalleCuentaPorPagarService : IDetalleCuentaPorPagar
    {
        private PDbContext _context;


        public DetalleCuentaPorPagarService()
        {
            _context = new PDbContext();
        }

        public async Task Add(DetalleCuentaPorPagar entity)
        {
            try
            {
                CuentasPorPagar cta =  await _context.CuentasPorPagar.Where(x=> x.IdMovimientoAlmacen==entity.IdMovAlmacen && x.IdEmpresa==entity.IdEmpresa).FirstAsync();
                if(cta.Restante == entity.Monto)
                {
                    cta.IsPaid = true;
                    cta.FechaUltimoPago = DateTime.Now;
                    cta.Restante = cta.Restante - entity.Monto;

                    _context.Entry(cta).State = EntityState.Modified;
                    
                    _context.DetalleCuentaPorPagar.Add(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    cta.Restante = cta.Restante - entity.Monto;
                    cta.FechaUltimoPago = DateTime.Now;
                    _context.Entry(cta).State = EntityState.Modified;
                    _context.DetalleCuentaPorPagar.Add(entity);
                    await _context.SaveChangesAsync();
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        

        public Task Delete(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public Task Edit(DetalleCuentaPorPagar entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<DetalleCuentaPorPagar>> GetAll(long idEMpresa)
        {
            try
            {
                return await _context.DetalleCuentaPorPagar.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<DetalleCuentaPorPagar>> GetAllByIdCtaPorPagar(int idcta)
        {
            return await _context.DetalleCuentaPorPagar.Where(x => x.IdMovAlmacen == idcta && x.Borrado != true).ToListAsync();
        }

        public Task<DetalleCuentaPorPagar> GetById(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }
    }
}
