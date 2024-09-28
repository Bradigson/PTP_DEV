using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Services;
using System.Threading.Tasks;
using DataLayer.Models;

namespace POS.Controllers
{
    public class CuentasPorPagarController : Controller
    {
        private readonly CuentasPorPagarService _cuentasPorPagarService;
        private readonly DetalleCuentaPorPagarService _detalleCxPService;

        public CuentasPorPagarController()
        {
            _cuentasPorPagarService = new CuentasPorPagarService();
            _detalleCxPService = new DetalleCuentaPorPagarService();
        }
        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }

        // GET: CuentasPorPagar
        public async Task<ActionResult> Index()
        {
            return View(await _cuentasPorPagarService.GetAll(idEmpresa()));
        }

        public async Task<ActionResult> HacerPagos(int id)
        {
            CuentasPorPagar cxp= await _cuentasPorPagarService.GetById(id, idEmpresa());
            ViewData["Monto"] = cxp.MontoDeuda;
            ViewData["Suplidor"] = cxp.MovimientoAlmacen.Suplidor.Nombre;
            ViewData["NoFactura"] = cxp.MovimientoAlmacen.NoFactura;
            ViewData["IdCta"] = cxp.IdMovimientoAlmacen;
            ViewData["Restante"] = cxp.Restante;
            ViewData["idmov"] = id;
            return View(await _detalleCxPService.GetAllByIdCtaPorPagar(cxp.IdMovimientoAlmacen));
        }

        [HttpPost]
        public async Task<ActionResult> HacerPagos(string dma, string idCta,int idmov)
        {
            decimal monto = decimal.Parse(dma);
            DetalleCuentaPorPagar d = new DetalleCuentaPorPagar();
            d.Monto = monto;
            d.FechaPago = DateTime.Now;
            d.IdMovAlmacen = Convert.ToInt32(idCta);
            d.IsCanceled = false;
            d.IdEmpresa = idEmpresa();
         
            await _detalleCxPService.Add(d);

            return RedirectToAction("HacerPagos/"+ idmov);
        }
    }
}