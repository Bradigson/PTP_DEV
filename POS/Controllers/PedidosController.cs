using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.Models;

namespace POS.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;
        private readonly SuplidoresService _suplidoresService;
        public PedidosController()
        {
            _pedidoService = new PedidoService();
            _suplidoresService = new SuplidoresService();
        }

        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }
        // GET: Pedidos
        public async Task<ActionResult> Index()
        {
            return View(await _pedidoService.GetAll(idEmpresa()));
        }

        // GET: Pedidos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(await _pedidoService.GetById((int)id, idEmpresa()));
        }

        // GET: Pedidos/Create
        public async Task<ActionResult> Create()
        {
            await LoadLookUps();
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.IdEmpresa = idEmpresa();
                   await _pedidoService.Add(pedido);
                return RedirectToAction("Index");
            }

            await LoadLookUps();
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            await LoadLookUps();
            return View(await _pedidoService.GetById((int)id, idEmpresa()));
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdSuplidor,Detalle,Solicitado")]Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                await _pedidoService.Edit(pedido);
                return RedirectToAction("Index");
            }
            await LoadLookUps();
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(await _pedidoService.GetById((int)id, idEmpresa()));
        }
        public async Task<ActionResult> GetDetalleByPedido(int pedidoId)
        {
            var tes = Json(await _pedidoService.GetDetallesByPedido(pedidoId, idEmpresa()));
            return tes;
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _pedidoService.Delete(id, idEmpresa());
            return RedirectToAction("Index");
        }

        private async Task LoadLookUps()
        {
            ViewBag.Suplidores = new SelectList(await _suplidoresService.GetAll(idEmpresa()), "Id", "Nombre");
        }
    }
}
