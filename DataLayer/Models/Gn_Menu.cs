using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
   public class Gn_Menu
    {

        [Key]
        public int IDMenu { get; set; }

        public string Menu { get; set; }

        [NotMapped]
        public bool Check { get; set; }

        public int Nivel { get; set; }
        public int Orden { get; set; }
        public string URL { get; set; }
        public string MenuIcon { get; set; }
        public  int IDEmpresa { get; set; }

    }
}
