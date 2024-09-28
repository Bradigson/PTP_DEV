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
    public class BovedaCajaDesglosesController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: BovedaCajaDesgloses
        public async Task<ActionResult> Index()
        {
            return View(await db.BovedaCajaDesgloses.ToListAsync());
        }

        // GET: BovedaCajaDesgloses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BovedaCajaDesglose bovedaCajaDesglose = await db.BovedaCajaDesgloses.FindAsync(id);
            if (bovedaCajaDesglose == null)
            {
                return HttpNotFound();
            }
            return View(bovedaCajaDesglose);
        }

        // GET: BovedaCajaDesgloses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BovedaCajaDesgloses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,idBoveda,idIdmoneda,idbilletes_moneda,Cantidad,idEmpresa,IdSucursal")] BovedaCajaDesglose bovedaCajaDesglose)
        {
            if (ModelState.IsValid)
            {
                db.BovedaCajaDesgloses.Add(bovedaCajaDesglose);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bovedaCajaDesglose);
        }

        // GET: BovedaCajaDesgloses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BovedaCajaDesglose bovedaCajaDesglose = await db.BovedaCajaDesgloses.FindAsync(id);
            if (bovedaCajaDesglose == null)
            {
                return HttpNotFound();
            }
            return View(bovedaCajaDesglose);
        }

        // POST: BovedaCajaDesgloses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,idBoveda,idIdmoneda,idbilletes_moneda,Cantidad,idEmpresa,IdSucursal")] BovedaCajaDesglose bovedaCajaDesglose)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bovedaCajaDesglose).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bovedaCajaDesglose);
        }

        // GET: BovedaCajaDesgloses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BovedaCajaDesglose bovedaCajaDesglose = await db.BovedaCajaDesgloses.FindAsync(id);
            if (bovedaCajaDesglose == null)
            {
                return HttpNotFound();
            }
            return View(bovedaCajaDesglose);
        }

        // POST: BovedaCajaDesgloses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BovedaCajaDesglose bovedaCajaDesglose = await db.BovedaCajaDesgloses.FindAsync(id);
            db.BovedaCajaDesgloses.Remove(bovedaCajaDesglose);
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
