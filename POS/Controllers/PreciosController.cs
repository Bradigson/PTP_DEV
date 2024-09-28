using System.Threading.Tasks;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.ViewModels;

namespace POS.Controllers
{
    public class PreciosController : Controller
    {
        private readonly ProductoService _productoService;
        private readonly PrecioService _precioService;

        public PreciosController()
        {
            _productoService = new ProductoService();
            _precioService = new PrecioService();   
        }
        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }
        public async Task<ActionResult> Index()
        {
            return View(await _precioService.GetProductPricesInfo(idEmpresa()));
        }
        public ActionResult SetProductPriceByNumber()
        {
            return View(new SetProductPriceByNumber());
        }
        [HttpPost]
        public async Task<ActionResult> SetProductPriceByNumber(SetProductPriceByNumber priceNumber)
        {
             await _precioService.SetPriceByNumber(priceNumber.PriceOption, idEmpresa());
 
            return View("SetProductPriceByNumber",new SetProductPriceByNumber());
        }

        public async Task<ActionResult> SetPrecios(int? id)
        {
            if (id == null) return RedirectToAction("Index", await _productoService.GetAll(idEmpresa()));
            return View(await _precioService.GetPrecioViewModel((int)id, idEmpresa()));
        }

        [HttpPost]
        public async Task<ActionResult> SetPrecios(ProductoPrecioInfoViewModel productoPrecio)
        {
            if (productoPrecio == null) return RedirectToAction("Index", await _productoService.GetAll(idEmpresa()));
            if (!ModelState.IsValid)
            {
                return View(productoPrecio);
            }
            await _precioService.AssignPrices(productoPrecio, idEmpresa());
            return RedirectToAction("Index");
        }

        public ActionResult SetAllProducts()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SetAllPrecios(SetProductsPriceViewModel productoPrecio)
        {
            if (productoPrecio == null) return RedirectToAction("Index", await _productoService.GetAll(idEmpresa()));
            if (!ModelState.IsValid)
            {
                return View("SetAllProducts", productoPrecio);
            }
            await _precioService.SetSamePrice(productoPrecio, idEmpresa());
            return RedirectToAction("Index");
        }
    }
}