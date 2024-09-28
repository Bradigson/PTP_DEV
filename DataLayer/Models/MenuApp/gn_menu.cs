using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.MenuApp
{
    public class gn_menu
    {
        [Key]
        public int IDMenu { get; set; }
        public string Menu { get; set; }
        public int Nivel { get; set; }
        public int Orden { get; set; }
        public string URL { get; set; }
        public string MenuIcon { get; set; }
        public int IDEmpresa { get; set; }
        public int menupadre { get; set; }
    }
}
