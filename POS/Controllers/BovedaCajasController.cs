using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models.Caja;
using DataLayer.PDbContex;

namespace POS.Controllers
{
    public class BovedaCajasController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: BovedaCajas
        public async Task<ActionResult> Index()
        {
            return View(await db.BovedaCajas.ToListAsync());
        }

        // GET: BovedaCajas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BovedaCaja bovedaCaja = await db.BovedaCajas.FindAsync(id);
            if (bovedaCaja == null)
            {
                return HttpNotFound();
            }
            return View(bovedaCaja);
        }

        // GET: BovedaCajas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BovedaCajas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Descripcion,idMoneda,FechaCreacion,UsuarioIDCrea,FechaActualizacion,UsuarioIDActualiza,idEmpresa,IdSucursal,idUsuarioResposable,idUsuarioModifica")] BovedaCaja bovedaCaja)
        {
            if (ModelState.IsValid)
            {
                db.BovedaCajas.Add(bovedaCaja);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bovedaCaja);
        }

        // GET: BovedaCajas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BovedaCaja bovedaCaja = await db.BovedaCajas.FindAsync(id);
            if (bovedaCaja == null)
            {
                return HttpNotFound();
            }
            return View(bovedaCaja);
        }

        // POST: BovedaCajas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Descripcion,idMoneda,FechaCreacion,UsuarioIDCrea,FechaActualizacion,UsuarioIDActualiza,idEmpresa,IdSucursal,idUsuarioResposable,idUsuarioModifica")] BovedaCaja bovedaCaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bovedaCaja).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bovedaCaja);
        }

        // GET: BovedaCajas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BovedaCaja bovedaCaja = await db.BovedaCajas.FindAsync(id);
            if (bovedaCaja == null)
            {
                return HttpNotFound();
            }
            return View(bovedaCaja);
        }

        // POST: BovedaCajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BovedaCaja bovedaCaja = await db.BovedaCajas.FindAsync(id);
            db.BovedaCajas.Remove(bovedaCaja);
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
