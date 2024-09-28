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
    public class SC_MUNIC001Controller : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: SC_MUNIC001
        public async Task<ActionResult> Index()
        {
            var sC_MUNIC001 = db.SC_MUNIC001.Include(s => s.SC_PROV001);
            return View(await sC_MUNIC001.ToListAsync());
        }

        // GET: SC_MUNIC001/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_MUNIC001 sC_MUNIC001 = await db.SC_MUNIC001.FindAsync(id);
            if (sC_MUNIC001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_MUNIC001);
        }

        // GET: SC_MUNIC001/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_PROV = new SelectList(db.SC_PROV001, "CODIGO_PROV", "NOMBRE_PROV");
            return View();
        }

        // POST: SC_MUNIC001/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO_MUNIC,NOMBRE_MUNIC,CODIGO_PROV,ID_USUARIO_ADICCION,IP_ADICCION,FECHA_ADICION,ID_USUARIO_MODIFICACION,IP_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_MUNIC001 sC_MUNIC001)
        {
            if (ModelState.IsValid)
            {
                sC_MUNIC001.FECHA_ADICION = DateTime.Now;
                sC_MUNIC001.FECHA_MODIFICACION= DateTime.Now;
                sC_MUNIC001.ID_USUARIO_ADICCION =int.Parse(Session["ID"].ToString());
                sC_MUNIC001.ID_USUARIO_MODIFICACION= int.Parse(Session["ID"].ToString());
                sC_MUNIC001.IP_ADICCION= 0;
                sC_MUNIC001.IP_MODIFICACION = 0; 


                db.SC_MUNIC001.Add(sC_MUNIC001);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_PROV = new SelectList(db.SC_PROV001, "CODIGO_PROV", "NOMBRE_PROV", sC_MUNIC001.CODIGO_PROV);
            return View(sC_MUNIC001);
        }

        // GET: SC_MUNIC001/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_MUNIC001 sC_MUNIC001 = await db.SC_MUNIC001.FindAsync(id);
            if (sC_MUNIC001 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_PROV = new SelectList(db.SC_PROV001, "CODIGO_PROV", "NOMBRE_PROV", sC_MUNIC001.CODIGO_PROV);
            return View(sC_MUNIC001);
        }

        // POST: SC_MUNIC001/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO_MUNIC,NOMBRE_MUNIC,CODIGO_PROV,ID_USUARIO_ADICCION,IP_ADICCION,FECHA_ADICION,ID_USUARIO_MODIFICACION,IP_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_MUNIC001 sC_MUNIC001)
        {
            if (ModelState.IsValid)
            {
                
                sC_MUNIC001.FECHA_MODIFICACION = DateTime.Now;                
                sC_MUNIC001.ID_USUARIO_MODIFICACION = 0;               
                sC_MUNIC001.IP_MODIFICACION = 0;

                db.Entry(sC_MUNIC001).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_PROV = new SelectList(db.SC_PROV001, "CODIGO_PROV", "NOMBRE_PROV", sC_MUNIC001.CODIGO_PROV);
            return View(sC_MUNIC001);
        }

        // GET: SC_MUNIC001/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_MUNIC001 sC_MUNIC001 = await db.SC_MUNIC001.FindAsync(id);
            if (sC_MUNIC001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_MUNIC001);
        }

        // POST: SC_MUNIC001/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SC_MUNIC001 sC_MUNIC001 = await db.SC_MUNIC001.FindAsync(id);
            db.SC_MUNIC001.Remove(sC_MUNIC001);
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
