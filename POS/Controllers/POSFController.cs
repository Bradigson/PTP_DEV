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
    public class POSFController : Controller
    {
        private readonly ProductoService _productoService;
        private readonly MarcaService _marcaService;
        private readonly VersionService _versionService;
        private readonly EnvaseService _envaseService;
        private readonly SuplidoresService _suplidoresService;

        public POSFController(){
            _productoService = new ProductoService();
        _marcaService = new MarcaService();
        _versionService = new VersionService();
        _envaseService = new EnvaseService();
        _suplidoresService = new SuplidoresService();
    }
        // GET: POS
        public async Task<ActionResult> FacturarPOS()
        {
           var marcas = await _marcaService.GetAll(idEmpresa()) ;
            ViewData["Marcas01"] = marcas;
            return View(await _productoService.GetInfoViewModelList(idEmpresa()));
        }

        private long idEmpresa()
        {
            return long.Parse(Session["IDEmpresa"].ToString());

        }



    }
}