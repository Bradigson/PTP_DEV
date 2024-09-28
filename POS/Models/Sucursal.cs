using POS.DBConexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace POS.Models
{
    public class Sucursal : Conexion
    {

        public string FechaCreada { get; set; }
        public long IDSucursal { get; set; }
        public string sucursal { get; set; }
        public string Esquema { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Email { get; set; }
        public string SitoWeb { get; set; }
        public string RNC { get; set; }
        public int ID_Pais { get; set; }
        public int ID_Region { get; set; }
        public int ID_Provincia { get; set; }
        public int ID_Municipio { get; set; }
        public int ID_Sectores { get; set; }
        public string Direccion { get; set; }
        public string logo { get; set; }
        public string UltimaFechaModificacion { get; set; }
        public int Bloquear { get; set; }
        public string IP { get; set; }
        public long IDEmpresa { get; set; }

        public List<Sucursal> getSucursales()
        {
            List<Sucursal> lista = new List<Sucursal>();
            var query = SpQueryTable("spSucursal 1, '','','','','','','','','',0,0 ,0,0,'' ,'' ,''  ,0 ,'',0 ");

            foreach (DataRow fila in query.Rows)
            {
                lista.Add(new Sucursal()
                {
                    FechaCreada = fila["FechaCreada"].ToString(),
                    IDEmpresa = long.Parse(fila["IDEmpresa"].ToString()),

                    IDSucursal = long.Parse(fila["IDSucursal"].ToString()),

                    sucursal = fila["sucursal"].ToString(),

                    Esquema = fila["Esquema"].ToString(),

                    Telefono1 = fila["Telefono1"].ToString(),

                    Telefono2 = fila["Telefono2"].ToString(),

                    Email = fila["Email"].ToString(),

                    SitoWeb = fila["SitoWeb"].ToString(),

                    RNC = fila["RNC"].ToString(),

                    ID_Pais = int.Parse(fila["ID_Pais"].ToString()),

                    ID_Region = int.Parse(fila["ID_Region"].ToString()),

                    ID_Provincia = int.Parse(fila["ID_Provincia"].ToString()),

                    ID_Municipio = int.Parse(fila["ID_Municipio"].ToString()),

                    ID_Sectores = int.Parse(fila["ID_Sectores"].ToString()),

                    Direccion = fila["Direccion"].ToString(),

                    logo = fila["logo"].ToString(),

                    UltimaFechaModificacion = fila["UltimaFechaModificacion"].ToString(),
                    Bloquear = int.Parse(fila["Bloquear"].ToString()),

                    IP = fila["IP"].ToString()

                });
            }
            return lista;

        }
    }
}