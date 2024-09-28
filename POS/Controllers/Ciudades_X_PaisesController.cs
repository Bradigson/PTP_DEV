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
    public class Ciudades_X_PaisesController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: Ciudades_X_Paises
        public async Task<ActionResult> Index()
        {
            return View(await db.Ciudades_X_Paises.ToListAsync());
        }

        // GET: Ciudades_X_Paises/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades_X_Paises ciudades_X_Paises = await db.Ciudades_X_Paises.FindAsync(id);
            if (ciudades_X_Paises == null)
            {
                return HttpNotFound();
            }
            return View(ciudades_X_Paises);
        }

        // GET: Ciudades_X_Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudades_X_Paises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Cod_ciudades,Cod_Empresa,Cod_pais,Descripcion,Cod_Usuario,Cod_Usuario_Modificacion,Fecha_adicion,Fecha_modificacion,Estado")] Ciudades_X_Paises ciudades_X_Paises)
        {
            if (ModelState.IsValid)
            {
                db.Ciudades_X_Paises.Add(ciudades_X_Paises);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ciudades_X_Paises);
        }

        // GET: Ciudades_X_Paises/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades_X_Paises ciudades_X_Paises = await db.Ciudades_X_Paises.FindAsync(id);
            if (ciudades_X_Paises == null)
            {
                return HttpNotFound();
            }
            return View(ciudades_X_Paises);
        }

        // POST: Ciudades_X_Paises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Cod_ciudades,Cod_Empresa,Cod_pais,Descripcion,Cod_Usuario,Cod_Usuario_Modificacion,Fecha_adicion,Fecha_modificacion,Estado")] Ciudades_X_Paises ciudades_X_Paises)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudades_X_Paises).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ciudades_X_Paises);
        }

        // GET: Ciudades_X_Paises/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades_X_Paises ciudades_X_Paises = await db.Ciudades_X_Paises.FindAsync(id);
            if (ciudades_X_Paises == null)
            {
                return HttpNotFound();
            }
            return View(ciudades_X_Paises);
        }

        // POST: Ciudades_X_Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ciudades_X_Paises ciudades_X_Paises = await db.Ciudades_X_Paises.FindAsync(id);
            db.Ciudades_X_Paises.Remove(ciudades_X_Paises);
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
