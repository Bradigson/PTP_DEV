using System.Threading.Tasks;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.Models;

namespace POS.Controllers
{
    public class MarcasController : Controller
    {
        private readonly MarcaService _marcaService;

        public MarcasController()
        {
            _marcaService = new MarcaService();
        }

        // GET: Marcas
        public async Task<ActionResult> Index()
        {
            return View(await _marcaService.GetAll(idEmpresa()));
        }

        // GET: Marcas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _marcaService.GetById(id, idEmpresa()));
        }

        // GET: Marcas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre")] Marca marca)
        {
            marca.IdEmpresa = idEmpresa();
            //if (!ModelState.IsValid) return View(marca);
            await _marcaService.Add(marca);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Create2(string DescripcioMarca01)
        {
            Marca marca = new Marca();
            marca.Nombre= DescripcioMarca01;


            await _marcaService.Add(marca);
            return RedirectToAction("Create","Productos");
        }
        // GET: Marcas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _marcaService.GetById(id, idEmpresa()));
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Activo,FechaModificacion,FechaCreacion,Borrado,IdEmpresa")] Marca marca)
        {
            marca.IdEmpresa = idEmpresa();
            if (!ModelState.IsValid) return View(marca);
            await _marcaService.Edit(marca);
            return RedirectToAction("Index");
        }

        // GET: Marcas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _marcaService.GetById(id, idEmpresa()));
        }
        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _marcaService.Delete(id, idEmpresa());
            return RedirectToAction("Index");
        }
        
    }
}
