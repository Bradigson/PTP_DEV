using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Caja
{
    public class Moneda
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; }
        public string siglas { get; set; }
        public string simbolo { get; set; }
        public int idPais { get; set; }
        public long idEmpresa { get; set; }
    }
}
