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
    public class ConciliacionTCTFsController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: ConciliacionTCTFs
        public async Task<ActionResult> Index()
        {
            var conciliacionTCTFs = db.ConciliacionTCTFs.Include(c => c.caja).Include(c => c.empresa).Include(c => c.facturacion).Include(c => c.moneda).Include(c => c.sucursal);
            return View(await conciliacionTCTFs.ToListAsync());
        }

        // GET: ConciliacionTCTFs/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConciliacionTCTF conciliacionTCTF = await db.ConciliacionTCTFs.FindAsync(id);
            if (conciliacionTCTF == null)
            {
                return HttpNotFound();
            }
            return View(conciliacionTCTF);
        }

        // GET: ConciliacionTCTFs/Create
        public ActionResult Create()
        {
            ViewBag.idCaja = new SelectList(db.Cajas, "Id", "NombreCaja");
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP");
            //ViewBag.idFactura = new SelectList(db.Facturacions, "Id", "NoFactura");
            ViewBag.idMoneda = new SelectList(db.Monedas, "id", "descripcion");
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC");
            return View();
        }

        // POST: ConciliacionTCTFs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,idCaja,idFactura,idMoneda,VTnoAuth,VT4digit,VTnoAuthEX,VT4digitEX,Conciliado,IdEmpresa,IdSucursal")] ConciliacionTCTF conciliacionTCTF)
        {
            if (ModelState.IsValid)
            {
                db.ConciliacionTCTFs.Add(conciliacionTCTF);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCaja = new SelectList(db.Cajas, "Id", "NombreCaja", conciliacionTCTF.idCaja);
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", conciliacionTCTF.IdEmpresa);
            ViewBag.idFactura = new SelectList(db.Facturacion, "Id", "NoFactura", conciliacionTCTF.idFactura);
            ViewBag.idMoneda = new SelectList(db.Monedas, "id", "descripcion", conciliacionTCTF.idMoneda);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", conciliacionTCTF.IdSucursal);
            return View(conciliacionTCTF);
        }

        // GET: ConciliacionTCTFs/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConciliacionTCTF conciliacionTCTF = await db.ConciliacionTCTFs.FindAsync(id);
            if (conciliacionTCTF == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCaja = new SelectList(db.Cajas, "Id", "NombreCaja", conciliacionTCTF.idCaja);
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", conciliacionTCTF.IdEmpresa);
            ViewBag.idFactura = new SelectList(db.Facturacion, "Id", "NoFactura", conciliacionTCTF.idFactura);
            ViewBag.idMoneda = new SelectList(db.Monedas, "id", "descripcion", conciliacionTCTF.idMoneda);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", conciliacionTCTF.IdSucursal);
            return View(conciliacionTCTF);
        }

        // POST: ConciliacionTCTFs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,idCaja,idFactura,idMoneda,VTnoAuth,VT4digit,VTnoAuthEX,VT4digitEX,Conciliado,IdEmpresa,IdSucursal")] ConciliacionTCTF conciliacionTCTF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conciliacionTCTF).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCaja = new SelectList(db.Cajas, "Id", "NombreCaja", conciliacionTCTF.idCaja);
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", conciliacionTCTF.IdEmpresa);
            ViewBag.idFactura = new SelectList(db.Facturacion, "Id", "NoFactura", conciliacionTCTF.idFactura);
            ViewBag.idMoneda = new SelectList(db.Monedas, "id", "descripcion", conciliacionTCTF.idMoneda);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", conciliacionTCTF.IdSucursal);
            return View(conciliacionTCTF);
        }

        // GET: ConciliacionTCTFs/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConciliacionTCTF conciliacionTCTF = await db.ConciliacionTCTFs.FindAsync(id);
            if (conciliacionTCTF == null)
            {
                return HttpNotFound();
            }
            return View(conciliacionTCTF);
        }

        // POST: ConciliacionTCTFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ConciliacionTCTF conciliacionTCTF = await db.ConciliacionTCTFs.FindAsync(id);
            db.ConciliacionTCTFs.Remove(conciliacionTCTF);
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
