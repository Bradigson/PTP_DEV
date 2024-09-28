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
    public class MovimientoBancoesController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: MovimientoBancoes
        public async Task<ActionResult> Index()
        {
            var movimientoBancoes = db.MovimientoBancoes.Include(m => m.empresa).Include(m => m.sucursal).Include(m => m.usuruario);
            return View(await movimientoBancoes.ToListAsync());
        }

        // GET: MovimientoBancoes/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimientoBanco movimientoBanco = await db.MovimientoBancoes.FindAsync(id);
            if (movimientoBanco == null)
            {
                return HttpNotFound();
            }
            return View(movimientoBanco);
        }

        // GET: MovimientoBancoes/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP");
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC");
            ViewBag.idUsuario = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO");
            return View();
        }

        // POST: MovimientoBancoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdBanco,Fecha_movimiento,Detalle,idTipoMovimientoBanco,idUsuario,IdEmpresa,IdSucursal,IdMoneda")] MovimientoBanco movimientoBanco)
        {
            if (ModelState.IsValid)
            {
                db.MovimientoBancoes.Add(movimientoBanco);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", movimientoBanco.IdEmpresa);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", movimientoBanco.IdSucursal);
            ViewBag.idUsuario = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", movimientoBanco.idUsuario);
            return View(movimientoBanco);
        }

        // GET: MovimientoBancoes/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimientoBanco movimientoBanco = await db.MovimientoBancoes.FindAsync(id);
            if (movimientoBanco == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", movimientoBanco.IdEmpresa);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", movimientoBanco.IdSucursal);
            ViewBag.idUsuario = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", movimientoBanco.idUsuario);
            return View(movimientoBanco);
        }

        // POST: MovimientoBancoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdBanco,Fecha_movimiento,Detalle,idTipoMovimientoBanco,idUsuario,IdEmpresa,IdSucursal,IdMoneda")] MovimientoBanco movimientoBanco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimientoBanco).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", movimientoBanco.IdEmpresa);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", movimientoBanco.IdSucursal);
            ViewBag.idUsuario = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", movimientoBanco.idUsuario);
            return View(movimientoBanco);
        }

        // GET: MovimientoBancoes/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimientoBanco movimientoBanco = await db.MovimientoBancoes.FindAsync(id);
            if (movimientoBanco == null)
            {
                return HttpNotFound();
            }
            return View(movimientoBanco);
        }

        // POST: MovimientoBancoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            MovimientoBanco movimientoBanco = await db.MovimientoBancoes.FindAsync(id);
            db.MovimientoBancoes.Remove(movimientoBanco);
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
