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
    public class ClienteService : IClientesService
    {
      
        public async Task Add(Cliente entity)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    context.Clientes.Add(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                    
                }
                
            }
          
        }

        public async Task<Cliente> GetById(int id,long idEmpresa)
        {
                var context= new PDbContext();
                return await context.Clientes.Where(x=>x.IdEmpresa== idEmpresa && x.Id==id).SingleAsync();
            
        }

        public async  Task<IList<Cliente>> GetAll(long idEmpresa)
        {
            var context = new PDbContext();
            
                try
                {
                    return await context.Clientes.Where(x => x.Borrado != true && x.IdEmpresa== idEmpresa).ToListAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            
        }

        public async Task Delete(int id, long empresa)
        {
            using (var context = new PDbContext())
            {
                var cl = await context.Clientes.FindAsync(id);
                if (cl == null) return;

                cl.Borrado = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task  Edit(Cliente entity)
        {

            using (var context = new PDbContext())
            {
                try
                {
                    //var oldCliente = await context.Clientes.FindAsync(entity.Id);
                    //if (oldCliente == null) return;

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
