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
    public class BovedaMovimientoesController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: BovedaMovimientoes
        public async Task<ActionResult> Index()
        {
            return View(await db.BovedaMovimientoes.ToListAsync());
        }

        // GET: BovedaMovimientoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BovedaMovimiento bovedaMovimiento = await db.BovedaMovimientoes.FindAsync(id);
            if (bovedaMovimiento == null)
            {
                return HttpNotFound();
            }
            return View(bovedaMovimiento);
        }

        // GET: BovedaMovimientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BovedaMovimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,idMoneda,idTipoOperacionBoveda,Descripcion,Entrada_Salida,idDesgloseXcajero,FechaCreacion,UsuarioIDCrea,FechaActualizacion,UsuarioIDActualiza,idEmpresa,IdSucursal")] BovedaMovimiento bovedaMovimiento)
        {
            if (ModelState.IsValid)
            {
                db.BovedaMovimientoes.Add(bovedaMovimiento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bovedaMovimiento);
        }

        // GET: BovedaMovimientoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BovedaMovimiento bovedaMovimiento = await db.BovedaMovimientoes.FindAsync(id);
            if (bovedaMovimiento == null)
            {
                return HttpNotFound();
            }
            return View(bovedaMovimiento);
        }

        // POST: BovedaMovimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,idMoneda,idTipoOperacionBoveda,Descripcion,Entrada_Salida,idDesgloseXcajero,FechaCreacion,UsuarioIDCrea,FechaActualizacion,UsuarioIDActualiza,idEmpresa,IdSucursal")] BovedaMovimiento bovedaMovimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bovedaMovimiento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bovedaMovimiento);
        }

        // GET: BovedaMovimientoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BovedaMovimiento bovedaMovimiento = await db.BovedaMovimientoes.FindAsync(id);
            if (bovedaMovimiento == null)
            {
                return HttpNotFound();
            }
            return View(bovedaMovimiento);
        }

        // POST: BovedaMovimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BovedaMovimiento bovedaMovimiento = await db.BovedaMovimientoes.FindAsync(id);
            db.BovedaMovimientoes.Remove(bovedaMovimiento);
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
