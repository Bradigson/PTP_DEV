using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Perfiles
    {
        public string FechaCreada { get; set; }
        public int IDPerfil { get; set; }
        public string Perfil { get; set; }
        public string Descripcion { get; set; }
        public long IDUsuario { get; set; }
        public int Bloquear { get; set; }
        public string UltimaFechaModificacion { get; set; }
    }
}