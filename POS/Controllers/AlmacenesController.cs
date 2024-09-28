using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BussinessLayer.Services;
using BussinessLayer.Services.Contracts;
using DataLayer.Models;

namespace POS.Controllers
{
    public class AlmacenesController : Controller
    {
        private AlmacenesService _almacenesService;

        private RegionService _regionService;

        private ProvinciasService _provinciasService;

        private MunicipioService _municipioService;

        // GET: Almacenes

        private long idEmpresa()
        {
             return long.Parse(Session["IDEmpresa"].ToString());

        }
           

        public AlmacenesController()
        {
            _almacenesService = new AlmacenesService();
            _regionService = new RegionService();
            _provinciasService = new ProvinciasService();
            _municipioService = new MunicipioService();
        }
        public async  Task<ActionResult> Index()
        {
           
            return View(await _almacenesService.GetAll(idEmpresa()));
        }
     

        public async Task<ActionResult> CrearAlmacen()
        {

            var lst = await _regionService.GetAll(idEmpresa());
            ViewData["ListaRegion"] = lst;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CrearAlmacen(Almacenes almacenes)
        {
            almacenes.IDEmpresa = idEmpresa();

            if (ModelState.IsValid)
            {
              
                await _almacenesService.Add(almacenes);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public async Task<ActionResult> EditarAlmacen(int idAlmacen)
        {
    
            var lst = await _regionService.GetAll(idEmpresa());
            ViewData["ListaRegion"] = lst;
            return View(await _almacenesService.GetById(idAlmacen,idEmpresa()));
        }

        [HttpPost]
        public async  Task<ActionResult> EditarAlmacen(Almacenes alm)
        {           
            await _almacenesService.Edit(alm);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EliminarAlmacen(int idAlmacen)
        {
          
            await _almacenesService.Delete(idAlmacen, idEmpresa());
            return RedirectToAction("Index");
        }



        public async Task<JsonResult> GetProvinciasByRegionId(int regionId)
        {
            
            var lst = _provinciasService.GetProvinciasByRegionId1(regionId).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipiosByProvinciaId(int provinciaId)
        {
        
            var lst = _municipioService.GetMunicipiosByProvinciaId(provinciaId);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

    }
}