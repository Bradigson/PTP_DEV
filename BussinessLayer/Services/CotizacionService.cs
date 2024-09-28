using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Services.Contracts;
using DataLayer.Models;
using DataLayer.PDbContex;
using DataLayer.ViewModels;

namespace BussinessLayer.Services
{
    public class CotizacionService:ICotizacionService
    {
        private readonly PDbContext _context;
        private readonly DetalleCotizacionService _detalleCotizacion;

        public CotizacionService()
        {
            _context = new PDbContext();
            _detalleCotizacion= new DetalleCotizacionService();
        }
        
        public async Task Add(Cotizacion entity)
        {
            try
            {
                _context.Cotizacion.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Create(CotizacionViewModel cotizacion)
        {
            try
            {
              await  Add(cotizacion.Cotizacion);
                int cotizacionId = cotizacion.Cotizacion.Id;
                foreach (var d in cotizacion.DetalleCotizacion)
                {
                    d.CotizacionId = cotizacionId;
                    d.IdEmpresa = cotizacion.Cotizacion.IdEmpresa;
                   await _detalleCotizacion.Add(d);
                   
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Edit(Cotizacion entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Cotizacion> GetById(int id, long idempresa) => await _context.Cotizacion.Include(x => x.DetalleCotizacion)
            .SingleOrDefaultAsync(x => x.Id == id && x.Borrado != true);

        public async Task<IList<Cotizacion>> GetAll(long idempresa) =>
            await _context.Cotizacion.Include(x=> x.DetalleCotizacion).Where(x => x.Borrado != true && x.IdEmpresa==idempresa).ToListAsync();

       

        public async Task Delete(int id, long idempresa)
        {
            throw new NotImplementedException();
        }
    }
}
