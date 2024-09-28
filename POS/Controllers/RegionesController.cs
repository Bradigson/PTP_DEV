using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.PDbContex;

namespace POS.Controllers
{
    public class RegionesController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: Regiones
        public async Task<ActionResult> Index()
        {
            var regiones = db.Regiones.Include(r => r.Pais);
            return View(await regiones.ToListAsync());
        }

        // GET: Regiones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = await db.Regiones.FindAsync(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // GET: Regiones/Create
        public ActionResult Create()
        {
            ViewBag.IdPais = new SelectList(db.Paises, "Id", "Nombre");
            return View();
        }

        // POST: Regiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,IdPais,FechaCreacion,Borrado")] Region region)
        {
            if (ModelState.IsValid)
            {
                db.Regiones.Add(region);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdPais = new SelectList(db.Paises, "Id", "Nombre", region.IdPais);
            return View(region);
        }

        // GET: Regiones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = await db.Regiones.FindAsync(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPais = new SelectList(db.Paises, "Id", "Nombre", region.IdPais);
            return View(region);
        }

        // POST: Regiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,IdPais,FechaCreacion,Borrado")] Region region)
        {
            if (ModelState.IsValid)
            {
                db.Entry(region).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdPais = new SelectList(db.Paises, "Id", "Nombre", region.IdPais);
            return View(region);
        }

        // GET: Regiones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = await db.Regiones.FindAsync(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Regiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Region region = await db.Regiones.FindAsync(id);
            db.Regiones.Remove(region);
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
