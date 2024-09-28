using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.Enums;
using DataLayer.Models;

namespace POS.Controllers
{
    public class DescuentosController : Controller
    {
        private readonly DescuentoService _descuentoService;
        private readonly ProductoService _productoService;

        public DescuentosController()
        {
            _descuentoService = new DescuentoService();
            _productoService = new ProductoService();
        }

        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }

        // GET: Descuentos
        public async Task<ActionResult> Index()
        {
            return View(await _descuentoService.GetAll(idEmpresa()));
        }

        // GET: Descuentos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            return id == null ? View("Index",await _descuentoService.GetAll(idEmpresa())):View(await _descuentoService.GetById((int)id, idEmpresa()));
        }

        // GET: Descuentos/Create
        public async Task<ActionResult> Create()
        {
            await LoadLookUps();
            return View();
        }

        // POST: Descuentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = ",IdProducto,DescuentoPorcentaje,DescuentoFijo,FechaInicio,FechaFin,TipoDescuento")] Descuentos descuentos)
        {
            if (!ModelState.IsValid)
            {
                await LoadLookUps();
                return View(descuentos);
            }

            await _descuentoService.Add(descuentos);
            return View("Index", await _descuentoService.GetAll(idEmpresa()));
        }

        // GET: Descuentos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return View("Index");
            await LoadLookUps();
            return View(await _descuentoService.GetById((int)id, idEmpresa()));
        }


        // POST: Descuentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdProducto,DescuentoPorcentaje,DescuentoFijo,FechaInicio,FechaFin,TipoDescuento,Activo")] Descuentos descuentos)
        {
            if (descuentos == null) return View("Index");

            if (!ModelState.IsValid) return View(descuentos);
         
            await _descuentoService.Edit(descuentos);
            return RedirectToAction("Index",await _descuentoService.GetAll(idEmpresa()));
        }

        // GET: Descuentos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var x = await _descuentoService.GetById((int)id, idEmpresa());

            }
            return id == null ? View("Index",await  _descuentoService.GetAll(idEmpresa())) : View(await _descuentoService.GetById((int)id, idEmpresa()));
        }

        // POST: Descuentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _descuentoService.Delete(id, idEmpresa());
            return RedirectToAction("Index", await _descuentoService.GetAll(idEmpresa()));

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private async Task LoadLookUps()
        {
            ViewBag.Productos = new SelectList(await _productoService.GetInfoViewModelList(idEmpresa()),"Id", "NombreCompleto");
            var tiposDescuento = from TipoDescuento e in Enum.GetValues(typeof(TipoDescuento))
                select new
                {
                    ID = (int)e,
                    Name = e.ToString()
                };
            ViewBag.TiposDescuento = new SelectList(tiposDescuento,"ID","Name");
        }
    }
}
