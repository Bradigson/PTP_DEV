using System.Threading.Tasks;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.Models;

namespace POS.Controllers
{
    public class TipoDePagoController : Controller
    {
        private TipoPagoService _tipoPago;

        public TipoDePagoController()
        {
            _tipoPago= new TipoPagoService();
        }
        // GET: TipoDePago
        public async Task<ActionResult> Index()
        {
            return View( await _tipoPago.GetAll(idEmpresa()));
        }
        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }
        public async Task<ActionResult> CrearTipoPago()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CrearTipoPago(TipoPago tp)
        {
           await _tipoPago.Add(tp);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> EditarTipoPago(int id)
        {
            return View(await _tipoPago.GetById(id, idEmpresa()));
        }

        [HttpPost]
        public async Task<ActionResult> EditarTipoPago(TipoPago tp)
        {
            await _tipoPago.Edit(tp);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> EliminarTp(int id)
        {
            await _tipoPago.Delete(id, idEmpresa());
            return RedirectToAction("Index");
        }
    }
}