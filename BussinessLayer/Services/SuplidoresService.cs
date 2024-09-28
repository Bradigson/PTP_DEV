using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Services.Contracts;
using DataLayer.Models;
using DataLayer.PDbContex;
using DataLayer.ViewModels;

namespace BussinessLayer.Services
{
    public class SuplidoresService : ISuplidoresService
    {
        private PDbContext _context;

        public SuplidoresService()
        {
            _context = new PDbContext();
        }
   


        public async Task Add(Suplidores entity)
        {

            try
            {


                _context.Suplidores.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public async Task Edit(Suplidores entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Suplidores> GetById(int id, long idEMpresa)
        {
            return await _context.Suplidores.Where(x=>x.Id==id && x.IdEmpresa==idEMpresa).FirstOrDefaultAsync(); 
        }

        public async Task<IList<Suplidores>> GetAll(long idEMpresa)
        {
            return await  _context.Suplidores.Where(x => x.Borrado != true && x.IdEmpresa== idEMpresa).ToListAsync();
        }

        public async Task Delete(int id, long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                var cl = await context.Suplidores.FindAsync(id);
                if (cl == null) return;

                cl.Borrado = true;
                await context.SaveChangesAsync();
            }
        }


    }
}
