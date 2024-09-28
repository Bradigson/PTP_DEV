using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class jObject
    {
      
        public string imagenUser { get; set; }
        public string imagenCompany { get; set; }
        public string NombreUser { get; set; }
        [Key]
        public string User { get; set; }
        public string UserPass { get; set; }
        public List<SC_SUC001> listaSuculsar { get; set; }
    }
}