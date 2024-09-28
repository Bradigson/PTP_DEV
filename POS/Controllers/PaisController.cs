using System;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.Models;

namespace POS.Controllers
{
    public class PaisController : Controller
    {
        private readonly PaisService _paisService;

        public PaisController()
        {
            _paisService = new PaisService();
        }

        // GET: Pais
        public async Task<ActionResult> Index()
        {
            try
            {
                var x = await _paisService.GetAll(idEmpresa());
                return View(x);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }

        // GET: Pais/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(await _paisService.GetById((int)id, idEmpresa()));
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre")] Pais pais)
        {
            if (!ModelState.IsValid) return View(pais);

            await _paisService.Add(pais);
            return RedirectToAction("Index");
        }

        // GET: Pais/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(await _paisService.GetById((int)id, idEmpresa()));
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre")] Pais pais)
        {
            if (!ModelState.IsValid) return View(pais);
            await _paisService.Edit(pais);
            return RedirectToAction("Index");
        }

        // GET: Pais/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(await _paisService.GetById((int)id, idEmpresa()));
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _paisService.Delete(id, idEmpresa());
            return RedirectToAction("Index");
        }
    }
}
