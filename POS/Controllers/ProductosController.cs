using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Services;
using DataLayer.Models;
using DataLayer.ViewModels;

namespace POS.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoService _productoService;
        private readonly MarcaService _marcaService;
        private readonly VersionService _versionService;
        private readonly EnvaseService _envaseService;
        private readonly SuplidoresService _suplidoresService;

        public ProductosController()
        {
            _productoService = new ProductoService();
            _marcaService = new MarcaService();
            _versionService = new VersionService();
            _envaseService = new EnvaseService();
            _suplidoresService = new SuplidoresService();
        }
        // GET: Productos
        public async Task<ActionResult> Index()
        {
            return View(await _productoService.GetInfoViewModelList(idEmpresa()));
        }


        public async Task<ActionResult> Agotados()
        {
            return View(await _productoService.GetInfoViewModelListAgotado(idEmpresa()));
        }

        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }


        // GET: Productos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(_productoService.GetInfoViewModel(await _productoService.GetById(id, idEmpresa()), idEmpresa()));
        }

        // GET: Productos/Create
        public async Task<ActionResult> Create()
        {
            await LoadLookUps(null);

            return View();
        }

        public async Task<ActionResult> SetPictures(int productId)
        {
            return View(await _productoService.GetPhotoViewModel(productId, idEmpresa()));

        }

        [HttpPost]
        public async Task SaveImage()
        {
            var id = Request["ID"];
            HttpFileCollectionBase files = Request.Files;
            if (files.Count > 0 && files[0] != null)
            {
                HttpPostedFileBase file = files[0];

                var url = System.IO.Path.GetFileName(file.FileName);
                var fullUrl = System.IO.Path.Combine(Server.MapPath("~/Imagenes/Productos"), url);
                file.SaveAs(fullUrl);
                await _productoService.SetProductPicture(int.Parse(id), $"/Imagenes/Productos/{url}", idEmpresa());
            }

            
        }

        [HttpPost]
        public async Task ChangeImage()
        {
            var id = Request["ID"];
            HttpFileCollectionBase files = Request.Files;
            if (files.Count > 0 && files[0] != null)
            {
                HttpPostedFileBase file = files[0];

                var url = System.IO.Path.GetFileName(file.FileName);
                var fullUrl = System.IO.Path.Combine(Server.MapPath("~/Imagenes/Productos"), url);
                file.SaveAs(fullUrl);
                await _productoService.ChangeProductPicture(int.Parse(id), $"/Imagenes/Productos/{url}", idEmpresa());
            }

            
        }

        // POST: Productos/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProductoCreateViewModel producto, HttpPostedFileBase Imagen)
        {
            producto.IdEmpresa = idEmpresa();
            if (producto == null) return View();
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
                    producto.Imagen = "data:image/" + extencioImg.Replace('.', ' ').TrimStart() + ";base64," + Convert.ToBase64String(thePictureAsBytes);



                }
                else
                {
                    producto.Imagen = @"data:image/jpg;base64,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";


                }

                producto.CantidadInventario = 0;
                    await _productoService.Create(producto);
                    return RedirectToAction("Index");
                

                await LoadLookUps(producto.MarcaId);
                return View("Create", producto);
            }
            catch
            {
                await LoadLookUps(producto.MarcaId);
                return View("Create",producto);
            }
        }

        // GET: Productos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var producto = await _productoService.GetById(id, idEmpresa());
            await LoadLookUps(producto.Version.IdMarca);
            return View(_productoService.GetCreateViewModel(producto, idEmpresa()));
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ProductoCreateViewModel producto, HttpPostedFileBase Imagen)
        {
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
                    producto.Imagen = "data:image/" + extencioImg.Replace('.', ' ').TrimStart() + ";base64," + Convert.ToBase64String(thePictureAsBytes);



                }
                else
                {
                    producto.Imagen = @"data:image/jpg;base64,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";


                }
                //if (ModelState.IsValid)
                producto.IdEmpresa = idEmpresa();
                var productToEdit = _productoService.GetProductoFromViewModel(producto, idEmpresa());
                    await _productoService.Edit(productToEdit);
                    return RedirectToAction("Index");
                

                await LoadLookUps(producto.MarcaId);
                return View(producto);
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(_productoService.GetInfoViewModel(await _productoService.GetById(id, idEmpresa()), idEmpresa()));
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(ProductoInfoViewModel producto)
        {
            try
            {
               await _productoService.DeleteProducto(producto, idEmpresa());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> CheckCodeExist(string code)
        {
            return Json(await _productoService.CheckCodeExist(code));
        }
        
        public async Task<ActionResult> GetProductosBySuplidor()
        {
            var list = await _productoService.GetInfoViewModelList(idEmpresa());
            return PartialView("_productosBySuplidor",list);
        }

        public async Task<ActionResult> GetProductoSelector()
        {
            var list = await _productoService.GetInfoViewModelList(idEmpresa());
            return PartialView("_productosSelector", list);
        }
        private async Task LoadLookUps(int? id)
        {
            var marcas = await _marcaService.GetAll(idEmpresa());
            ViewBag.Marcas = new SelectList(marcas, "Id", "Nombre");
            ViewBag.Versiones = id != null ?
                new SelectList(await _versionService.GetVersionesByMarca(id, idEmpresa()), "Id", "Nombre") : 
                new SelectList(new List<Versiones>(), "Id", "Nombre");
            ViewBag.Suplidores = new SelectList(await _suplidoresService.GetAll(idEmpresa()), "Id", "Nombre");
            ViewBag.Envases = new SelectList(await _envaseService.GetAll(idEmpresa()), "Id", "Descripcion");
        }
    }
}
