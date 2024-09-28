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
    public class SC_HORAGROUP002Controller : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: SC_HORAGROUP002
        public async Task<ActionResult> Index()
        {
            var sC_HORAGROUP002 = db.SC_HORAGROUP002.Include(s => s.SC_EMP001);
            return View(await sC_HORAGROUP002.ToListAsync());
        }

        // GET: SC_HORAGROUP002/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_HORAGROUP002 sC_HORAGROUP002 = await db.SC_HORAGROUP002.FindAsync(id);
            if (sC_HORAGROUP002 == null)
            {
                return HttpNotFound();
            }
            return View(sC_HORAGROUP002);
        }

        // GET: SC_HORAGROUP002/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP");
            return View();
        }

        // POST: SC_HORAGROUP002/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO_HRRGROUP,CODIGO_EMP,CODIGO_HRR_1,CODIGO_HRR_2,CODIGO_HRR_3,CODIGO_HRR_4,CODIGO_HRR_5,CODIGO_HRR_6,CODIGO_HRR_7,BORRAR,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION")] SC_HORAGROUP002 sC_HORAGROUP002)
        {
            if (ModelState.IsValid)
            {
                db.SC_HORAGROUP002.Add(sC_HORAGROUP002);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_HORAGROUP002.CODIGO_EMP);
            return View(sC_HORAGROUP002);
        }

        // GET: SC_HORAGROUP002/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_HORAGROUP002 sC_HORAGROUP002 = await db.SC_HORAGROUP002.FindAsync(id);
            if (sC_HORAGROUP002 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_HORAGROUP002.CODIGO_EMP);
            return View(sC_HORAGROUP002);
        }

        // POST: SC_HORAGROUP002/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO_HRRGROUP,CODIGO_EMP,CODIGO_HRR_1,CODIGO_HRR_2,CODIGO_HRR_3,CODIGO_HRR_4,CODIGO_HRR_5,CODIGO_HRR_6,CODIGO_HRR_7,BORRAR,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION")] SC_HORAGROUP002 sC_HORAGROUP002)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sC_HORAGROUP002).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_EMP = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", sC_HORAGROUP002.CODIGO_EMP);
            return View(sC_HORAGROUP002);
        }

        // GET: SC_HORAGROUP002/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_HORAGROUP002 sC_HORAGROUP002 = await db.SC_HORAGROUP002.FindAsync(id);
            if (sC_HORAGROUP002 == null)
            {
                return HttpNotFound();
            }
            return View(sC_HORAGROUP002);
        }

        // POST: SC_HORAGROUP002/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SC_HORAGROUP002 sC_HORAGROUP002 = await db.SC_HORAGROUP002.FindAsync(id);
            db.SC_HORAGROUP002.Remove(sC_HORAGROUP002);
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
