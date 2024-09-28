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
    public class EnvaseService : IEnvaseService
    {
        public async Task Add(Envase entity)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    context.Envases.Add(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        public async Task Edit(Envase entity)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    var oldEnvase = await context.Envases.FindAsync(entity.Id);
                    if (oldEnvase == null) return;

                    oldEnvase.FechaModificacion = DateTime.Now;
                    oldEnvase.Descripcion = entity.Descripcion;
                    oldEnvase.Activo = entity.Activo;

                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        public async Task<Envase> GetById(int id, long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                return await context.Envases.Where(x=>x.Id==id && x.IdEmpresa== idEMpresa).FirstOrDefaultAsync();
            }
        }

        public async Task<IList<Envase>> GetAll(long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    return await context.Envases.Where(x => x.Borrado != true && x.IdEmpresa==idEMpresa).OrderBy(x => x.Descripcion).ToListAsync();
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
                var marca = await context.Envases.Where(x=>x.IdEmpresa== idEMpresa && x.Id==id).FirstOrDefaultAsync();
                if (marca == null) return;

                marca.Borrado = true;
                await context.SaveChangesAsync();
            }
        }
    }
}
