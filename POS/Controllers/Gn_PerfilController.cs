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
using DataLayer.ViewModels;
using DataLayer.PDbContex;

namespace POS.Controllers
{
    public class Gn_PerfilController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: Gn_Perfil
        public async Task<ActionResult> Index()
        {

          long id = idEmpresa();

            return View(await db.Gn_Perfil.Where(x=>x.IDEmpresa==id ).ToListAsync());
        }
        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }

        // GET: Gn_Perfil/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PerfilMenuViewModel headerBody = new PerfilMenuViewModel();
            headerBody.Gn_Perfil = await db.Gn_Perfil.SingleAsync(x => x.IDPerfil == id);
            List<Gn_Permiso> p = new List<Gn_Permiso>();
            p = db.Gn_Permiso.Where(x=>x.IDPerfil==id && x.IDEmpresa== headerBody.Gn_Perfil.IDEmpresa).ToList();

          
            var linkPrincipar = db.Gn_Menu.Where(x => x.Nivel == 0).ToList();
            var linkSecundario = db.Gn_Menu.Where(x => x.Nivel != 0).ToList();
            
            headerBody.Gn_Menu = new List<Gn_Menu>();
            foreach (var x in linkPrincipar)
            {
                
                headerBody.Gn_Menu.Add(x);
                foreach (var xs in linkSecundario)
                {
                    if(xs.Nivel==x.IDMenu)
                    {
                        headerBody.Gn_Menu.Add(xs);
                    }
                }
            }
            
            foreach (var ls in headerBody.Gn_Menu)
            {
                foreach (var ck in p)
                {
                    if (ls.IDMenu == ck.IDMenu)
                    {
                        ls.Check=true;
                    }
                }

            }
            headerBody.Gn_Menu = await db.Gn_Menu.ToListAsync();

            if (headerBody.Gn_Perfil == null)
            {
                return HttpNotFound();
            }
            long empresa = long.Parse(Session["IDEmpresa"].ToString());
            ViewBag.CODIGO_USUARIO = new SelectList(db.SC_USUAR001.Where(x => x.CODIGO_EMP == empresa), "CODIGO_USUARIO", "NOMBRE_USUARIO");            
            ViewBag.CODIGO_SUC = new SelectList(db.SC_SUC001.Where(x=>x.CODIGO_EMP== empresa), "CODIGO_SUC", "NOMBRE_SUC");

            return View(headerBody);
        }
        [HttpPost]
        public async Task<ActionResult> DetailsSave (PerfilMenuViewModel Menu)
        {
            Gn_Permiso pSave;
            db = new PDbContext();
            var lisPermiso = db.Gn_Permiso.Where(x=>x.IDPerfil==Menu.Gn_Perfil.IDPerfil).ToList();

            foreach (var menu in Menu.Gn_Menu)
            {
                if(lisPermiso.Count==0)
                {
                    if(menu.Check==true)
                    {
                        pSave = new Gn_Permiso();
                        pSave.IDPerfil = Menu.Gn_Perfil.IDPerfil;
                        pSave.IDMenu = menu.IDMenu;
                        pSave.IDEmpresa =long.Parse(Session["IDEmpresa"].ToString());
                       // pSave.IDSucursal = int.Parse(Session["IDSucursal"].ToString());
                       
                        db.Gn_Permiso.Add(pSave);
                        db.SaveChanges();

                    }


                }else
                {
                    var p = lisPermiso.Where(x=>x.IDMenu==menu.IDMenu && x.IDPerfil==Menu.Gn_Perfil.IDPerfil).ToList();
                    if(p.Count==0)
                    {
                        if (menu.Check == true)
                        {
                            pSave = new Gn_Permiso();
                            pSave.IDPerfil = Menu.Gn_Perfil.IDPerfil;
                            pSave.IDMenu = menu.IDMenu;
                            pSave.IDEmpresa = long.Parse(Session["IDEmpresa"].ToString());
                            //pSave.IDSucursal = int.Parse(Session["IDSucursal"].ToString());

                            db.Gn_Permiso.Add(pSave);
                            db.SaveChanges();
                        }

                        } else
                    {
                        if(menu.Check==false)
                        {
                            db.Gn_Permiso.Remove(p.Single());
                            db.SaveChanges();
                        }
                    }


                }


            }
            return RedirectToAction("Index");

        }
            // GET: Gn_Perfil/Create
            public ActionResult Create()
        {
            long id = idEmpresa();
            var empr = db.SC_EMP001.Where(x=>x.CODIGO_EMP== id).ToList();
            ViewData["eMPRESA"] = empr;

            return View();
        }

        // POST: Gn_Perfil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FechaCreada,Perfil,Descripcion,IDUsuario,Bloquear,UltimaFechaModificacion,IDEmpresa")] Gn_Perfil gn_Perfil)
        {
            if (ModelState.IsValid)
            {
                gn_Perfil.Bloquear = 0;
                gn_Perfil.FechaCreada =DateTime.Now;
                gn_Perfil.UltimaFechaModificacion = DateTime.Now;
                gn_Perfil.IDUsuario=long.Parse(Session["ID"].ToString());

                db.Gn_Perfil.Add(gn_Perfil);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gn_Perfil);
        }

        // GET: Gn_Perfil/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gn_Perfil gn_Perfil = await db.Gn_Perfil.SingleAsync(x=>x.IDPerfil==id);
            if (gn_Perfil == null)
            {
                return HttpNotFound();
            }
            return View(gn_Perfil);
        }

        // POST: Gn_Perfil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FechaCreada,IDPerfil,Perfil,Descripcion,IDUsuario,Bloquear,UltimaFechaModificacion")] Gn_Perfil gn_Perfil)
        {
            if (ModelState.IsValid)
            {
                gn_Perfil.UltimaFechaModificacion =DateTime.Now;
                gn_Perfil.IDUsuario = long.Parse(Session["ID"].ToString());
                db.Entry(gn_Perfil).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gn_Perfil);
        }

        // GET: Gn_Perfil/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gn_Perfil gn_Perfil = await db.Gn_Perfil.SingleAsync(x => x.IDPerfil == id); ;
            if (gn_Perfil == null)
            {
                return HttpNotFound();
            }
            return View(gn_Perfil);
        }

        // POST: Gn_Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            Gn_Perfil gn_Perfil = await db.Gn_Perfil.SingleAsync(x => x.IDPerfil == id); 
            if(gn_Perfil.Perfil== "ADMIN")
            { ModelState.AddModelError("ADMIN-001", "No se puede eliminar un perfil ADIMIN"); }
            else {
            db.Gn_Perfil.Remove(gn_Perfil);
            await db.SaveChangesAsync();
            }
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
