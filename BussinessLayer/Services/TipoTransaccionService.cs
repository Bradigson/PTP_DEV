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
    public class TipoTransaccionService:ITipoTransaccionService
    {
        private readonly PDbContext _context;

        public TipoTransaccionService()
        {
            _context = new PDbContext();
        }
        public async Task Add(TipoTransaccion entity)
        {
            try
            {
                _context.TipoTransaccion.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Edit(TipoTransaccion entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TipoTransaccion> GetById(int id, long idEMpresa)
        {
            return await _context.TipoTransaccion.FindAsync(id);
        }

        public Task<IList<TipoTransaccion>> GetAll(long idEMpresa)
        {
            throw new NotImplementedException();
        }
            public  IList<TipoTransaccion> GetAllE(long idEMpresa)

        /*
          Efectivo =1,
    Cheques =2,
    Tarjeta =3,
    Cupones =4,
    TarjetayEfectivo = 5
         */
        {
            List<TipoTransaccion> lista_tipo = new List<TipoTransaccion>();
            lista_tipo.Add(new TipoTransaccion() { Nombre = DataLayer.Enums.TipoTransaccionEnum.Efectivo.ToString(),Id=1});
            lista_tipo.Add(new TipoTransaccion() { Nombre = DataLayer.Enums.TipoTransaccionEnum.Tarjeta.ToString(), Id =3});
            lista_tipo.Add(new TipoTransaccion() { Nombre = DataLayer.Enums.TipoTransaccionEnum.Cheques.ToString(), Id = 2 });
            lista_tipo.Add(new TipoTransaccion() { Nombre = DataLayer.Enums.TipoTransaccionEnum.Cupones.ToString(), Id = 4 });
            lista_tipo.Add(new TipoTransaccion() { Nombre = DataLayer.Enums.TipoTransaccionEnum.TarjetayEfectivo.ToString(), Id=5 });
            return  lista_tipo;
               // _context.TipoTransaccion.Where(x => x.Borrado != true).ToListAsync();

            
        }

        public async Task Delete(int id, long idEMpresa)
        {
           var tt= await _context.TipoTransaccion.FindAsync(id);
            if (tt != null)
            {
                tt.Borrado = true;
             await   _context.SaveChangesAsync();
            }
        }
    }
}
