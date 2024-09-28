using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Services.Contracts;
using DataLayer.Models;
using DataLayer.PDbContex;
using DataLayer.Enums;

namespace BussinessLayer.Services
{
    public class MovimientoAlmacenService : IMovimientoAlmacenService
    {
        private PDbContext _context;
        private CuentasPorPagarService _cppService;
        private CuentasPorPagar _cuentasPorPagar;
        private ProductoService _productoService;
        private TipoPagoService _ipoPagoService;
        private TipoMovimientoService _TipoMovimientoService;

        public MovimientoAlmacenService()
        {
            _context = new PDbContext();
            _cppService = new CuentasPorPagarService();
            _cuentasPorPagar = new CuentasPorPagar();
            _productoService = new ProductoService();
        }

        public async Task Create(MovimientoAlmacen mov, List<DetalleMovimientoAlmacen> dma, string fechaLimite, decimal montoInicial)
        {
            var newMovimiento = new MovimientoAlmacen
            {
                IdSuplidor = mov.IdSuplidor,
                IdTipoMovimiento = mov.IdTipoMovimiento,
                NoFactura = mov.NoFactura,
                Ncf = mov.Ncf,
                CantidadProducto = mov.CantidadProducto,
                TotalFacturado = mov.TotalFacturado,
                IdAlmacen = mov.IdAlmacen,
                IdTipoPago = mov.IdTipoPago,
                IdEmpresa=mov.IdEmpresa



            };
            await Add(mov, dma, fechaLimite,montoInicial);
        }

        public async Task Add(MovimientoAlmacen entity, List<DetalleMovimientoAlmacen> dma, string fechaLimite, decimal montoInicial)
        {
            try
            {

                _context.MovimientoAlmacenes.Add(entity);

                await _context.SaveChangesAsync();

                int maxId = this.GetMaxIdMovimientoAlmacen();


                _ipoPagoService = new TipoPagoService();
                var tp = await _ipoPagoService.GetById(entity.IdTipoPago, entity.IdEmpresa);
                _TipoMovimientoService = new TipoMovimientoService();
                var tpm = await _TipoMovimientoService.GetById(entity.IdTipoMovimiento, entity.IdEmpresa);

                if ((DataLayer.Enums.TipoPago) int.Parse(tp.IN_OUT.ToString()) == DataLayer.Enums.TipoPago.Credito)
                {
                    _cuentasPorPagar.Descripcion = "N/A";
                    
                    _cuentasPorPagar.IdMovimientoAlmacen = maxId;
                    _cuentasPorPagar.MontoDeuda = (entity.TotalFacturado- montoInicial);
                    _cuentasPorPagar.MontoInicial = montoInicial; //Pendiente
                    
                    _cuentasPorPagar.Restante= (entity.TotalFacturado - montoInicial);

                    _cuentasPorPagar.FechaLimitePago = Convert.ToDateTime(fechaLimite);
                    _cuentasPorPagar.FechaUltimoPago = DateTime.Now; //Pendiendte => debe venir del detalle
                    _cuentasPorPagar.IsPaid = false;
                    _cuentasPorPagar.IdUsuario = 0; //Pediente;
                    _cuentasPorPagar.IdEmpresa = entity.IdEmpresa;
                    
                   


                     await _cppService.AddWithInicial(_cuentasPorPagar);
                    foreach (var d in dma)
                    {
                        d.IdMovimiento = maxId;
                        d.IdEmpresa = entity.IdEmpresa;
                        _context.DetalleMovimientoAlmacenes.Add(d);
                        await _context.SaveChangesAsync();
                    }

                    foreach (var d in dma)
                    {
                        d.IdMovimiento = maxId;
                        Producto p = _context.Productos.Find(d.IdProducto);
                        p.CantidadInventario += d.Cantidad;
                        d.IdEmpresa = tpm.IdEmpresa;
                        _context.Entry(p).State = EntityState.Modified;
                        _context.DetalleMovimientoAlmacenes.Add(d);
                        await _context.SaveChangesAsync();
                    }

                }
                else if ((DataLayer.Enums.TipoPago)int.Parse(tp.IN_OUT.ToString()) == DataLayer.Enums.TipoPago.Contado)
                {

                    if ((TipoMovimientoEnum)int.Parse(tpm.IN_OUT.ToString()) == TipoMovimientoEnum.ENTRADA)
                    {
                        foreach (var d in dma)
                        {
                            d.IdMovimiento = maxId;
                            Producto p = _context.Productos.Find(d.IdProducto);
                            p.CantidadInventario += d.Cantidad;
                            d.IdEmpresa = tpm.IdEmpresa;
                            _context.Entry(p).State = EntityState.Modified;
                            _context.DetalleMovimientoAlmacenes.Add(d);
                            await _context.SaveChangesAsync();
                        }
                    }
                    else if((TipoMovimientoEnum)int.Parse(tpm.IN_OUT.ToString()) == TipoMovimientoEnum.SALIDA ||
                        (TipoMovimientoEnum)int.Parse(tpm.IN_OUT.ToString()) == TipoMovimientoEnum.DEVOLUCION)
                    {
                        foreach (var d in dma)
                        {
                            d.IdMovimiento = maxId;
                            Producto p = _context.Productos.Find(d.IdProducto);
                            p.CantidadInventario -= d.Cantidad;
                            d.IdEmpresa= tpm.IdEmpresa;
                            _context.Entry(p).State = EntityState.Modified;
                            _context.DetalleMovimientoAlmacenes.Add(d);
                            await _context.SaveChangesAsync();
                        }
                    }


                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }




        public async Task Edit(MovimientoAlmacen entity)
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

        public async Task<MovimientoAlmacen> GetById(int id, long idEMpresa)
        {
            try
            {
                return await _context.MovimientoAlmacenes.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<MovimientoAlmacen>> GetAll(long idEMpresa)
        {
            return await _context.MovimientoAlmacenes.Where(x => x.Borrado != true && x.IdEmpresa== idEMpresa).ToListAsync();
        }

        public async Task Delete(int id, long idEMpresa)
        {
            var entity = await _context.MovimientoAlmacenes.Where(x=>x.IdEmpresa== idEMpresa && x.Id==id).SingleAsync();
            if (entity != null)
            {
                entity.Borrado = true;
                await _context.SaveChangesAsync();
            }
        }

        public int GetMaxIdMovimientoAlmacen()
        {
            int maxID = _context.MovimientoAlmacenes.Max(x => x.Id);
            return maxID;
        }

        public Task Create()
        {
            throw new NotImplementedException();
        }

        public Task Add(MovimientoAlmacen entity)
        {
            throw new NotImplementedException();
        }
    }
}
