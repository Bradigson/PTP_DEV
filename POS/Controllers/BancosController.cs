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
    public class BancosController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: Bancos
        public async Task<ActionResult> Index()
        {
            var bancos = db.Bancos.Include(b => b.empresa).Include(b => b.sucursal);
            return View(await bancos.ToListAsync());
        }

        // GET: Bancos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bancos bancos = await db.Bancos.FindAsync(id);
            if (bancos == null)
            {
                return HttpNotFound();
            }
            return View(bancos);
        }

        // GET: Bancos/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP");
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC");
            return View();
        }

        // POST: Bancos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Banco,FechaCreacion,idUsuarioCrea,FechaModificacion,Estado,IdEmpresa,IdSucursal")] Bancos bancos)
        {
            if (ModelState.IsValid)
            {
                db.Bancos.Add(bancos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", bancos.IdEmpresa);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", bancos.IdSucursal);
            return View(bancos);
        }

        // GET: Bancos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bancos bancos = await db.Bancos.FindAsync(id);
            if (bancos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", bancos.IdEmpresa);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", bancos.IdSucursal);
            return View(bancos);
        }

        // POST: Bancos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Banco,FechaCreacion,idUsuarioCrea,FechaModificacion,Estado,IdEmpresa,IdSucursal")] Bancos bancos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bancos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", bancos.IdEmpresa);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", bancos.IdSucursal);
            return View(bancos);
        }

        // GET: Bancos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bancos bancos = await db.Bancos.FindAsync(id);
            if (bancos == null)
            {
                return HttpNotFound();
            }
            return View(bancos);
        }

        // POST: Bancos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bancos bancos = await db.Bancos.FindAsync(id);
            db.Bancos.Remove(bancos);
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
