using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.ViewModels;

namespace POS.Controllers
{
    public class CotizacionController : Controller
    {
        private readonly CotizacionService _cotizacionService;

        public CotizacionController()
        {
            
            _cotizacionService= new CotizacionService();
        }
        // GET: Cotizacion
        public async Task<ActionResult> Index()
        {

            return View(await _cotizacionService.GetAll(idEmpresa()));
        }
        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }

        private int idCodigoUsuario()
        {
            return int.Parse(Session["ID"].ToString());

        }
        public async Task<ActionResult> Cotizar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cotizar(CotizacionViewModel Cotizar)
        {
            if (Cotizar.Cotizacion != null && Cotizar.DetalleCotizacion.Length > 0)
            {
                Cotizar.Cotizacion.IdEmpresa = idEmpresa();
                Cotizar.Cotizacion.EmpleadoId = idCodigoUsuario();
              await _cotizacionService.Create(Cotizar);
                return Json(1, JsonRequestBehavior.DenyGet);

            }

            return Json(0,JsonRequestBehavior.DenyGet);
            
        }
    }
}