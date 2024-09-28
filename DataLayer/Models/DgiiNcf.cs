using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DgiiNcf : BaseModel
    {
        
        [Required]
        public string Serie { get; set; }
        [Required]
        public string TipoComprobante { get; set; }
        [Required]
        public string SecuencialInicial { get; set; }
        [Required]
        public string SecuenciaDgii { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaVencimiento { get; set; }

        public int IdUsuario { get; set; }//Nombre y ID del Usuario Separado por Guion

        public string Usuario { get; set; }//Nombre y ID del Usuario Separado por Guion

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaModificacion { get; set; }

        [Required]
        public string  Descripcion { get; set; }


    }

   
}
