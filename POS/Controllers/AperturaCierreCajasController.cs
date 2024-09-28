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
    public class AperturaCierreCajasController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: AperturaCierreCajas
        public async Task<ActionResult> Index()
        {
            var aperturaCierreCajas = db.AperturaCierreCajas.Include(a => a.caja).Include(a => a.empresa).Include(a => a.sucursal).Include(a => a.usuarioConfirmaCierreA).Include(a => a.usuarioConfirmaTF).Include(a => a.usuarioRespCaja);
            return View(await aperturaCierreCajas.ToListAsync());
        }

        // GET: AperturaCierreCajas/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AperturaCierreCaja aperturaCierreCaja = await db.AperturaCierreCajas.FindAsync(id);
            if (aperturaCierreCaja == null)
            {
                return HttpNotFound();
            }
            return View(aperturaCierreCaja);
        }

        // GET: AperturaCierreCajas/Create
        public ActionResult Create()
        {
            ViewBag.idCaja = new SelectList(db.Cajas, "Id", "NombreCaja");
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP");
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC");
            ViewBag.idUsuarioConfirmaCO = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO");
            ViewBag.idUsuarioConfirmaTjoTF = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO");
            ViewBag.idUsuarioReponCaja = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO");
            return View();
        }

        // POST: AperturaCierreCajas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Fecha_apertura,AperturCierre,idCaja,DeclaroFatante,IdMoneda,idUsuarioReponCaja,totalOperacionesEfectivo,totalOperacionesTajeta,ConciliadoAlCuadre,idUsuarioConfirmaCO,ConciliarTJoTransaferencia,idUsuarioConfirmaTjoTF,idConciliacion,FechaCoinciliacionTJoTF,IdEmpresa,IdSucursal")] AperturaCierreCaja aperturaCierreCaja)
        {
            if (ModelState.IsValid)
            {
                db.AperturaCierreCajas.Add(aperturaCierreCaja);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCaja = new SelectList(db.Cajas, "Id", "NombreCaja", aperturaCierreCaja.idCaja);
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", aperturaCierreCaja.IdEmpresa);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", aperturaCierreCaja.IdSucursal);
            ViewBag.idUsuarioConfirmaCO = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", aperturaCierreCaja.idUsuarioConfirmaCO);
            ViewBag.idUsuarioConfirmaTjoTF = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", aperturaCierreCaja.idUsuarioConfirmaTjoTF);
            ViewBag.idUsuarioReponCaja = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", aperturaCierreCaja.idUsuarioReponCaja);
            return View(aperturaCierreCaja);
        }

        // GET: AperturaCierreCajas/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AperturaCierreCaja aperturaCierreCaja = await db.AperturaCierreCajas.FindAsync(id);
            if (aperturaCierreCaja == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCaja = new SelectList(db.Cajas, "Id", "NombreCaja", aperturaCierreCaja.idCaja);
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", aperturaCierreCaja.IdEmpresa);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", aperturaCierreCaja.IdSucursal);
            ViewBag.idUsuarioConfirmaCO = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", aperturaCierreCaja.idUsuarioConfirmaCO);
            ViewBag.idUsuarioConfirmaTjoTF = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", aperturaCierreCaja.idUsuarioConfirmaTjoTF);
            ViewBag.idUsuarioReponCaja = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", aperturaCierreCaja.idUsuarioReponCaja);
            return View(aperturaCierreCaja);
        }

        // POST: AperturaCierreCajas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Fecha_apertura,AperturCierre,idCaja,DeclaroFatante,IdMoneda,idUsuarioReponCaja,totalOperacionesEfectivo,totalOperacionesTajeta,ConciliadoAlCuadre,idUsuarioConfirmaCO,ConciliarTJoTransaferencia,idUsuarioConfirmaTjoTF,idConciliacion,FechaCoinciliacionTJoTF,IdEmpresa,IdSucursal")] AperturaCierreCaja aperturaCierreCaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aperturaCierreCaja).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCaja = new SelectList(db.Cajas, "Id", "NombreCaja", aperturaCierreCaja.idCaja);
            ViewBag.IdEmpresa = new SelectList(db.SC_EMP001, "CODIGO_EMP", "NOMBRE_EMP", aperturaCierreCaja.IdEmpresa);
            ViewBag.IdSucursal = new SelectList(db.SC_SUC001, "CODIGO_SUC", "NOMBRE_SUC", aperturaCierreCaja.IdSucursal);
            ViewBag.idUsuarioConfirmaCO = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", aperturaCierreCaja.idUsuarioConfirmaCO);
            ViewBag.idUsuarioConfirmaTjoTF = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", aperturaCierreCaja.idUsuarioConfirmaTjoTF);
            ViewBag.idUsuarioReponCaja = new SelectList(db.SC_USUAR001, "CODIGO_USUARIO", "NOMBRE_USUARIO", aperturaCierreCaja.idUsuarioReponCaja);
            return View(aperturaCierreCaja);
        }

        // GET: AperturaCierreCajas/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AperturaCierreCaja aperturaCierreCaja = await db.AperturaCierreCajas.FindAsync(id);
            if (aperturaCierreCaja == null)
            {
                return HttpNotFound();
            }
            return View(aperturaCierreCaja);
        }

        // POST: AperturaCierreCajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            AperturaCierreCaja aperturaCierreCaja = await db.AperturaCierreCajas.FindAsync(id);
            db.AperturaCierreCajas.Remove(aperturaCierreCaja);
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
