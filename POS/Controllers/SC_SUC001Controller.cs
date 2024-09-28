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
using System.Net.NetworkInformation;
using System.Net.Sockets;


namespace POS.Controllers
{
    public class SC_SUC001Controller : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: SC_SUC001
        public async Task<ActionResult> Index()
        {
            var sC_SUC001 = db.SC_SUC001.Include(s => s.SC_EMP001);
            return View(await sC_SUC001.ToListAsync());
        }

        // GET: SC_SUC001/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_SUC001 sC_SUC001 = await db.SC_SUC001.FindAsync(id);

            ViewBag.nombrUsurio1 = db.SC_USUAR001.Single(x => x.CODIGO_USUARIO == sC_SUC001.USUARIO_ADICCION).NOMBRE_USUARIO;
            if (sC_SUC001 == null)
            {
                return HttpNotFound();
            }

            ViewBag.nombrUsurio = db.SC_USUAR001.Single(x => x.CODIGO_USUARIO == sC_SUC001.USUARIO_MODIFICACION).NOMBRE_USUARIO;
            if (sC_SUC001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_SUC001);
        }

        // GET: SC_SUC001/Create
        public ActionResult Create()
        {

            initCializacion();


            return View();
        }
        private void initCializacion()
        {
            var pais = db.SC_PAIS001.OrderBy(x => x.NOMBRE_PAIS).ToList();
            ViewData["pais"] = pais;

            var eMPRESA = db.SC_EMP001.ToList();
            ViewData["eMPRESA"] = eMPRESA;
        }
        // POST: SC_SUC001/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO_SUC,CODIGO_EMP,NOMBRE_SUC,TELEFONO1,ID_USUARIO_RESPONSABLE,Cod_Pais,Cod_Region,Cod_Provincia,IdMunicipio,DIRECCION,ESTADO_SUC,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD,PRINCIPAL")] SC_SUC001 sC_SUC001)
        {
            if (ModelState.IsValid)
            {

               var eMPRESA = db.SC_EMP001.Where(x=>x.CODIGO_EMP== sC_SUC001.CODIGO_EMP).Single();
               var vC_SUC001 = db.SC_SUC001.Where(x => x.CODIGO_EMP == sC_SUC001.CODIGO_EMP).ToList();
                int coutSuc= vC_SUC001.Count();
                if (vC_SUC001.Count() >= eMPRESA.CANT_SUCURSALES )
                {
                    ModelState.AddModelError("Plan-001","Ha excedido la cantidad de sucursal por plan. Para la modificacion del plan cominiquese con su proveedor");
                    initCializacion();

                } //else if ((vC_SUC001.Where(x=>x.PRINCIPAL== sC_SUC001.PRINCIPAL).Count() == 1) )
                //{ ModelState.AddModelError("Plan-001", "No puedes tener dos sucursales como principal"); }else
                    
                { 
                sC_SUC001.FECHA_ADICION = DateTime.Now;
                sC_SUC001.FECHA_MODIFICACION = DateTime.Now;
               sC_SUC001.IP_ADICCION = "0";
                sC_SUC001.IP_MODIFICACION = "0";
                sC_SUC001.USUARIO_ADICCION = int.Parse(Session["ID"].ToString());
                sC_SUC001.USUARIO_MODIFICACION = int.Parse(Session["ID"].ToString());

                db.SC_SUC001.Add(sC_SUC001);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
                }

            }

         
            return View(sC_SUC001);
        }

        // GET: SC_SUC001/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_SUC001 sC_SUC001 = await db.SC_SUC001.FindAsync(id);
            var pais = db.SC_PAIS001.ToList();
            ViewData["pais"] = pais;

            var reg = db.SC_REG001.Where(x => x.CODIGO_PAIS == sC_SUC001.Cod_Pais).ToList();
            ViewData["reg"] = reg;

            var provin = db.SC_PROV001.Where(x => x.CODIGO_REG == sC_SUC001.Cod_Region).ToList();
            ViewData["provin"] = provin;

            var mun = db.SC_MUNIC001.Where(x => x.CODIGO_PROV == sC_SUC001.Cod_Provincia).ToList();
            ViewData["mun"] = mun;


            var empr = db.SC_EMP001.ToList();
            ViewData["eMPRESA"] = empr;
            
            if (sC_SUC001 == null)
            {
                return HttpNotFound();
            }
  
            return View(sC_SUC001);
        }

        // POST: SC_SUC001/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO_SUC,CODIGO_EMP,NOMBRE_SUC,TELEFONO1,ID_USUARIO_RESPONSABLE,Cod_Pais,Cod_Region,Cod_Provincia,IdMunicipio,DIRECCION,ESTADO_SUC,IP_ADICCION,IP_MODIFICACION,USUARIO_ADICCION,FECHA_ADICION,USUARIO_MODIFICACION,FECHA_MODIFICACION,LONGITUD,LATITUD")] SC_SUC001 sC_SUC001)
        {
            if (ModelState.IsValid)
            {
                
                sC_SUC001.FECHA_MODIFICACION = DateTime.Now;
                sC_SUC001.IP_MODIFICACION = "";               
                sC_SUC001.USUARIO_MODIFICACION = int.Parse(Session["ID"].ToString());
                sC_SUC001.LATITUD = "0";
                sC_SUC001.LONGITUD = "0";
            


                db.Entry(sC_SUC001).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
              return View(sC_SUC001);
        }

        // GET: SC_SUC001/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_SUC001 sC_SUC001 = await db.SC_SUC001.FindAsync(id);
            if (sC_SUC001 == null)
            {
                return HttpNotFound();
            }
            return View(sC_SUC001);
        }

        // POST: SC_SUC001/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SC_SUC001 sC_SUC001 = await db.SC_SUC001.FindAsync(id);
            db.SC_SUC001.Remove(sC_SUC001);
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
