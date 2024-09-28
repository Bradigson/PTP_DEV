using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Services.Contracts;
using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.PDbContex;
using DataLayer.ViewModels;
using TipoPago = DataLayer.Enums.TipoPago;

namespace BussinessLayer.Services
{
    public class FacturacionService : IFacturacionService
    {
        private PDbContext _context;
        private DetalleFacturacionService _detalleFacturacionService;
        private CuentaPorCobrarService _cuentasPorCobrarService;
        private CuentasPorCobrar _cuentasPorCobrar;
        private readonly DgiiNcfService _dgii;

        public FacturacionService()
        {
            _context = new PDbContext();
            _detalleFacturacionService = new DetalleFacturacionService();
            _cuentasPorCobrarService = new CuentaPorCobrarService();
            _dgii = new DgiiNcfService();
        }


        public async Task Create(FacturacionViewModel vm)
        {


            if (vm.Facturacion != null && vm.DetalleFacturacions.Count > 0)
            {
                //Facturar
                string ncf = await _dgii.GetSeqNcfByTipoNcf(vm.Facturacion.SecuenciaId);

                vm.Facturacion.Ncf = string.IsNullOrEmpty(ncf)? " -":ncf;
                DgiiNcfSecuencia ncfEditar = await _dgii.FindNcfBySequencial(ncf);
                vm.Facturacion.SecuenciaId = ncfEditar.Id;
                await this.Add(vm.Facturacion);

                //Cambiar estado de NCF a True(Enviado a la Dgii)
                
                ncfEditar.Estado = true;
                await _dgii.Edit(ncfEditar);


                var maxId = await _context.Facturacion.MaxAsync(x => x.Id);

                if ((TipoPago)vm.Facturacion.TipoPagoId == TipoPago.Credito)
                {
                    _cuentasPorCobrar = new CuentasPorCobrar();
                    _cuentasPorCobrar.FacturacionId = vm.Facturacion.Id;
                    _cuentasPorCobrar.ClienteId = vm.Facturacion.ClienteId;
                    _cuentasPorCobrar.IsPaid = false;
                    _cuentasPorCobrar.FechaLimite = DateTime.Now;
                    _cuentasPorCobrar.FechaUltimoPago = DateTime.Now; //Revisar
                    _cuentasPorCobrar.MontoInicial = 0;
                    _cuentasPorCobrar.MontoPendiente = vm.Facturacion.MontoTotal; //Menos monto inicial
                    _cuentasPorCobrar.MontoTotal = vm.Facturacion.MontoTotal;
                    _cuentasPorCobrar.Borrado = false;
                    _cuentasPorCobrar.IdEmpresa = vm.Facturacion.IdEmpresa;

                    _cuentasPorCobrar.DetalleCuentasPorCobrar = new List<DetalleCuentasPorCobrar>
                   
                    {
                        new DetalleCuentasPorCobrar()
                        {
                            Monto = _cuentasPorCobrar.MontoInicial,
                            FechaPago =DateTime.Now,
                            IdUsuario = vm.Facturacion.CodigoUsuario, // Identity
                            IsCalceled = false
                            ,IdEmpresa=vm.Facturacion.IdEmpresa
                }
                    };
                    await _cuentasPorCobrarService.Add(_cuentasPorCobrar);
                  

                }

                foreach (var d in vm.DetalleFacturacions)
                {
                    d.FacturacionId = maxId;
                    d.IdEmpresa= vm.Facturacion.IdEmpresa;

                    await _detalleFacturacionService.Add(d);

                    //Reduccion Inventario y aumento en Servicios
                    Producto p = await _context.Productos.FindAsync(d.ProductoId);
                    if(p.EsProducto=="S")
                    { p.CantidadInventario = p.CantidadInventario + d.Cantidad; }
                    else { p.CantidadInventario = p.CantidadInventario - d.Cantidad; }
                    
                    _context.Entry(p).State = EntityState.Modified;
                    //Fin Reduccion

                    await _context.SaveChangesAsync();

                }
            }
        }

        public async Task Add(Facturacion entity)
        {
            if (entity != null)
            {
                try
                {

                    entity.Borrado = false;
                    entity.Comentario = "N/A";
                    entity.Justificacion = "N/A";
                    //entity.Id = 0;
                    _context.Facturacion.Add(entity);
                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task Edit(Facturacion entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Facturacion> GetById(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Facturacion>> GetAll(long idEMpresa)
        {
            return await _context.Facturacion.Where(x => x.Borrado != true).Include(x => x.Cliente).ToListAsync();
        }

        public async Task Delete(int id, long idEMpresa)
        {
            throw new NotImplementedException();
        }


    }
}
