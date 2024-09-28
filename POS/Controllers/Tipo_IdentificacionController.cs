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
    public class Tipo_IdentificacionController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: Tipo_Identificacion
        public async Task<ActionResult> Index()
        {
            return View(await db.Tipo_Identificacion.ToListAsync());
        }

        // GET: Tipo_Identificacion/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Identificacion tipo_Identificacion = await db.Tipo_Identificacion.FindAsync(id);
            if (tipo_Identificacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Identificacion);
        }

        // GET: Tipo_Identificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Identificacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Cod_Tipo_Identificacion,Cod_Empresa,Descripcion,Cod_Usuario,Cod_Usuario_Modificacion,Fecha_adicion,Fecha_modificacion,Estado")] Tipo_Identificacion tipo_Identificacion)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Identificacion.Add(tipo_Identificacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipo_Identificacion);
        }

        // GET: Tipo_Identificacion/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Identificacion tipo_Identificacion = await db.Tipo_Identificacion.FindAsync(id);
            if (tipo_Identificacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Identificacion);
        }

        // POST: Tipo_Identificacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Cod_Tipo_Identificacion,Cod_Empresa,Descripcion,Cod_Usuario,Cod_Usuario_Modificacion,Fecha_adicion,Fecha_modificacion,Estado")] Tipo_Identificacion tipo_Identificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Identificacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipo_Identificacion);
        }

        // GET: Tipo_Identificacion/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Identificacion tipo_Identificacion = await db.Tipo_Identificacion.FindAsync(id);
            if (tipo_Identificacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Identificacion);
        }

        // POST: Tipo_Identificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tipo_Identificacion tipo_Identificacion = await db.Tipo_Identificacion.FindAsync(id);
            db.Tipo_Identificacion.Remove(tipo_Identificacion);
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
