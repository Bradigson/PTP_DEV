using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DetalleMovimientoAlmacen:BaseModel
    {
        public int IdMovimiento { get; set; }
        [ForeignKey("IdMovimiento")]
        public virtual MovimientoAlmacen MovimientoAlmacen { get; set; }

        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }

        public int Cantidad { get; set; }
       
    }
}
