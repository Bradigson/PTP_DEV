using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.PDbContex;

namespace BussinessLayer.Services.Contracts
{
    public class ProvinciasService : IProvinciaService
    {
        public async Task Add(Provincia entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Provincia>> GetProvinciasByRegionId(int regionId)
        {
            var db = new PDbContext();
           return await  db.Provincias.Where(x => x.IdRegion == regionId).ToListAsync();
        }

        public Task Edit(Provincia entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Provincia>> GetAll(long idEMpresa)
        {
            using (var db = new PDbContext())
            {

                return await db.Provincias.Where(x => x.Borrado != true && x.IdEmpresa==idEMpresa).ToListAsync();
            }
        }

        public Task<Provincia> GetById(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Provincia> GetProvinciasByRegionId1(int regionId)
        {
            var db = new PDbContext();

            return db.Provincias.Where(x => x.IdRegion == regionId).ToList();
        }


    }
}
