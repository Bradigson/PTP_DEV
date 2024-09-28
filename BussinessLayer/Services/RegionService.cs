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
    public class RegionService : IRegionService
    {
        public async Task Add(Region entity)
        {
            using (var db = new PDbContext())
            {
                try
                {
                    db.Regiones.Add(entity);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        public Task Edit(Region entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Region> GetById(int id, long idEMpresa)
        {
            using (var db = new PDbContext())
            {
                return await db.Regiones.FindAsync(id);
                
            }
        }

        public async Task<IList<Region>> GetAll(long idEMpresa)
        {
            using (var db = new PDbContext())
            {
                try
                {
                    return await db.Regiones.Where(x => x.Borrado != true && x.IdEmpresa==idEMpresa).ToListAsync();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public IEnumerable<Region> GetAllN()
        {
            var db = new PDbContext();
                try
                {
                    return  db.Regiones.Where(x => x.Borrado != true).ToList();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            
        }

        public async Task Delete(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

      

    }
}
