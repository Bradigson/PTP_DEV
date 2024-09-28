using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.Models;

namespace POS.Controllers
{
    public class CuentasPorCobrarController : Controller
    {
        private readonly CuentaPorCobrarService _cxCService;
        private readonly DetalleCuentaPorCobrarService _dCxCService;
        private  readonly ClienteService _lienteService;
        private readonly FacturacionService _facturacionService; 
        public CuentasPorCobrarController()
        {
            _cxCService = new CuentaPorCobrarService();
            _dCxCService = new DetalleCuentaPorCobrarService();
            _lienteService = new ClienteService();
            _facturacionService = new FacturacionService();
        }
        // GET: CuentasPorCobrar
        public async Task<ActionResult> Index()
        {

            return View(await _cxCService.GetAll(idEmpresa()));
        }

        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }

        public async Task<ActionResult> HacerPagosaCuenta(int id)
        {
            var cxc = await _cxCService.GetById(id,idEmpresa());
         
            var cliente = await _lienteService.GetById(cxc.ClienteId, idEmpresa());

            ViewData["Monto"] = cxc.MontoTotal;
            ViewData["Cliente"] = cliente.Nombre + " " + cliente.Apellido;
            ViewData["NoFactura"] = cxc.FacturacionId;
            ViewData["IdCta"] = id;
            ViewData["Restante"] = cxc.MontoPendiente;
            ViewData["idmov"] = id;

            return View(await _dCxCService.GetAllByCuentaPorCobrarId(id));
        }

        [HttpPost]
        public async Task<ActionResult> HacerPagosaCuenta(string Monto,int idCta)
        {

            DetalleCuentasPorCobrar dc= new DetalleCuentasPorCobrar();
            dc.Monto = Decimal.Parse(Monto);
            dc.FacturacionId = idCta;
            dc.FechaPago = DateTime.Now;
            dc.IsCalceled = false;
            

            await _dCxCService.Add(dc);
            return RedirectToAction("HacerPagosaCuenta",new{id=idCta});
        }
    }
}