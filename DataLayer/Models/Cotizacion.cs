using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Cotizacion:BaseModel
    {
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public decimal MontoTotal { get; set; }

        public decimal DescuntoTotal { get; set; }

        public decimal ItbisTotal { get; set; }

        public int EmpleadoId { get; set; }
        public string NoFactura { get; set; }
            

        public ICollection<DetalleCotizacion> DetalleCotizacion { get; set; }
        
    }
}
