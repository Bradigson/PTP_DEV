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
    public class CuentaPorCobrarService:ICuentasPorCobrar
    {
       private DetalleCuentasPorCobrar _DetallecuentaCxc=null;
        private PDbContext _context;

        public CuentaPorCobrarService()
        {
            _context=  new PDbContext();
        }

        public async Task Add(CuentasPorCobrar entity)
        {
            try
            {
                
                _DetallecuentaCxc = new DetalleCuentasPorCobrar();
                _DetallecuentaCxc = entity.DetalleCuentasPorCobrar.SingleOrDefault();
                _DetallecuentaCxc.FacturacionId = entity.FacturacionId;
                _context.CuentasPorCobrar.Add(entity);
                await _context.SaveChangesAsync();
                _context.DetalleCuentasPorCobrar.Add(_DetallecuentaCxc);
                 await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public async Task Edit(CuentasPorCobrar entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CuentasPorCobrar> GetById(int id, long idempresa) => await _context.CuentasPorCobrar.Include(x => x.Facturacion)
            .SingleOrDefaultAsync(x => x.FacturacionId == id && x.IdEmpresa== idempresa);

        public async Task<IList<CuentasPorCobrar>> GetAll(long idempresa)
        {
            try
            {
                return await _context.CuentasPorCobrar.Where(x => x.Borrado != true && x.IdEmpresa==idempresa).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Delete(int id, long idempresa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CuentasPorCobrar>> GetAllPaids()
        {
            try
            {
                return await _context.CuentasPorCobrar.Where(x => x.IsPaid).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
