using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Services;
using System.Data.Entity;
using BussinessLayer.Services.Contracts;
using DataLayer.PDbContex;

namespace POS.Controllers
{
    public class LocationController : Controller
    {
        //private ProvinciasService _provinciasService;
        private MunicipioService _municipioService;
        private PDbContext db ;
        /// <summary>
        /// Este Controller solo Deuelve estos Json Que se
        /// Utilizaran en muchos otros controllers 
        /// Asi que los hice general
        /// </summary>
        /// <param name="regionId"></param>
        /// <returns></returns>
        public LocationController()
        {
            db = new PDbContext();
        }

        public async Task<JsonResult> GetPais()
        {

            var lst = await db.SC_PAIS001.ToListAsync();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetRegionByPaisId(int Id)
        {

            var lst = await db.SC_REG001.Where(x => x.CODIGO_PAIS == Id).OrderBy(x => x.NOMBRE_REG).ToListAsync();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetProvinciasByRegionId(int Id)
        {
            
            var lst = await db.SC_PROV001.Where(x => x.CODIGO_REG == Id).OrderBy(x => x.NOMBRE_PROV).ToListAsync();
            return Json( lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipiosByProvinciaId(int Id)
        {


            var lst = db.SC_MUNIC001.Where(x => x.CODIGO_PROV == Id).OrderBy(x => x.NOMBRE_MUNIC).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}