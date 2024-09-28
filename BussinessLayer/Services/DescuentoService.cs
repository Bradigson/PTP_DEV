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
    public class DescuentoService : IDescuentoService
    {
        public async Task Add(Descuentos entity)
        {
            using (var context = new PDbContext())
            {
                try
                {
                    entity.Activo = DateTime.Today >= entity.FechaInicio && DateTime.Today <= entity.FechaFin;
                    context.Descuentos.Add(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task Edit(Descuentos entity)
        {
            using (var context = new PDbContext())
            {
                var descuentoToEdit = await context.Descuentos.FindAsync(entity.Id);
                if (descuentoToEdit == null) return;

                descuentoToEdit.IdProducto = entity.IdProducto;
                descuentoToEdit.Activo = entity.Activo;
                descuentoToEdit.DescuentoFijo = entity.DescuentoFijo;
                descuentoToEdit.DescuentoPorcentaje = entity.DescuentoPorcentaje;
                descuentoToEdit.FechaFin = entity.FechaFin;
                descuentoToEdit.FechaInicio = entity.FechaInicio;
                descuentoToEdit.TipoDescuento = entity.TipoDescuento;
                descuentoToEdit.Borrado = entity.Borrado;
                

                await context.SaveChangesAsync();
            }
        }

        public async Task<Descuentos> GetById(int id, long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                return await context.Descuentos.Include(x => x.Producto).SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
        }

        public async Task<IList<Descuentos>> GetAll(long idEMpresa)
        {
            using (var context = new PDbContext())
            {
                var list = await context.Descuentos.Include(x => x.Producto.Version.Marca).Where(x => x.Borrado == false).ToListAsync();

                if (!list.Any()) return list;
                {
                    foreach (var x in list)
                    {
                        x.NombreProducto = $"{x.Producto?.Version.Marca.Nombre} {x.Producto?.Version.Nombre}";
                    }
                }

                return list;
            }
        }

        public async Task Delete(int id, long idEMpresa)
        {
            var descuento = await GetById(id,idEMpresa);
            if (descuento == null) return;

            descuento.Borrado = true;
            await Edit(descuento);

        }
    }
}