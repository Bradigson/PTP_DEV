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
    public class AlmacenesService:IAlmacenesService
    {
      
        public async Task Add(Almacenes entity)
        {
            
            using (var context= new PDbContext())
            {
                try
                {
                    context.Almacenes.Add(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    throw;
                }
            }
               
            
        }

        public async  Task<Almacenes> GetById(int id, long idEmpresa)
        {
            using (var context = new PDbContext())
            {
                return await context.Almacenes.Where(x=>x.Id==id && x.IDEmpresa==idEmpresa).FirstOrDefaultAsync();
            }

        }
        public async Task<IList<Almacenes>> GetPrincipal(long idEmpresa)
        {
            using (var context = new PDbContext())
            {
                return await context.Almacenes.Where(x => x.Borrado != true && x.AlmacenPrincipal == "S" && x.IDEmpresa == idEmpresa).ToListAsync();
            }

        }
        public async Task<IList<Almacenes>> GetAll(long idEmpresa)
        {
            var context = new PDbContext();
            
                try
                {
                
                return await context.Almacenes.Where(x => x.Borrado != true && x.IDEmpresa == idEmpresa).ToListAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            
        }

        public async Task Delete(int id,long idEmpresa)
        {
            using (var context = new PDbContext())
            {
                Almacenes alm = await context.Almacenes.Where(x=>x.Id==id && x.IDEmpresa==idEmpresa).FirstOrDefaultAsync();
                if (alm != null)
                {
                    alm.Borrado = true;
                   await context.SaveChangesAsync();
                }
            }
              
            
        }

        public async Task Edit(Almacenes entity)
        {
            using (var context= new PDbContext())
            {
                try
                {
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

      
    }
}
