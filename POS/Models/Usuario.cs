using POS.DBConexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace POS.Models
{
    public class Usuario : Conexion
    {
        public string FechaCreada { get; set; }
        public int IDUsuario { get; set; }
        public string usuario { get; set; }
        public string PasswordUS { get; set; }
        public int IDPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string img { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int ID_Pais { get; set; }
        public int ID_Region { get; set; }
        public int ID_Provincia { get; set; }
        public int ID_Municipio { get; set; }
        public int ID_Sectores { get; set; }
        public string Direccion { get; set; }
        public string Cargo { get; set; }
        public long IDEmpresa { get; set; }
        public long IDSucusal { get; set; }
        public int IDUSuarioCreador { get; set; }
        public int Bloquear { get; set; }
        public string UltimaFechaModificacion { get; set; }

        public List<Usuario> getUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            var query = SpQueryTable("spUsuario   1,'',0,'','',0,'','','','','','',0,0,0,0 ,0,'','',0,0,0 ,0,''");

            foreach (DataRow fila in query.Rows)
            {
                lista.Add(new Usuario()
                {

                    FechaCreada = fila["FechaCreada"].ToString(),
                    IDUsuario = int.Parse(fila["IDUsuario"].ToString()),
                    usuario = fila["usuario"].ToString(),
                    PasswordUS = fila["PasswordUS"].ToString(),
                    IDPerfil = int.Parse(fila["IDPerfil"].ToString()),
                    Nombre = fila["Nombre"].ToString(),
                    Apellido = fila["Apellido"].ToString(),
                    img = fila["img"].ToString(),
                    Cedula = fila["Cedula"].ToString(),
                    Telefono = fila["Telefono"].ToString(),
                    Email = fila["Email"].ToString(),
                    ID_Pais = int.Parse(fila["ID_Pais"].ToString()),
                    ID_Region = int.Parse(fila["ID_Region"].ToString()),
                    ID_Provincia = int.Parse(fila["ID_Provincia"].ToString()),
                    ID_Municipio = int.Parse(fila["ID_Municipio"].ToString()),
                    ID_Sectores = int.Parse(fila["ID_Sectores"].ToString()),
                    Direccion = fila["Direccion"].ToString(),
                    Cargo = fila["Cargo"].ToString(),
                    IDEmpresa = long.Parse(fila["IDEmpresa"].ToString()),
                    IDSucusal = long.Parse(fila["IDSucusal"].ToString()),
                    IDUSuarioCreador = int.Parse(fila["IDUSuarioCreador"].ToString()),
                    Bloquear = int.Parse(fila["Bloquear"].ToString()),
                    UltimaFechaModificacion = fila["UltimaFechaModificacion"].ToString()

                });
            }
            return lista;

        }


    }
}