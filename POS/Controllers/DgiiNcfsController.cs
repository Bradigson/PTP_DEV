using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.Models;
using DataLayer.PDbContex;

namespace POS.Controllers
{
    public class DgiiNcfsController : Controller
    {
        private PDbContext db = new PDbContext();

        private readonly DgiiNcfService _dgii;

        public DgiiNcfsController()
        {
            _dgii= new DgiiNcfService();
        }
        // GET: DgiiNcfs
        public async Task<ActionResult> Index()
        {
            return View(await db.DgiiNcf.ToListAsync());
        }

        // GET: DgiiNcfs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DgiiNcf dgiiNcf = await db.DgiiNcf.FindAsync(id);
            if (dgiiNcf == null)
            {
                return HttpNotFound();
            }
            return View(dgiiNcf);
        }

        // GET: DgiiNcfs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DgiiNcfs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DgiiNcf dgiiNcf)
        {
            dgiiNcf.Descripcion = "0";
            //if (ModelState.IsValid)
            //{

                await _dgii.Add(dgiiNcf);

                return RedirectToAction("Index");
            //}

            //return View(dgiiNcf);
        }

        // GET: DgiiNcfs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DgiiNcf dgiiNcf = await db.DgiiNcf.FindAsync(id);
            if (dgiiNcf == null)
            {
                return HttpNotFound();
            }
            return View(dgiiNcf);
        }

        // POST: DgiiNcfs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Serie,TipoComprobante,SecuencialInicial,SecuenciaDgii,FechaVencimiento,usuario,usuarioUltimaModificacion,FechaModificacion,FechaCreacion,Borrado")] DgiiNcf dgiiNcf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dgiiNcf).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dgiiNcf);
        }

        // GET: DgiiNcfs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DgiiNcf dgiiNcf = await db.DgiiNcf.FindAsync(id);
            if (dgiiNcf == null)
            {
                return HttpNotFound();
            }
            return View(dgiiNcf);
        }

        // POST: DgiiNcfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DgiiNcf dgiiNcf = await db.DgiiNcf.FindAsync(id);
            db.DgiiNcf.Remove(dgiiNcf);
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




        public async Task<ActionResult> GetSeqNcfByTipo(int tipoNcf)
        {
            var klk= await _dgii.GetSeqNcfByTipoNcf(tipoNcf);

            return View();
        }
    }
}
