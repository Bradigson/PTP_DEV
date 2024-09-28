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
    public class CajasController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: Cajas
        public async Task<ActionResult> Index()
        {
            return View(await db.Cajas.ToListAsync());
        }

        // GET: Cajas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caja caja = await db.Cajas.FindAsync(id);
            if (caja == null)
            {
                return HttpNotFound();
            }
            return View(caja);
        }

        // GET: Cajas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cajas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,numeroCaja,NombreCaja,idUsuarioResposable,UsuarioIDCrea,FechaActualizacion,UsuarioIDActualiza,EstadoCaja,idEmpresa,IdSucursal,FechaUltimoCierre")] Caja caja)
        {
            if (ModelState.IsValid)
            {
                db.Cajas.Add(caja);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(caja);
        }

        // GET: Cajas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caja caja = await db.Cajas.FindAsync(id);
            if (caja == null)
            {
                return HttpNotFound();
            }
            return View(caja);
        }

        // POST: Cajas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,numeroCaja,NombreCaja,idUsuarioResposable,UsuarioIDCrea,FechaActualizacion,UsuarioIDActualiza,EstadoCaja,idEmpresa,IdSucursal,FechaUltimoCierre")] Caja caja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caja).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(caja);
        }

        // GET: Cajas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caja caja = await db.Cajas.FindAsync(id);
            if (caja == null)
            {
                return HttpNotFound();
            }
            return View(caja);
        }

        // POST: Cajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Caja caja = await db.Cajas.FindAsync(id);
            db.Cajas.Remove(caja);
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
