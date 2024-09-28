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
    public class CuentaBancosController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: CuentaBancos
        public async Task<ActionResult> Index()
        {
            var cuentaBancos = db.CuentaBancos.Include(c => c.banco).Include(c => c.empresa).Include(c => c.moneda).Include(c => c.sucursal);
            return View(await cuentaBancos.ToListAsync());
        }

        // GET: CuentaBancos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancos cuentaBancos = await db.CuentaBancos.FindAsync(id);
            if (cuentaBancos == null)
            {
                return HttpNotFound();
            }
            return View(cuentaBancos);
        }

        // GET: CuentaBancos/Create
        public ActionResult Create()
        {
            ViewBag.IdBanco = new SelectList(db.Bancos, "Id", "Banco");
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP");
            ViewBag.IdMoneda = new SelectList(db.Monedas, "id", "descripcion");
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC");
            return View();
        }

        // POST: CuentaBancos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdBanco,IdMoneda,NombreCuenta,NumeroCuenta,FechaCreacion,idUsuarioCrea,FechaModificacion,Estado,IdEmpresa,IdSucursal")] CuentaBancos cuentaBancos)
        {
            if (ModelState.IsValid)
            {
                db.CuentaBancos.Add(cuentaBancos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdBanco = new SelectList(db.Bancos, "Id", "Banco", cuentaBancos.IdBanco);
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", cuentaBancos.IdEmpresa);
            ViewBag.IdMoneda = new SelectList(db.Monedas, "id", "descripcion", cuentaBancos.IdMoneda);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", cuentaBancos.IdSucursal);
            return View(cuentaBancos);
        }

        // GET: CuentaBancos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancos cuentaBancos = await db.CuentaBancos.FindAsync(id);
            if (cuentaBancos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBanco = new SelectList(db.Bancos, "Id", "Banco", cuentaBancos.IdBanco);
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", cuentaBancos.IdEmpresa);
            ViewBag.IdMoneda = new SelectList(db.Monedas, "id", "descripcion", cuentaBancos.IdMoneda);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", cuentaBancos.IdSucursal);
            return View(cuentaBancos);
        }

        // POST: CuentaBancos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdBanco,IdMoneda,NombreCuenta,NumeroCuenta,FechaCreacion,idUsuarioCrea,FechaModificacion,Estado,IdEmpresa,IdSucursal")] CuentaBancos cuentaBancos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentaBancos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdBanco = new SelectList(db.Bancos, "Id", "Banco", cuentaBancos.IdBanco);
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", cuentaBancos.IdEmpresa);
            ViewBag.IdMoneda = new SelectList(db.Monedas, "id", "descripcion", cuentaBancos.IdMoneda);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", cuentaBancos.IdSucursal);
            return View(cuentaBancos);
        }

        // GET: CuentaBancos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancos cuentaBancos = await db.CuentaBancos.FindAsync(id);
            if (cuentaBancos == null)
            {
                return HttpNotFound();
            }
            return View(cuentaBancos);
        }

        // POST: CuentaBancos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CuentaBancos cuentaBancos = await db.CuentaBancos.FindAsync(id);
            db.CuentaBancos.Remove(cuentaBancos);
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
