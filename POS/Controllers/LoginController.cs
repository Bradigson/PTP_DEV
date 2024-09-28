
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.Util;
using DataLayer.PDbContex;
using System.Net.NetworkInformation;
using POS.Models;


namespace POS.Controllers
{
    public class LoginController : Controller
    {
        private Models.Empresa emp;
        private Models.Sucursal suc;
        private Models.Usuario usu;

        private PDbContext db;
        private SC_EMP001 sC_EMP001;
        private SC_SUC001 sC_SUC001;
        private SC_USUAR001 sC_USUAR001;


        private static int count_m = 0;

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                if (count_m > 0) {
                    // Do your stuff

                    count_m = 0;


                }
                else
                {


                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult login(string Usuario, string PasswordUS)
        {
                jObject jobject = new jObject();
                var db = new PDbContext();
                var db2 = db.SC_USUAR001.Where(x => x.USUARIO == Usuario && x.PASSWOR == PasswordUS);
                var getEmpresa = db2.Single().CODIGO_EMP;
                var listaSucursal = db.SC_SUC001.Where(x => x.CODIGO_EMP == getEmpresa).ToList();
                jobject.listaSuculsar = listaSucursal;
                jobject.imagenUser = db2.ToList().Single().IMAGEN_USUARIO;
                jobject.imagenCompany = db.SC_EMP001.Where(x => x.CODIGO_EMP == getEmpresa).ToList().Single().LOGO_EMP;
                jobject.NombreUser = db2.ToList().Single().NOMBRE_USUARIO;
                jobject.User = Usuario;
                jobject.UserPass=PasswordUS;
                Session["User000001"] = jobject;


                return RedirectToAction("Index", "LoginBienvenida");
                
                

            
        }
      

     

        
     
    }
}