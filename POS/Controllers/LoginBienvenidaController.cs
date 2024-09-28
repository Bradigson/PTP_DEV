
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
    public class LoginBienvenidaController : Controller
    {

        private Models.Empresa emp;
        private Models.Sucursal suc;
        private Models.Usuario usu;

        private PDbContext db;
        private SC_EMP001 sC_EMP001;
        private SC_SUC001 sC_SUC001;
        private SC_USUAR001 sC_USUAR001;
        // GET: LoginBienvenida
        public ActionResult Index()
        {
            var jobject = Session["User000001"];
            return View(jobject);
            
        }
        [HttpPost]
        public ActionResult login2(long IdSucursal, string Usuario2, string PasswordUS2)
        {
            try
            {
                //el error es normal
                // emp = new Models.Empresa();
                db = new PDbContext();

                sC_USUAR001 = new SC_USUAR001();
                var validaUsuario = db.SC_USUAR001.Single(x => x.USUARIO == Usuario2 && x.PASSWOR == PasswordUS2 && x.CODIGO_SUC == IdSucursal);

                if (validaUsuario != null)
                {
                    sC_SUC001 = new SC_SUC001();


                    var valida_sucursal = db.SC_SUC001.Single(x => x.CODIGO_SUC == validaUsuario.CODIGO_SUC && x.ESTADO_SUC == true && x.CODIGO_SUC == IdSucursal);
                    if (valida_sucursal != null)
                    {
                        var Empresa = db.SC_EMP001.Single(x => x.CODIGO_EMP == valida_sucursal.CODIGO_EMP);

                        if (Empresa != null)
                        {


                            Session["IP"] = Utilidades.GetIP(NetworkInterfaceType.Wireless80211, "Fisica").ToString();
                            // Session["logitud"] = Utilidades.LocationDevice()[0];
                            // Session["latitud"] = Utilidades.LocationDevice()[1];

                            string log = Utilidades.LocationDevice()[0];
                            string lat = Utilidades.LocationDevice()[1];
                            Session["ID"] = validaUsuario.CODIGO_USUARIO;
                            Session["Nombre"] = validaUsuario.NOMBRE_USUARIO;
                            Session["IDPerfil"] = validaUsuario.ID_PERFIL;
                            Session["Img"] = validaUsuario.IMAGEN_USUARIO;
                            Session["emailUs"] = validaUsuario.CORREO;
                            Session["Telefono"] = validaUsuario.TELEFONO;
                            Session["Fecha"] = validaUsuario.FECHA_ADICION;
                            Session["IDEmpresa"] = Empresa.CODIGO_EMP;
                            Session["Empresa"] = Empresa.NOMBRE_EMP;
                            Session["IDSucursal"] = valida_sucursal.CODIGO_SUC;
                            Session["Sucursal"] = valida_sucursal.NOMBRE_SUC;
                            Session["web"] = Empresa.WEB;
                            Session["RNC"] = Empresa.RNC_EMP;
                            Session["logo"] = Empresa.LOGO_EMP;
                            Session["telefon1Suc"] = valida_sucursal.TELEFONO1;
                            Session["telefon2Suc"] = Empresa.TELEFONO1;
                            // Session["esquema"] = validaSuc.Esquema;
                            //Session["email"] = valida_sucursal.c;
                            return RedirectToAction("Index", "Home");


                        }
                        else
                        {
                            return RedirectToAction("Index", "Login");
                        }




                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");
                    }




                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }



            }
            catch (Exception EX)
            {
              

                return Json(EX.Message);

            }



        }


    }
}