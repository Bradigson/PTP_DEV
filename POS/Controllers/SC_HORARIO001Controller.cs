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
    public class SC_HORARIO001Controller : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: SC_HORARIO001
        public async Task<ActionResult> Index()
        {
            var sC_HORARIO001 = db.SC_HORARIO001.Include(s => s.SC_EMP001);
            return View(await sC_HORARIO001.ToListAsync());
        }

        // GET: SC_HORARIO001/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_HORARIO001 sC_HORARIO001 = await db.SC_HORARIO001.FindAsync(id);
            if (sC_HORARIO001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_HORARIO001);
        }

        // GET: SC_HORARIO001/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP");
            return View();
        }

        // POST: SC_HORARIO001/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO_HRR,CODIGO_EMP,DIA,BORRAR,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION")] SC_HORARIO001 sC_HORARIO001)
        {
            if (ModelState.IsValid)
            {
                db.SC_HORARIO001.Add(sC_HORARIO001);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_HORARIO001.CODIGO_EMP);
            return View(sC_HORARIO001);
        }

        // GET: SC_HORARIO001/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_HORARIO001 sC_HORARIO001 = await db.SC_HORARIO001.FindAsync(id);
            if (sC_HORARIO001 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_HORARIO001.CODIGO_EMP);
            return View(sC_HORARIO001);
        }

        // POST: SC_HORARIO001/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO_HRR,CODIGO_EMP,DIA,BORRAR,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION")] SC_HORARIO001 sC_HORARIO001)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sC_HORARIO001).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_HORARIO001.CODIGO_EMP);
            return View(sC_HORARIO001);
        }

        // GET: SC_HORARIO001/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_HORARIO001 sC_HORARIO001 = await db.SC_HORARIO001.FindAsync(id);
            if (sC_HORARIO001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_HORARIO001);
        }

        // POST: SC_HORARIO001/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SC_HORARIO001 sC_HORARIO001 = await db.SC_HORARIO001.FindAsync(id);
            db.SC_HORARIO001.Remove(sC_HORARIO001);
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
