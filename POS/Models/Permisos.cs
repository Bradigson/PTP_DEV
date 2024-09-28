using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using POS.DBConexion;
namespace POS.Models
{
   
        public class Permisos : Conexion
        {
            public long IDPerminso { get; set; }
            public int IDPerfil { get; set; }
            public int IDMenu { get; set; }
            //public long IDSucursal { get; set; }
            public long IDEmpresa { get; set; }


            // spPermisos 1,	0 ,	0,	0 ,	0 ,	0

            public List<Permisos> getPermisos()
            {
                List<Permisos> lista = new List<Permisos>();
                var query = SpQueryTable($"spPermisos {2},{0},{0},{0} ,{0}");
                foreach (DataRow fila in query.Rows)
                {
                    lista.Add(new Permisos()
                    {

                        IDPerminso = long.Parse(fila["IDPerminso"].ToString()),

                        IDPerfil = int.Parse(fila["IDPerfil"].ToString()),

                        IDMenu = int.Parse(fila["IDMenu"].ToString()),

                       // IDSucursal = long.Parse(fila["IDSucursal"].ToString()),

                        IDEmpresa = long.Parse(fila["IDEmpresa"].ToString())

                        //IDMenu = int.Parse(fila["IDMenu"].ToString()),
                        //menu = fila["menu"].ToString(),
                        //Nivel = int.Parse(fila["Nivel"].ToString()),
                        //Orden = int.Parse(fila["Orden"].ToString()),
                        //URL = fila["URL"].ToString(),
                        //MenuIcon = fila["MenuIcon"].ToString()



                    });
                }

                return lista;
            }
        }
    }
