using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models.Caja;
using DataLayer.PDbContex;

namespace POS.Controllers
{
    public class TipoMovimientoBancoesController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: TipoMovimientoBancoes
        public async Task<ActionResult> Index()
        {
            var tipoMovimientoBancoes = db.TipoMovimientoBancoes.Include(t => t.empresa).Include(t => t.usuruario);
            return View(await tipoMovimientoBancoes.ToListAsync());
        }

        // GET: TipoMovimientoBancoes/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMovimientoBanco tipoMovimientoBanco = await db.TipoMovimientoBancoes.FindAsync(id);
            if (tipoMovimientoBanco == null)
            {
                return HttpNotFound();
            }
            return View(tipoMovimientoBanco);
        }

        // GET: TipoMovimientoBancoes/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP");
            ViewBag.IdUsuarioCrea = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO");
            return View();
        }

        // POST: TipoMovimientoBancoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descripcion,FechaCreacion,DebitoCreditootro,InternoExterno,IdUsuarioCrea,Estado,IdEmpresa")] TipoMovimientoBanco tipoMovimientoBanco)
        {
            if (ModelState.IsValid)
            {
                db.TipoMovimientoBancoes.Add(tipoMovimientoBanco);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", tipoMovimientoBanco.IdEmpresa);
            ViewBag.IdUsuarioCrea = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", tipoMovimientoBanco.IdUsuarioCrea);
            return View(tipoMovimientoBanco);
        }

        // GET: TipoMovimientoBancoes/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMovimientoBanco tipoMovimientoBanco = await db.TipoMovimientoBancoes.FindAsync(id);
            if (tipoMovimientoBanco == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", tipoMovimientoBanco.IdEmpresa);
            ViewBag.IdUsuarioCrea = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", tipoMovimientoBanco.IdUsuarioCrea);
            return View(tipoMovimientoBanco);
        }

        // POST: TipoMovimientoBancoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descripcion,FechaCreacion,DebitoCreditootro,InternoExterno,IdUsuarioCrea,Estado,IdEmpresa")] TipoMovimientoBanco tipoMovimientoBanco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoMovimientoBanco).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", tipoMovimientoBanco.IdEmpresa);
            ViewBag.IdUsuarioCrea = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", tipoMovimientoBanco.IdUsuarioCrea);
            return View(tipoMovimientoBanco);
        }

        // GET: TipoMovimientoBancoes/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMovimientoBanco tipoMovimientoBanco = await db.TipoMovimientoBancoes.FindAsync(id);
            if (tipoMovimientoBanco == null)
            {
                return HttpNotFound();
            }
            return View(tipoMovimientoBanco);
        }

        // POST: TipoMovimientoBancoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            TipoMovimientoBanco tipoMovimientoBanco = await db.TipoMovimientoBancoes.FindAsync(id);
            db.TipoMovimientoBancoes.Remove(tipoMovimientoBanco);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
