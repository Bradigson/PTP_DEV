using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Caja
{
    public class Billetes_Moneda
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; }
        public int idMoneda { get; set; }
        public int numeroOrden { get; set; }
        public long idEmpresa { get; set; }

    }
}
