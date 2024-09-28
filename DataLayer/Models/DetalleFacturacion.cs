using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DetalleFacturacion:BaseModel
    {

        public int  FacturacionId { get; set; }
        [ForeignKey("FacturacionId")]
        public virtual  Facturacion Facturacion { get; set; }

        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }

        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Itbis   { get; set; }
        [Required]
        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }


    }
}
