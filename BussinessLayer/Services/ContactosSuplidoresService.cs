using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.PDbContex;

namespace BussinessLayer.Services.Contracts
{
    public class ContactosSuplidoresService:IContactosSuplidoresService
    {
        private PDbContext _context;

        public ContactosSuplidoresService()
        {
            _context= new PDbContext();
        }


        public async  Task Add(ContactosSuplidores entity)
        {
            try
            {
                _context.ContactosSuplidores.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Edit(ContactosSuplidores entity)
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

        public async Task<ContactosSuplidores> GetById(int id, long idempresa)
        {
            return await _context.ContactosSuplidores.FindAsync(id);

        }

        public async  Task<IList<ContactosSuplidores>> GetAll(long idempresa)
        {
            return await _context.ContactosSuplidores.Where(x => x.Borrado != true).ToListAsync();
        }

        public async Task Delete(int id, long idempresa)
        {
            try
            {
                var c = await _context.ContactosSuplidores.FindAsync(id);
                if (c != null)
                {
                    c.Borrado = true;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
