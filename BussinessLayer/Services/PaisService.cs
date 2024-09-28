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
    public class PaisService : IPaisService
    {
        public async Task Add(Pais entity)
        {
            using (var context = new PDbContext())
            {
                entity.FechaModificacion = DateTime.Now;
                context.Paises.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Edit(Pais entity)
        {
            using (var context = new PDbContext())
            {
                var oldPais = await context.Paises.FindAsync(entity.Id);
                if (oldPais == null) return;
                oldPais.Nombre = entity.Nombre;
                oldPais.FechaModificacion = DateTime.Now;
                context.SaveChanges();
            }
        }

        public async Task<Pais> GetById(int id, long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                return await context.Paises.FindAsync(id);
            }
        }

        public async Task<IList<Pais>> GetAll(long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                return await context.Paises.Where(x => x.Borrado != true).ToListAsync();
            }
        }

        public async Task Delete(int id, long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                var oldPais = await context.Paises.FindAsync(id);
                if (oldPais == null) return;
                oldPais.Borrado = true;
                await context.SaveChangesAsync();
            }
        }
    }
}