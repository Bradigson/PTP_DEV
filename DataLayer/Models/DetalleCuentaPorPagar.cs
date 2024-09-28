using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DetalleCuentaPorPagar : BaseModel
    {
        public int IdMovAlmacen { get; set; }
       

        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }

        public int IdUsuario { get; set; }

        public bool  IsCanceled { get; set; }


    }
}
