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
    public class SC_IPSYS001Controller : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: SC_IPSYS001
        public async Task<ActionResult> Index()
        {
            var sC_IPSYS001 = db.SC_IPSYS001.Include(s => s.SC_USUAR001);
            return View(await sC_IPSYS001.ToListAsync());
        }

        // GET: SC_IPSYS001/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_IPSYS001 sC_IPSYS001 = await db.SC_IPSYS001.FindAsync(id);
            if (sC_IPSYS001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_IPSYS001);
        }

        // GET: SC_IPSYS001/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_USUARIO = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO");
            return View();
        }

        // POST: SC_IPSYS001/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO_IPSYS,IP,CODIGO_USUARIO,ID_USUARIO_ADICION,IP_ADICCION,FECHA_ADICION,ID_USUARIO_MODIFICACION,IP_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_IPSYS001 sC_IPSYS001)
        {
            if (ModelState.IsValid)
            {
                db.SC_IPSYS001.Add(sC_IPSYS001);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_USUARIO = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", sC_IPSYS001.CODIGO_USUARIO);
            return View(sC_IPSYS001);
        }

        // GET: SC_IPSYS001/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_IPSYS001 sC_IPSYS001 = await db.SC_IPSYS001.FindAsync(id);
            if (sC_IPSYS001 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_USUARIO = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", sC_IPSYS001.CODIGO_USUARIO);
            return View(sC_IPSYS001);
        }

        // POST: SC_IPSYS001/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO_IPSYS,IP,CODIGO_USUARIO,ID_USUARIO_ADICION,IP_ADICCION,FECHA_ADICION,ID_USUARIO_MODIFICACION,IP_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_IPSYS001 sC_IPSYS001)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sC_IPSYS001).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_USUARIO = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", sC_IPSYS001.CODIGO_USUARIO);
            return View(sC_IPSYS001);
        }

        // GET: SC_IPSYS001/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_IPSYS001 sC_IPSYS001 = await db.SC_IPSYS001.FindAsync(id);
            if (sC_IPSYS001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_IPSYS001);
        }

        // POST: SC_IPSYS001/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SC_IPSYS001 sC_IPSYS001 = await db.SC_IPSYS001.FindAsync(id);
            db.SC_IPSYS001.Remove(sC_IPSYS001);
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
