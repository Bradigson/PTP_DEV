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
    public class SC_HORA_X_USR002Controller : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: SC_HORA_X_USR002
        public async Task<ActionResult> Index()
        {
            var sC_HORA_X_USR002 = db.SC_HORA_X_USR002.Include(s => s.SC_EMP001);
            return View(await sC_HORA_X_USR002.ToListAsync());
        }

        // GET: SC_HORA_X_USR002/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_HORA_X_USR002 sC_HORA_X_USR002 = await db.SC_HORA_X_USR002.FindAsync(id);
            if (sC_HORA_X_USR002 == null)
            {
                return HttpNotFound();
            }
            return View(sC_HORA_X_USR002);
        }

        // GET: SC_HORA_X_USR002/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP");
            return View();
        }

        // POST: SC_HORA_X_USR002/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO_HRR,CODIGO_EMP,CODIGO_USUARIO,CODIGO_HRRUSR,MINUTOS_PRORROGA,BORRAR,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION")] SC_HORA_X_USR002 sC_HORA_X_USR002)
        {
            if (ModelState.IsValid)
            {
                db.SC_HORA_X_USR002.Add(sC_HORA_X_USR002);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_HORA_X_USR002.CODIGO_EMP);
            return View(sC_HORA_X_USR002);
        }

        // GET: SC_HORA_X_USR002/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_HORA_X_USR002 sC_HORA_X_USR002 = await db.SC_HORA_X_USR002.FindAsync(id);
            if (sC_HORA_X_USR002 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_HORA_X_USR002.CODIGO_EMP);
            return View(sC_HORA_X_USR002);
        }

        // POST: SC_HORA_X_USR002/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO_HRR,CODIGO_EMP,CODIGO_USUARIO,CODIGO_HRRUSR,MINUTOS_PRORROGA,BORRAR,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION")] SC_HORA_X_USR002 sC_HORA_X_USR002)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sC_HORA_X_USR002).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_HORA_X_USR002.CODIGO_EMP);
            return View(sC_HORA_X_USR002);
        }

        // GET: SC_HORA_X_USR002/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_HORA_X_USR002 sC_HORA_X_USR002 = await db.SC_HORA_X_USR002.FindAsync(id);
            if (sC_HORA_X_USR002 == null)
            {
                return HttpNotFound();
            }
            return View(sC_HORA_X_USR002);
        }

        // POST: SC_HORA_X_USR002/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SC_HORA_X_USR002 sC_HORA_X_USR002 = await db.SC_HORA_X_USR002.FindAsync(id);
            db.SC_HORA_X_USR002.Remove(sC_HORA_X_USR002);
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
