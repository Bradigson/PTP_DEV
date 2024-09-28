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
    public class ProvinciasController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: Provincias
        public async Task<ActionResult> Index()
        {
            var provincias = db.Provincias.Include(p => p.Region);
            return View(await provincias.ToListAsync());
        }

        // GET: Provincias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = await db.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            ViewBag.IdRegion = new SelectList(db.Regiones, "Id", "Nombre");
            return View();
        }

        // POST: Provincias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,IdRegion,FechaCreacion,Borrado")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Provincias.Add(provincia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdRegion = new SelectList(db.Regiones, "Id", "Nombre", provincia.IdRegion);
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = await db.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRegion = new SelectList(db.Regiones, "Id", "Nombre", provincia.IdRegion);
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,IdRegion,FechaCreacion,Borrado")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provincia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdRegion = new SelectList(db.Regiones, "Id", "Nombre", provincia.IdRegion);
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = await db.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Provincia provincia = await db.Provincias.FindAsync(id);
            db.Provincias.Remove(provincia);
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
