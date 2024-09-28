using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Enums;

namespace DataLayer.Models
{
   public  class Descuentos: BaseModel
    {
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }

        public int DescuentoPorcentaje { get; set; }
        public int DescuentoFijo { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public TipoDescuento TipoDescuento { get; set; }

        public bool Activo { get; set; }
        public virtual string NombreProducto { get; set; }


    }
}
