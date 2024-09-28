using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Services;
using BussinessLayer.Services.Contracts;
using DataLayer.Models;
using DataLayer.PDbContex;
using System.Data.Entity;
using DataLayer.ViewModels;
using System.Linq;

namespace POS.Controllers
{
    public class SuplidoresController : Controller
    {
        private SuplidoresService _suplidoresService; 
        private ContactosSuplidoresService _contactosSuplidoresService;
        private PDbContext db = new PDbContext();
        //private RegionService _regionService;
        //private PaisService _PaisService;
        //private MunicipioService _municipoService;
        //private BussinessLayer.Services.Contracts.ProvinciasService _provinciasService;


        public SuplidoresController()
        {
            _suplidoresService = new SuplidoresService();
            _contactosSuplidoresService = new ContactosSuplidoresService();
        }
        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }

        // GET: Suplidores
        public async Task<ActionResult> Index()
        {
            return View( await _suplidoresService.GetAll(idEmpresa()));
        }


        public async Task<ActionResult> CrearSuplidor()
        {
            //_regionService= new RegionService();
            //_provinciasService= new ProvinciasService();

            var pais = db.SC_PAIS001.ToList();
            ViewData["pais"] = pais;


            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CrearSuplidor(Suplidores cs, HttpPostedFileBase Imagen)
        {
            if (ModelState.IsValid)
            {

                @TempData["alerta"] = "x";
            try
            {

                if (Imagen != null)
                {
                   

                    string theFileName = Path.GetFileName(Imagen.FileName);
                    byte[] thePictureAsBytes = new byte[Imagen.ContentLength];
                    using (BinaryReader theReader = new BinaryReader(Imagen.InputStream))
                    {
                        thePictureAsBytes = theReader.ReadBytes(Imagen.ContentLength);
                    }
                    var extencioImg = System.IO.Path.GetExtension(Imagen.FileName);
                    cs.Imagen = "data:image/" + extencioImg.Replace('.', ' ').TrimStart() + ";base64," + Convert.ToBase64String(thePictureAsBytes);
                    


                }
                else
                {
                    cs.Imagen = @"data:image/jpg;base64,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";


                }

                cs.Fecha_Modificacion = DateTime.Now;
                cs.Usuario_Adicion = int.Parse(Session["ID"].ToString());
                cs.Usuario_Modificacion = int.Parse(Session["ID"].ToString());

                await _suplidoresService.Add(cs);

                @TempData["titulo"] = "Guardado";
                @TempData["message"] = "Suplidor Guardado Exitosamente!";
                @TempData["alerta"] = "success";


                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                @TempData["message"] = "Cliente Guardado Exitosamente! " + e.Message;
                @TempData["alerta"] = "warning";
                return View(cs);
            
        }
        }
            else
            {
                var sC_REG001 = db.SC_REG001.Include(x => x.SC_PAIS001);
                var provincia = db.SC_PROV001.ToListAsync();
               

        ViewData["Regiones"] = await sC_REG001.ToListAsync() ;
        ViewData["Provincias"] = await provincia;
     
                @TempData["titulo"] = "Advertencia";
                @TempData["message"] = "Revisar la informacion! ";
                @TempData["alerta"] = "warning";
                return View(cs);
    }
}


        public async Task<ActionResult> EditarSuplidor(int id)
        {
            var pais = await  db.SC_PAIS001.ToListAsync();
            var sC_REG001 = await db.SC_REG001.Include(x => x.SC_PAIS001).ToListAsync();
            var provincia = await db.SC_PROV001.ToListAsync();
            var municipio = await db.SC_MUNIC001.ToListAsync();

         

            ViewData["ListaRegion"] = sC_REG001;
            ViewData["ListaMunicipio"] = municipio;
            ViewData["ListaProvincia"] = provincia;
            return View( await _suplidoresService.GetById(id, idEmpresa()));
        }

        [HttpPost]
        public async Task<ActionResult> EditarSuplidor(Suplidores cs, HttpPostedFileBase Imagen)
        {
            if (Imagen != null)
            {


                string theFileName = Path.GetFileName(Imagen.FileName);
                byte[] thePictureAsBytes = new byte[Imagen.ContentLength];
                using (BinaryReader theReader = new BinaryReader(Imagen.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(Imagen.ContentLength);
                }
                var extencioImg = System.IO.Path.GetExtension(Imagen.FileName);
                cs.Imagen = "data:image/" + extencioImg.Replace('.', ' ').TrimStart() + ";base64," + Convert.ToBase64String(thePictureAsBytes);



            } else
            {
              
                cs.Imagen = Session["imagen2"].ToString();

            }
         

            cs.Fecha_Modificacion = DateTime.Now;
            cs.Usuario_Adicion = int.Parse(Session["ID"].ToString());
            cs.Usuario_Modificacion = int.Parse(Session["ID"].ToString());

            await _suplidoresService.Edit(cs);
            @TempData["titulo"] = "Guardado";
            @TempData["message"] = "Suplidor Guardado Exitosamente!";
            @TempData["alerta"] = "success";

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EliminarSuplidor(int idSuplidor)
        {

            await _suplidoresService.Delete(idSuplidor, idEmpresa());
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> CrearContactoSuplidor(int idSuplidor)
        {
            ViewData["IdSuplidor"] = idSuplidor;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CrearContactoSuplidor(ContactosSuplidores ctc)
        {
            int idSuplidor = ctc.IdSuplidor;
            await _contactosSuplidoresService.Add(ctc);
            return RedirectToAction("EditarContactos",new{id = idSuplidor });
        }

        public async Task<ActionResult> EditarContact(int id)
        {
            return View(await _suplidoresService.GetById(id, idEmpresa()));
        }

        public async Task<ActionResult> EditarContacto(int idContacto)
        {
            return View(await _contactosSuplidoresService.GetById(idContacto, idEmpresa()));
        }

        [HttpPost]
        public async Task<ActionResult> EditarContacto(ContactosSuplidores cs)
        {
            await _contactosSuplidoresService.Edit(cs);
            return RedirectToAction("EditarContactos",new{id=cs.IdSuplidor});
        }

        public async Task<ActionResult> Eliminarcontacto(int idContacto)
        {
            var c = await _contactosSuplidoresService.GetById(idContacto, idEmpresa());
            await _contactosSuplidoresService.Delete(idContacto, idEmpresa());
            return RedirectToAction("EditarContactos",new{id= c.IdSuplidor});
        }



    }
}