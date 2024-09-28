using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DetalleCuentasPorCobrar:BaseModel
    {
        public int FacturacionId { get; set; }
              
        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }

        public bool IsCalceled { get; set; }

        public int IdUsuario { get; set; }


    }
}
