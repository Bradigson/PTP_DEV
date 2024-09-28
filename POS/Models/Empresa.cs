using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS.DBConexion;

namespace POS.Models
{
    public class Empresa : Conexion
    {
        public string FechaCreada { get; set; }
        public long IDEmpresa { get; set; }
        public string empresa { get; set; }
        public string ServidorDB { get; set; }
        public string UsuarioDB { get; set; }
        public string PasswordDB { get; set; }
        public string DBnombre { get; set; }
        public string IP { get; set; }







        public List<Empresa> getEmpresas()
        {
            List<Empresa> lista = new List<Empresa>();
            var query = SpQueryTable(" spEmpresa 1,'',0,'','', '', '', '','','' ");

            foreach (DataRow fila in query.Rows)
            {
                lista.Add(new Empresa()
                {
                    FechaCreada = fila["FechaCreada"].ToString(),
                    IDEmpresa = long.Parse(fila["IDEmpresa"].ToString()),
                    empresa = fila["Empresa"].ToString(),
                    ServidorDB = fila["ServidorDB"].ToString(),
                    UsuarioDB = fila["UsuarioDB"].ToString(),
                    PasswordDB = fila["PasswordDB"].ToString(),
                    DBnombre = fila["DBnombre"].ToString(),
                    IP = fila["IP"].ToString()

                });
            }
            return lista;

        }
    }
}