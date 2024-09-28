using System.Threading.Tasks;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.Models;

namespace POS.Controllers
{
    public class EnvaseController : Controller
    {
        private readonly EnvaseService _envaseService;

        public EnvaseController()
        {
            _envaseService = new EnvaseService();
        }

        // GET: Envase
        public async Task<ActionResult> Index()
        {
            return View(await _envaseService.GetAll(idEmpresa()));
        }

        // GET: Envase/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _envaseService.GetById(id, idEmpresa()));
        }

        // GET: Envase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Envase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descripcion")] Envase envase)
        {
            envase.IdEmpresa = idEmpresa();
            if (!ModelState.IsValid) return View(envase);
            await _envaseService.Add(envase);
            return RedirectToAction("Index");
        }

        // GET: Envase/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _envaseService.GetById(id, idEmpresa()));
        }

        // POST: Envase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descripcion,Activo")] Envase envase)
        {
            envase.IdEmpresa = idEmpresa();
            if (!ModelState.IsValid) return View(envase);
            await _envaseService.Edit(envase);
            return RedirectToAction("Index");
        }

        // GET: Envase/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _envaseService.GetById(id, idEmpresa()));
        }

        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }
        // POST: Envase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _envaseService.Delete(id, idEmpresa());
            return RedirectToAction("Index");
        }
        
    }
}
