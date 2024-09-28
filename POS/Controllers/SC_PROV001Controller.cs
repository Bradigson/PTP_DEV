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
    public class SC_PROV001Controller : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: SC_PROV001
        public async Task<ActionResult> Index()
        {
            var sC_PROV001 = db.SC_PROV001.Include(s => s.SC_REG001);
            return View(await sC_PROV001.ToListAsync());
        }

        // GET: SC_PROV001/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_PROV001 sC_PROV001 = await db.SC_PROV001.FindAsync(id);
            if (sC_PROV001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_PROV001);
        }

        // GET: SC_PROV001/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_REG = new SelectList(db.SC_REG001, "CODIGO_REG", "NOMBRE_REG");
            return View();
        }

        // POST: SC_PROV001/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO_PROV,NOMBRE_PROV,CODIGO_REG,ID_USUARIO_ADICCION,IP_ADICCION,FECHA_ADICION,ID_USUARIO_MODIFICACION,IP_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_PROV001 sC_PROV001)
        {
            if (ModelState.IsValid)
            {
                sC_PROV001.FECHA_ADICION = DateTime.Now;
                sC_PROV001.FECHA_MODIFICACION = DateTime.Now;
                sC_PROV001.ID_USUARIO_ADICCION = int.Parse(Session["ID"].ToString());
                sC_PROV001.ID_USUARIO_MODIFICACION = int.Parse(Session["ID"].ToString());
                sC_PROV001.IP_ADICCION = 0;
                sC_PROV001.IP_MODIFICACION = 0;
                db.SC_PROV001.Add(sC_PROV001);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_REG = new SelectList(db.SC_REG001, "CODIGO_REG", "NOMBRE_REG", sC_PROV001.CODIGO_REG);
            return View(sC_PROV001);
        }

        // GET: SC_PROV001/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_PROV001 sC_PROV001 = await db.SC_PROV001.FindAsync(id);
            if (sC_PROV001 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_REG = new SelectList(db.SC_REG001, "CODIGO_REG", "NOMBRE_REG", sC_PROV001.CODIGO_REG);
            return View(sC_PROV001);
        }

        // POST: SC_PROV001/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO_PROV,NOMBRE_PROV,CODIGO_REG,ID_USUARIO_ADICCION,IP_ADICCION,FECHA_ADICION,ID_USUARIO_MODIFICACION,IP_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_PROV001 sC_PROV001)
        {
            if (ModelState.IsValid)
            {

            
                sC_PROV001.FECHA_MODIFICACION = DateTime.Now;               
                sC_PROV001.ID_USUARIO_MODIFICACION = int.Parse(Session["ID"].ToString());                
                sC_PROV001.IP_MODIFICACION = 0;
                db.Entry(sC_PROV001).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_REG = new SelectList(db.SC_REG001, "CODIGO_REG", "NOMBRE_REG", sC_PROV001.CODIGO_REG);
            return View(sC_PROV001);
        }

        // GET: SC_PROV001/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_PROV001 sC_PROV001 = await db.SC_PROV001.FindAsync(id);
            if (sC_PROV001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_PROV001);
        }

        // POST: SC_PROV001/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SC_PROV001 sC_PROV001 = await db.SC_PROV001.FindAsync(id);
            db.SC_PROV001.Remove(sC_PROV001);
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
