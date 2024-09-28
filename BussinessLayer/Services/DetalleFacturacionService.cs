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
    public class DetalleFacturacionService: IDetalleFacturacionService
    {
        private PDbContext _context;

        public DetalleFacturacionService()
        {
            _context = new PDbContext();
        }
        public async Task Add(DetalleFacturacion entity)
        {
            if (entity != null)
            {
                try
                {
                    entity.Borrado = false;
                    _context.DetalleFacturacion.Add(entity);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task Edit(DetalleFacturacion entity)
        {
            if (entity != null)
            {
                try
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
               
            }
        }

        public async Task<DetalleFacturacion> GetById(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<DetalleFacturacion>> GetAll(long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DetalleFacturacion>> GetDetalleByFacturacionId(int facturacionId)
        {
            try
            {
            return  await   _context.DetalleFacturacion.Where(x => x.FacturacionId == facturacionId && x.Borrado != true).Include(x => x.Facturacion)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
