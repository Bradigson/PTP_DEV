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
    public class SC_REG001Controller : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: SC_REG001
        public async Task<ActionResult> Index()
        {
            var sC_REG001 = db.SC_REG001.Include(s => s.SC_PAIS001);
            return View(await sC_REG001.ToListAsync());
        }

        // GET: SC_REG001/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_REG001 sC_REG001 = await db.SC_REG001.FindAsync(id);
            if (sC_REG001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_REG001);
        }

        // GET: SC_REG001/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_PAIS = new SelectList(db.SC_PAIS001, "CODIGO_PAIS", "NOMBRE_PAIS");
            return View();
        }

        // POST: SC_REG001/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO_REG,NOMBRE_REG,CODIGO_PAIS,ID_USUARIO_ADICCION,IP_ADICCION,FECHA_ADICION,ID_USUARIO_MODIFICACION,IP_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_REG001 sC_REG001)
        {
            if (ModelState.IsValid)
            {
                sC_REG001.FECHA_ADICION = DateTime.Now;
                sC_REG001.FECHA_MODIFICACION = DateTime.Now;
                sC_REG001.ID_USUARIO_ADICCION = int.Parse(Session["ID"].ToString());
                sC_REG001.ID_USUARIO_MODIFICACION = int.Parse(Session["ID"].ToString());
                sC_REG001.IP_ADICCION = 0;
                sC_REG001.IP_MODIFICACION = 0;
                db.SC_REG001.Add(sC_REG001);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_PAIS = new SelectList(db.SC_PAIS001, "CODIGO_PAIS", "NOMBRE_PAIS", sC_REG001.CODIGO_PAIS);
            return View(sC_REG001);
        }

        // GET: SC_REG001/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_REG001 sC_REG001 = await db.SC_REG001.FindAsync(id);
            if (sC_REG001 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_PAIS = new SelectList(db.SC_PAIS001, "CODIGO_PAIS", "NOMBRE_PAIS", sC_REG001.CODIGO_PAIS);
            return View(sC_REG001);
        }

        // POST: SC_REG001/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO_REG,NOMBRE_REG,CODIGO_PAIS,ID_USUARIO_ADICCION,IP_ADICCION,FECHA_ADICION,ID_USUARIO_MODIFICACION,IP_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_REG001 sC_REG001)
        {
            if (ModelState.IsValid)
            {
                
                sC_REG001.FECHA_MODIFICACION = DateTime.Now;                
                sC_REG001.ID_USUARIO_MODIFICACION = int.Parse(Session["ID"].ToString());          
                sC_REG001.IP_MODIFICACION = 0;
                db.Entry(sC_REG001).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_PAIS = new SelectList(db.SC_PAIS001, "CODIGO_PAIS", "NOMBRE_PAIS", sC_REG001.CODIGO_PAIS);
            return View(sC_REG001);
        }

        // GET: SC_REG001/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_REG001 sC_REG001 = await db.SC_REG001.FindAsync(id);
            if (sC_REG001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_REG001);
        }

        // POST: SC_REG001/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SC_REG001 sC_REG001 = await db.SC_REG001.FindAsync(id);
            db.SC_REG001.Remove(sC_REG001);
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
