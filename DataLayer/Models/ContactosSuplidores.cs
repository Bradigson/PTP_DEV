using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class ContactosSuplidores:BaseModel
    {
        public int IdSuplidor { get; set; }
        [ForeignKey("IdSuplidor")]
        public virtual Suplidores Suplidores { get; set; }

        [StringLength(30),Required]
        public string Nombre { get; set; }

        [StringLength(30), Required]
        public string Telefono1 { get; set; }

        [StringLength(30)]
        public string Telefono2 { get; set; }

        [StringLength(30)]
        public string Extension { get; set; }
    }
}
