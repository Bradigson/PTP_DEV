using BussinessLayer.Services;
using DataLayer.Enums;
using DataLayer.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly ProductoService _productoService;
        private readonly ClienteService _clienteService;
        private readonly FacturacionService _facturacionService;
        private readonly TipoPagoService _tipoPagoService;
        private readonly TipoTransaccionService _tipoTransaccionService;
        private readonly DgiiNcfService _dgiiNcfService;
        public FacturacionController()
        {
            _productoService = new ProductoService();
            _clienteService = new ClienteService();
            _facturacionService = new FacturacionService();
            _tipoPagoService = new TipoPagoService();
            _tipoTransaccionService = new TipoTransaccionService();
            _dgiiNcfService = new DgiiNcfService();

        }
        // GET: Facturacion
        public async Task<ActionResult> Index()
        {

            return View(await _facturacionService.GetAll(idEmpresa()));
        }
        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }
        private int codigoUsuario()
        {
            return int.Parse(Session["ID"].ToString());

        }


        public async Task<ActionResult> Facturar()
        {
            var idEmpre = idEmpresa();
            //Tipo De Pago
            var tipoPago = await _tipoPagoService.GetAll(idEmpre);
            ViewData["TipoPago"] = tipoPago;

            //Tipo Transaccion
            var tipoTransaccion = _tipoTransaccionService.GetAllE(idEmpre);
            ViewData["TipoTransaccion"] = tipoTransaccion;

            //Tipo Ncf
            var tipoNcf = await _dgiiNcfService.GetAll(idEmpre);
            ViewData["TipoNcf"] = tipoNcf;

            return View();

        }


        [HttpPost]
        public async Task<ActionResult> Facturar(FacturacionViewModel fvm)
        {
            
            
            if (fvm != null && fvm.Facturacion != null && fvm.DetalleFacturacions.Count > 0)
            {
                try
                {
                    fvm.Facturacion.IdEmpresa = idEmpresa();
                    fvm.Facturacion.CodigoUsuario = codigoUsuario();

                    await _facturacionService.Create(fvm);
                    return Json(1, JsonRequestBehavior.DenyGet);
                }
                catch (Exception e)
                {
                    return Json(0, JsonRequestBehavior.DenyGet);
                }
            }

            return Json(0, JsonRequestBehavior.DenyGet);
        }

        public async Task<JsonResult> AddSingleProduct(int idProducto)
        
        {
         

            var p = await _productoService.GetById(idProducto, idEmpresa());
            var desc = p.Descuentos.SingleOrDefault(x => x.Activo);
            string descuentoValor = string.Empty;
            string valorImpuesto = string.Empty;
            if (p.AplicaImp == "S")
            {
                valorImpuesto = $"<input type='number' readonly value ='{p.ValorImpuesto}' class='form-control col-md-1 itbs' id='i{p.Id}' name='ITBS' size='4' />";

            }
            else
            {
                valorImpuesto = $"<input type='number' readonly value ='0' class='form-control col-md-1 itbs' id='i{p.Id}' name='ITBS' size='4' />";

            }
            if (desc != null && desc.TipoDescuento == TipoDescuento.Fijo)
            {
                p.PrecioBase = p.PrecioBase - desc.DescuentoFijo;
                return Json(new
                {
                    Id = p.Id,
                    CodProducto = p.Codigo,
                    Producto = p.Version.Marca.Nombre + ' ' + p.Version.Nombre,
                    Envase = p.Envase.Descripcion,
                    Existencia = p.CantidadInventario,
                    Precio = p.PrecioBase,
                    Cantidad = $"<input type='number' value='1' class='form-control col-md-1 cantidad'  id='{p.Id}' name='Cantidad' size='4' />",
                    ITBIS = valorImpuesto,
                    Descuento = $"<input type='text' readonly value='{desc.DescuentoFijo}' class='form-control descuento' size='4' id='d{p.Id}'  name='subTotal' />",
                    Subtotal = $"<input type='number' value='0' class='form-control subtotal' id='t{p.Id}'  readonly name='subTotal' size='8' />",
                    Checkbox = $"<button id='b{p.Id}' class='btn btn-danger btn-sm'> X</button> ",
                    ValorImpu = p.ValorImpuesto
                }, JsonRequestBehavior.AllowGet);
            }
             if (desc != null && desc.TipoDescuento == TipoDescuento.Porcentaje)
            {
                p.PrecioBase = p.PrecioBase -(p.PrecioBase * desc.DescuentoPorcentaje) / 100; //Cambiar a decimal en el Model
                return Json(new
                {
                    Id = p.Id,
                    CodProducto = p.Codigo,
                    Producto = p.Version.Marca.Nombre + ' ' + p.Version.Nombre,
                    Envase = p.Envase.Descripcion,
                    Existencia = p.CantidadInventario,
                    Precio = p.PrecioBase,
                    Cantidad = $"<input type='number' value='1' class='form-control col-md-1 cantidad' id='{p.Id}' name='Cantidad' size='4' />",
                    ITBIS = valorImpuesto ,
                    Descuento = $"<input type='text' readonly value='{(p.PrecioBase * desc.DescuentoPorcentaje) / 100}' class='form-control descuento' id='d{p.Id}'  name='subTotal' size='4' />",
                    Subtotal = $"<input type='number' value='0' class='form-control subtotal' id='t{p.Id}' readonly name='subTotal' size='8'/>",
                    Checkbox = $"<button id='b{p.Id}' class='btn btn-danger btn-sm'> X</button> ",
                    ValorImpu = p.ValorImpuesto
                }, JsonRequestBehavior.AllowGet);
            }
            if (p.AdmiteDescuento)
            {
                descuentoValor = $"<input type='number'  value='0' class='form-control descuento' id='d{p.Id}'  name='subTotal' size='4' />";
            }
            else
            {
                descuentoValor = $"<input type='text' readonly value='0' readonly class='form-control descuento' id='d{p.Id}'  name='subTotal' size='4' />";

            }
            return Json(new
            {
                Id = p.Id,
                CodProducto = p.Codigo,
                Producto = p.Version.Marca.Nombre + ' ' + p.Version.Nombre,
                Envase = p.Envase.Descripcion,
                Existencia = p.CantidadInventario,
                Precio = p.PrecioBase,
                Cantidad = $"<input type='number' value='1'  class='form-control cantidad col-xs-2' id='{p.Id}' name='Cantidad'  size='4' />",
                ITBIS = valorImpuesto,
                Descuento = descuentoValor,
                Subtotal = $"<input type='number'   value='0' class='form-control col-md-1 subtotal' id='t{p.Id}' readonly name='subTotal' size='8' />",
                Checkbox = $"<button id='b{p.Id}' class='btn btn-danger btn-sm'> X</button> ",
                ValorImpu=p.ValorImpuesto
            }, JsonRequestBehavior.AllowGet);



        }


        public async Task<JsonResult> GetSingleProductByCB(string cb = "")
        {

            var p2 = await _productoService.GetProductoByCBFactura(idEmpresa(), cb);
            if (p2 != null)
            {
                var desc = p2.Descuentos.SingleOrDefault(x => x.Activo);
                string descuentoValor = string.Empty;
                string valorImpuesto = string.Empty;
                if (p2.AplicaImp == "S")
                {
                    valorImpuesto = $"<input type='number' readonly value ='{p2.ValorImpuesto}' class='form-control col-md-1 itbs' id='i{p2.Id}' name='ITBS' size='4' />";

                }
                else
                {
                    valorImpuesto = $"<input type='number' readonly value ='0' class='form-control col-md-1 itbs' id='i{p2.Id}' name='ITBS' size='4' />";

                }

                if (desc != null && desc.TipoDescuento == TipoDescuento.Fijo)
                {
                    p2.PrecioBase = p2.PrecioBase - desc.DescuentoFijo;
                    return Json(new
                    {
                        Id = p2.Id,
                        CodProducto = p2.Codigo,
                        Producto = p2.Version.Marca.Nombre + ' ' + p2.Version.Nombre,
                        Envase = p2.Envase.Descripcion,
                        Existencia = p2.CantidadInventario,
                        Precio = p2.PrecioBase,
                        Cantidad = $"<input type='number' value='1' class='form-control cantidad col-xs-2' id='{p2.Id}' name='Cantidad' size='4' />",
                        ITBIS = valorImpuesto,
                        Descuento = $"<input type='text' readonly value='{desc.DescuentoFijo}' class='form-control descuento' id='d{p2.Id}'  name='subTotal' size='4' />",
                        Subtotal = $"<input type='number' class='form-control subtotal' id='t{p2.Id}' readonly name='subTotal' size='8' />",
                        Checkbox = $"<button id='b{p2.Id}' class='btn btn-danger btn-sm'> X</button> "
                    }, JsonRequestBehavior.AllowGet);
                }
                if (desc != null && desc.TipoDescuento == TipoDescuento.Porcentaje)
                {
                    p2.PrecioBase = p2.PrecioBase - (p2.PrecioBase * desc.DescuentoPorcentaje) / 100; //Cambiar a decimal en el Model
                    return Json(new
                    {
                        Checkbox = $"<button id='b{p2.Id}' class='btn btn-danger btn-sm'> X</button> ",
                        Id = p2.Id,
                        CodProducto = p2.Codigo,
                        Cantidad = $"<input type='number' value='1' class='form-control cantidad' id='{p2.Id}' name='Cantidad' size='4' />",
                        Producto = p2.Version.Marca.Nombre + ' ' + p2.Version.Nombre,
                        Descuento = $"<input type='text'  value='{(p2.PrecioBase * desc.DescuentoPorcentaje) / 100}' class='form-control descuento' id='d{p2.Id}'  name='subTotal' size='4' />",
                        Envase = p2.Envase.Descripcion,
                        Existencia = p2.CantidadInventario,
                        Precio = p2.PrecioBase,
                        ITBIS = valorImpuesto,
                        Subtotal = $"<input type='number'  class='form-control subtotal' id='t{p2.Id}' readonly name='subTotal' size='8' />"

                    }, JsonRequestBehavior.AllowGet);
                }
                if (p2.AdmiteDescuento)
                {
                    descuentoValor = $"<input type='number'  value='0' class='form-control descuento' id='d{p2.Id}'  name='subTotal' size='4' />";
                }
                else
                {
                    descuentoValor = $"<input type='text' readonly value='0' readonly class='form-control descuento' id='d{p2.Id}'  name='subTotal' size='4' />";

                }

                return Json(new
                {
                    Checkbox = $"<button id='b{p2.Id}' class='btn btn-danger btn-sm'> X</button> ",
                    Id = p2.Id,
                    CodProducto = p2.Codigo,
                    Cantidad = $"<input type='number' value='1' class='form-control cantidad' id='{p2.Id}' name='Cantidad'  size='4' />",
                    Producto = p2.Version.Marca.Nombre + ' ' + p2.Version.Nombre,
                    Descuento = descuentoValor,
                    Envase = p2.Envase.Descripcion,
                    Existencia = p2.CantidadInventario,
                    Precio = p2.PrecioBase,
                    ITBIS = valorImpuesto,
                    Subtotal = $"<input type='number'  class='form-control subtotal' id='t{p2.Id}' readonly name='subTotal' size='8' />"

                }, JsonRequestBehavior.AllowGet);
            } else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }



        public async Task<ActionResult> ListaProductos()
        {
            var prod = await _productoService.GetAllFacturacion(idEmpresa());
           

            return PartialView("_ListaProductos", prod);
        }

        public async Task<ActionResult> ListaClientes()
        {
            return PartialView("_ListaClientes", await _clienteService.GetAll(idEmpresa()));
        }

        public async Task<JsonResult> GetClienteById(int id)
        {
            return Json(await _clienteService.GetById(id, idEmpresa()), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> POS()
        {
            return View();
       }

        }
}