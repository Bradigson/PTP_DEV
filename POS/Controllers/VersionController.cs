using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.Models;

namespace POS.Controllers
{
    public class VersionController : Controller
    {
        private readonly VersionService _versionService;
        private readonly MarcaService _marcaService;

        public VersionController()
        {
            _versionService = new VersionService();
            _marcaService = new MarcaService();
        }

        // GET: Version
        public async Task<ActionResult> Index()
        {
            return View(await _versionService.GetAll(idEmpresa()));
        }

        // GET: Version/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _versionService.GetById(id, idEmpresa()));
        }

        // GET: Version/Create
        public async Task<ActionResult> Create()
        {

            var marcas = await _marcaService.GetAll(idEmpresa());
            ViewBag.Marcas = new SelectList(marcas, "Id", "Nombre");
            return View();
        }

        // POST: Version/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,IdMarca")] Versiones version)
        {
            version.IdEmpresa = idEmpresa();
            if (!ModelState.IsValid) return View(version);
            await _versionService.Add(version);
            return RedirectToAction("Index");
        }

        // GET: Version/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var marcas = await _marcaService.GetAll(idEmpresa());
            ViewBag.Marcas = new SelectList(marcas, "Id", "Nombre");
            return View(await _versionService.GetById(id, idEmpresa()));
        }

        // POST: Version/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Activo,IdMarca")] Versiones version)
        {
            version.IdEmpresa = idEmpresa();
            if (!ModelState.IsValid) return View(version);
            await _versionService.Edit(version);
            return RedirectToAction("Index");
        }

        // GET: Version/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _versionService.GetById(id, idEmpresa()));
        }
        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }

        // POST: Version/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _versionService.Delete(id, idEmpresa());
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> GetVersionesByMarca(int id)
        {
            var versiones = await _versionService.GetVersionesByMarca(id,idEmpresa());
           

            var versionesList = versiones.Select(x => new
            {
                ID =  x.Id ,
                Text =  x.Nombre 
            }).ToList();

            return Json(versionesList, JsonRequestBehavior.AllowGet);
        }
    }
}
