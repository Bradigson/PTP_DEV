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
    public class MunicipioService : IMunicipioService
    {
        public Task Add(Municipio entity)
        {
            throw new NotImplementedException();
        }

        public Task<Municipio> GetById(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        async Task<IList<Municipio>> IBaseService<Municipio>.GetAll(long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Municipio>> GetAll(long idEMpresa)
        {
            using (var db = new PDbContext())
            {

                return await db.Municipios.Where(x => x.Borrado != true).ToListAsync();
            }
        }

        public Task Delete(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipio> GetMunicipiosByProvinciaId(int provinciaId)
        {
            var db = new PDbContext();


            return db.Municipios.ToList().Where(x => x.Borrado != true && x.IdProvincia == provinciaId);

        }

        public Task Edit(Municipio entity)
        {
            throw new NotImplementedException();
        }

        //Task IBaseService<Municipio>.Edit(Municipio entity)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Municipio> IBaseService<Municipio>.GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<Municipio>> IBaseService<Municipio>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //Task IBaseService<Municipio>.Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}
        

    
    }
}
