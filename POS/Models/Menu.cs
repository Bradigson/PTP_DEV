using POS.DBConexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Menu : Conexion
    {
        public int IDMenu { get; set; }

        public string menu { get; set; }

        public int Nivel { get; set; }

        public int Orden { get; set; }

        public string URL { get; set; }
        public string MenuIcon { get; set; }
        public int menupadre { get; set; }


        public List<Menu> getMenu()
        {
            List<Menu> lista = new List<Menu>();
            var query = SpQueryTable("spMenu 1,0,'','',0,'',''");
            foreach (DataRow fila in query.Rows)
            {
                lista.Add(new Menu()
                {
                    IDMenu = int.Parse(fila["IDMenu"].ToString()),
                    menu = fila["menu"].ToString(),
                    Nivel = int.Parse(fila["Nivel"].ToString()),
                    Orden = int.Parse(fila["Orden"].ToString()),
                    URL = fila["URL"].ToString(),
                    MenuIcon = fila["MenuIcon"].ToString(),
                    menupadre= int.Parse(fila["menupadre"].ToString())


                });
            }

            return lista.OrderBy(x=>x.Orden).ToList();
        }

        public List<Menu> CargaMenuEnOrden()
        {
            List<Menu> menuFinal = new List<Menu>();
            List<Menu> returnValue = getMenu();

            List<Menu> menu = (from m in returnValue
                                     where m.Nivel == 1
                                     select m).OrderBy(x=>x.Orden).ToList();

            List<Menu> subMenu;
            List<Menu> subMenunivel3;
            //int count = 0;
            int count2 = 0;
            int count3 = 0;
            // string superMenu = "<ul class=\"nav\" id=\"side-menu\">";

            foreach (Menu me in menu)
            {
                menuFinal.Add(new Menu() { IDMenu = me.IDMenu,  menupadre = me.menupadre, menu = me.menu, Nivel = me.Nivel ,URL=me.URL, MenuIcon=me.MenuIcon});
                //primer nivel

                //segundo nivel
                subMenu = (from sM in returnValue
                           where sM.Nivel == 2
                              && sM.menupadre == me.IDMenu
                           select sM).OrderBy(x => x.Orden).ToList();


                foreach (Menu subme in subMenu)
                {
                    menuFinal.Add(new Menu() { IDMenu = subme.IDMenu,  menupadre = subme.menupadre, menu = subme.menu, Nivel = subme.Nivel, URL = subme.URL, MenuIcon = subme.MenuIcon });


                    //tercer nivel
                    subMenunivel3 = (from sM in returnValue
                                     where sM.Nivel == 3
                                        && sM.menupadre == subme.IDMenu
                                     select sM).OrderBy(x => x.Orden).ToList();



                    foreach (Menu subme3 in subMenunivel3)
                    {
                        menuFinal.Add(new Menu() { IDMenu = subme3.IDMenu,  menupadre = subme3.menupadre, menu = subme3.menu, Nivel = subme3.Nivel, URL = subme3.URL, MenuIcon = subme3.MenuIcon });
                        count3++;
                    }



                    count2++;
                }


            }


            return menuFinal;
        }
    }
}