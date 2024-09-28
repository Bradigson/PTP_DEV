using BussinessLayer.Services;
using DataLayer.Models;
using DataLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class MovimientoAlmacenController : Controller
    {
        private readonly MovimientoAlmacenService _movimientoAlmacenService;
        private readonly DetalleMovimientoAlmacenService _detalleMovimientoService;
        private readonly ClienteService _clienteService;
        private readonly AlmacenesService _almacenesService;
        private readonly SuplidoresService _suplidoresService;
        private readonly TipoMovimientoService _tipoMovimientoService;
        private readonly TipoPagoService _tipoPagoService;
        private readonly ProductoService _productoService;
        private readonly PedidoService _pedidoService;
        public MovimientoAlmacenController()
        {
            _movimientoAlmacenService = new MovimientoAlmacenService();
            _detalleMovimientoService = new DetalleMovimientoAlmacenService();
            _almacenesService = new AlmacenesService();
            _suplidoresService = new SuplidoresService();
            _tipoMovimientoService = new TipoMovimientoService();
            _tipoPagoService = new TipoPagoService();
            _productoService = new ProductoService();
            _clienteService = new ClienteService();
            _pedidoService = new PedidoService();

        }
        // GET: MovimientoAlmacen
        public async Task<ActionResult> Index()
        {

            return View(await _movimientoAlmacenService.GetAll(idEmpresa()));
        }
     
        private long idEmpresa()
        {
          
            return long.Parse(Session["IDEmpresa"].ToString());
           

        }
        public async Task<ActionResult> CrearMovimiento()
        {
            var idEmpresaN = idEmpresa();


            ViewData["Almacenes"] = await _almacenesService.GetPrincipal(idEmpresaN);
            ViewData["Suplidores"] = await _suplidoresService.GetAll(idEmpresaN);
            ViewData["TipoMovimiento"] = await _tipoMovimientoService.GetAll(idEmpresaN);
            ViewData["TipoPago"] = await _tipoPagoService.GetAll(idEmpresaN);

            return View();
        }



        public async Task<ActionResult> ListaProductos()
        {

            return PartialView("ListaProductos", await _productoService.GetAll(idEmpresa()));
        }

        public async Task<ActionResult> ListaClientes()
        {

            return PartialView("_ListaClientes", await _clienteService.GetAll(idEmpresa()));
        }

        //public async Task<JsonResult> AddSingleClient(int idCliente)
        //{
        //    var c = await _clienteService.GetById(idCliente);
        //    return Json(new
        //    {
        //        Nombre = c.Nombre,
        //        Empresa = c.Empresa,
        //        IdCliente = c.Id
        //    }, JsonRequestBehavior.AllowGet);
        //}


        public async Task<JsonResult> AddSingleProduct(int idProducto)
        {

            var p = await _productoService.GetById(idProducto, idEmpresa());

            return Json(new
            {
                Checkbox = $"<button type='button' id='b{p.Id}' class='btn btn-danger btn-sm'> X</button> ",
                Id = p.Id,
                CodProducto = p.Codigo,
                Producto = p.Version.Marca.Nombre + ' ' + p.Version.Nombre,
                Envase = p.Envase.Descripcion,
                Existencia = p.CantidadInventario,
                Precio = $"<input type='number' value='{p.PrecioCompra}' class='form-control' id='PrecioCompra' name='PrecioCompra' />" ,
                Cantidad = $"<input type='number' value='0' class='form-control cantidad' id='{p.Id}' name='Cantidad' />",
                Subtotal = $"<input type='number' class='form-control subtotal' id='t{p.Id}' readonly name='subTotal' />"
                

            }, JsonRequestBehavior.AllowGet);



        }


        public async Task<JsonResult> GetSingleProductByCB(string cb = "")
        {
            var p2 = await _productoService.GetProductoByCB(idEmpresa(),cb);

           return Json(new
            {
                Checkbox = $"<button id='b{p2.Id}' class='btn btn-danger btn-sm'> X</button> ",
                Id = p2.Id,
                CodProducto = p2.Codigo,
                Producto = p2.Version.Marca.Nombre + ' ' + p2.Version.Nombre,
                Envase = p2.Envase.Descripcion,
                Existencia = p2.CantidadInventario,
                Precio = $"<input type='number' value='{p2.PrecioCompra}' class='form-control' id='{p2.Id}P' name='PrecioCompra' />",
                Cantidad = $"<input type='number'value='0' class='form-control cantidad' id='{p2.Id}' name='Cantidad' />",
                Subtotal = $"<input type='number'  class='form-control subtotal' id='t{p2.Id}' readonly name='subTotal' />"
              
            }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public async Task<ActionResult> ProcesarMovimiento(MovimientoAlmacen vm, List<DetalleMovimientoAlmacen> dma,string fechaLimite="",string montoInicial ="")
        {
          
            if (vm != null || dma != null)
             {
                vm.IdEmpresa = idEmpresa();
                
                List<DetalleMovimientoAlmacen> cantidadProducto = dma;
                foreach (var c in cantidadProducto)
                {
                    vm.CantidadProducto += c.Cantidad;
                }
                
                await _movimientoAlmacenService.Create(vm, dma,fechaLimite,decimal.Parse(montoInicial));
                return RedirectToAction("Index");
            }



            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DetalleMovimiento(int idMovimiento)
        {
            var idEmpresaN = idEmpresa();
            
            var mov = await _movimientoAlmacenService.GetById(idMovimiento, idEmpresaN);
            ViewData["Movimiento"] = mov;
            ViewData["Almacenes"] = await _almacenesService.GetById(mov.IdAlmacen,idEmpresaN);
            ViewData["Suplidores"] = await _suplidoresService.GetById(mov.IdSuplidor,idEmpresaN);
            ViewData["TipoMovimiento"] = await _tipoMovimientoService.GetById(mov.IdTipoMovimiento,idEmpresaN);
            ViewData["TipoPago"] = await _tipoPagoService.GetById(mov.IdTipoPago,idEmpresaN);
            return View(await _detalleMovimientoService.GetDetalleMovimientoByMovimientoId(idMovimiento, idEmpresaN));
        }


        public async Task<JsonResult> GetDesgloseByPedidoId(int pedidoId)
        {
            var detalle = await _pedidoService.GetDetallePedidoByPedidoId(pedidoId);
            var header = await _pedidoService.GetHeaderFromDetalle(pedidoId);

            MovimientoAlmacen mov = new MovimientoAlmacen();
            ViewModelOfViewModel vmovm = new ViewModelOfViewModel();

            mov.IdSuplidor = header.Suplidor.Id;




            List<ProductosFromPedidoVm> vm = new List<ProductosFromPedidoVm>();

            foreach (var d in detalle)
            {
                foreach(var dd in d.Detalle)
                {
                    vm.Add(new ProductosFromPedidoVm
                    {

                        IdProducto = dd.Producto.Id,
                        Cantidad = $"<input type='number' class='form-control cantidad' value='{dd.Cantidad}' id='{dd.Producto.Id}' name='Cantidad' />",
                        Subtotal = $"<input type='number' class='form-control subtotal' id='t{dd.Producto.Id}' readonly name='subTotal' />",
                        Eliminar = $"<button id='b{dd.Producto.Id}' class='btn btn-danger btn-sm'> X</button> ",
                        Existencia = dd.Producto.CantidadInventario,
                        CodProducto = dd.Producto.Codigo,
                        Producto = dd.Producto.Version.Marca.Nombre + " " + dd.Producto.Version.Nombre,
                        Envase = dd.Producto.Envase.Descripcion,
                        Precio = dd.Producto.PrecioCompra

                    });
                }
            
            }
            vmovm.ProductosFromPedidos = vm;
            vmovm.MovimientoAlmacen = mov;


            return Json(vmovm, JsonRequestBehavior.AllowGet);
        }

    }
}