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
    public class Billetes_MonedaController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: Billetes_Moneda
        public async Task<ActionResult> Index()
        {
            return View(await db.Billetes_Moneda.ToListAsync());
        }

        // GET: Billetes_Moneda/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billetes_Moneda billetes_Moneda = await db.Billetes_Moneda.FindAsync(id);
            if (billetes_Moneda == null)
            {
                return HttpNotFound();
            }
            return View(billetes_Moneda);
        }

        // GET: Billetes_Moneda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Billetes_Moneda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,descripcion,idMoneda,numeroOrden,idEmpresa")] Billetes_Moneda billetes_Moneda)
        {
            if (ModelState.IsValid)
            {
                db.Billetes_Moneda.Add(billetes_Moneda);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(billetes_Moneda);
        }

        // GET: Billetes_Moneda/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billetes_Moneda billetes_Moneda = await db.Billetes_Moneda.FindAsync(id);
            if (billetes_Moneda == null)
            {
                return HttpNotFound();
            }
            return View(billetes_Moneda);
        }

        // POST: Billetes_Moneda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,descripcion,idMoneda,numeroOrden,idEmpresa")] Billetes_Moneda billetes_Moneda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billetes_Moneda).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(billetes_Moneda);
        }

        // GET: Billetes_Moneda/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billetes_Moneda billetes_Moneda = await db.Billetes_Moneda.FindAsync(id);
            if (billetes_Moneda == null)
            {
                return HttpNotFound();
            }
            return View(billetes_Moneda);
        }

        // POST: Billetes_Moneda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Billetes_Moneda billetes_Moneda = await db.Billetes_Moneda.FindAsync(id);
            db.Billetes_Moneda.Remove(billetes_Moneda);
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
