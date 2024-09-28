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
    public class SC_IMP001Controller : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: SC_IMP001
        public async Task<ActionResult> Index()
        {
            var sC_IMP001 = db.SC_IMP001.Include(s => s.SC_EMP001);
            return View(await sC_IMP001.ToListAsync());
        }

        // GET: SC_IMP001/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_IMP001 sC_IMP001 = await db.SC_IMP001.FindAsync(id);
            if (sC_IMP001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_IMP001);
        }

        // GET: SC_IMP001/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP");
            return View();
        }

        // POST: SC_IMP001/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO_IMP,CODIGO_EMP,PORCENTAJE,VALOR_FIJO,DESCRIPCION,BORRAR,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_IMP001 sC_IMP001)
        {
            if (ModelState.IsValid)
            {
                db.SC_IMP001.Add(sC_IMP001);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_IMP001.CODIGO_EMP);
            return View(sC_IMP001);
        }

        // GET: SC_IMP001/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_IMP001 sC_IMP001 = await db.SC_IMP001.FindAsync(id);
            if (sC_IMP001 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_IMP001.CODIGO_EMP);
            return View(sC_IMP001);
        }

        // POST: SC_IMP001/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO_IMP,CODIGO_EMP,PORCENTAJE,VALOR_FIJO,DESCRIPCION,BORRAR,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_IMP001 sC_IMP001)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sC_IMP001).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_IMP001.CODIGO_EMP);
            return View(sC_IMP001);
        }

        // GET: SC_IMP001/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_IMP001 sC_IMP001 = await db.SC_IMP001.FindAsync(id);
            if (sC_IMP001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_IMP001);
        }

        // POST: SC_IMP001/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SC_IMP001 sC_IMP001 = await db.SC_IMP001.FindAsync(id);
            db.SC_IMP001.Remove(sC_IMP001);
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
