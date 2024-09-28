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
    public class DetalleCotizacionService:IDetalleCotizacionService
    {
        private readonly PDbContext _context;

        public DetalleCotizacionService()
        {
            _context = new PDbContext();
        }
        public async Task Add(DetalleCotizacion entity)
        {
            try
            {
                _context.DetalleCotizacion.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Edit(DetalleCotizacion entity)
        {
            throw new NotImplementedException();
        }

        public async Task<DetalleCotizacion> GetById(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<DetalleCotizacion>> GetAll(long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DetalleCotizacion>> GetAllByCotizacionId(int cotizacionId) => await _context.DetalleCotizacion.Include(x => x.Cotizacion)
            .Where(x => x.CotizacionId == cotizacionId && x.Borrado != true).ToListAsync();

     
    }
}
