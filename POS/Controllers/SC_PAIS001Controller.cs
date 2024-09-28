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
    public class SC_PAIS001Controller : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: SC_PAIS001
        public async Task<ActionResult> Index()
        {
            return View(await db.SC_PAIS001.ToListAsync());
        }

        // GET: SC_PAIS001/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_PAIS001 sC_PAIS001 = await db.SC_PAIS001.FindAsync(id);
            if (sC_PAIS001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_PAIS001);
        }

        // GET: SC_PAIS001/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SC_PAIS001/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO_PAIS,NOMBRE_PAIS,COD_ISO_2,COD_ISO_3,COD_ISO_NUMERICO,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_PAIS001 sC_PAIS001)
        {
            if (ModelState.IsValid)
            {
                sC_PAIS001.FECHA_ADICION = DateTime.Now;
                sC_PAIS001.FECHA_MODIFICACION = DateTime.Now;
                sC_PAIS001.USUARIO_ADICCION = int.Parse(Session["ID"].ToString());
                sC_PAIS001.USUARIO_MODIFICACION = int.Parse(Session["ID"].ToString());
                sC_PAIS001.IP_ADICCION = "0";
                sC_PAIS001.IP_MODIFICACION = "0";
                db.SC_PAIS001.Add(sC_PAIS001);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sC_PAIS001);
        }

        // GET: SC_PAIS001/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_PAIS001 sC_PAIS001 = await db.SC_PAIS001.FindAsync(id);
            if (sC_PAIS001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_PAIS001);
        }

        // POST: SC_PAIS001/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO_PAIS,NOMBRE_PAIS,COD_ISO_2,COD_ISO_3,COD_ISO_NUMERICO,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_PAIS001 sC_PAIS001)
        {
            if (ModelState.IsValid)
            {
                
                sC_PAIS001.FECHA_MODIFICACION = DateTime.Now;
              
                sC_PAIS001.USUARIO_MODIFICACION = int.Parse(Session["ID"].ToString());
                
                sC_PAIS001.IP_MODIFICACION = "0";
                db.Entry(sC_PAIS001).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sC_PAIS001);
        }

        // GET: SC_PAIS001/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_PAIS001 sC_PAIS001 = await db.SC_PAIS001.FindAsync(id);
            if (sC_PAIS001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_PAIS001);
        }

        // POST: SC_PAIS001/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SC_PAIS001 sC_PAIS001 = await db.SC_PAIS001.FindAsync(id);
            db.SC_PAIS001.Remove(sC_PAIS001);
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
