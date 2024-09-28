using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models.MenuApp;
using DataLayer.PDbContex;

namespace POS.Controllers
{
    public class gn_menuController : Controller
    {
        private PDbContext db = new PDbContext();

        // GET: gn_menu
        public async Task<ActionResult> Index()
        {
            return View(await db.gn_menus.ToListAsync());
        }

        // GET: gn_menu/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gn_menu gn_menu = await db.gn_menus.FindAsync(id);
            if (gn_menu == null)
            {
                return HttpNotFound();
            }
            return View(gn_menu);
        }

        // GET: gn_menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: gn_menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDMenu,Menu,Nivel,Orden,URL,MenuIcon,IDEmpresa,menupadre")] gn_menu gn_menu)
        {
            if (ModelState.IsValid)
            {
                db.gn_menus.Add(gn_menu);
                 await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gn_menu);
        }

        // GET: gn_menu/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gn_menu gn_menu = await db.gn_menus.FindAsync(id);
            if (gn_menu == null)
            {
                return HttpNotFound();
            }
            return View(gn_menu);
        }

        // POST: gn_menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDMenu,Menu,Nivel,Orden,URL,MenuIcon,IDEmpresa,menupadre")] gn_menu gn_menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gn_menu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gn_menu);
        }

        // GET: gn_menu/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gn_menu gn_menu = await db.gn_menus.FindAsync(id);
            if (gn_menu == null)
            {
                return HttpNotFound();
            }
            return View(gn_menu);
        }

        // POST: gn_menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            gn_menu gn_menu = await db.gn_menus.FindAsync(id);
            db.gn_menus.Remove(gn_menu);
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
