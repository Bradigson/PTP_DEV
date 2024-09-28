using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Services.Contracts;
using DataLayer.Models;
using DataLayer.PDbContex;

namespace BussinessLayer.Services
{
    public class MarcaService : IMarcaService
    {
        public async Task Add(Marca entity)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    context.Marcas.Add(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
            }

        }

        public async Task Edit(Marca entity)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    entity.FechaModificacion = DateTime.Now;
                    context.Entry(entity).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        public async Task<Marca> GetById(int id, long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                return await context.Marcas.Where(x=>x.Id==id && x.IdEmpresa==idEMpresa).FirstOrDefaultAsync();
            }
        }

        public async Task<IList<Marca>> GetAll(long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    return await context.Marcas.Where(x => x.Borrado != true && x.IdEmpresa==idEMpresa).OrderBy(x => x.Nombre).ToListAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
            }
        }

        public async Task Delete(int id, long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                var marca = await context.Marcas.Where(x => x.Borrado != true && x.IdEmpresa == idEMpresa).FirstOrDefaultAsync();
                if(marca == null) return;

                marca.Borrado = true;
                await context.SaveChangesAsync();
            }
        }
    }
}
