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
    public class VersionService : IVersionService
    {
        public async Task Add(Versiones entity)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    context.Versiones.Add(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        public async Task Edit(Versiones entity)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    var oldVersion = await context.Versiones.FindAsync(entity.Id);
                    if (oldVersion == null) return;

                    oldVersion.Nombre = entity.Nombre;
                    oldVersion.Activo = entity.Activo;
                    oldVersion.FechaModificacion = DateTime.Now;
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        public async Task<Versiones> GetById(int id, long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                return await context.Versiones.Include(x => x.Marca.IdEmpresa==idEMpresa).SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
        }

        public async Task<IList<Versiones>> GetAll(long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    return await context.Versiones.Include(x => x.Marca).Where(x => x.Borrado != true && x.IdEmpresa== idEMpresa).ToListAsync();
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
                var version = await context.Versiones.Where(x => x.IdEmpresa == idEMpresa && x.Id == id).FirstOrDefaultAsync();
                if (version == null) return;

                version.Borrado = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IList<Versiones>> GetVersionesByMarca(int? id, long idempresa)
        {
            if (id == null) return new List<Versiones>();
            using (var context = new PDbContext())
            {
                return await context.Versiones.Include(x => x.Marca).Where(x => x.IdMarca == id && x.IdEmpresa== idempresa)
                    .OrderBy(x => x.Nombre).ToListAsync();
            }
        }
    }
}
