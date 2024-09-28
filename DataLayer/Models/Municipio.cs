using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
   public  class Municipio:BaseModel
    {
        public string Nombre { get; set; }
        public int  IdProvincia { get; set; }
        [ForeignKey("IdProvincia")]
        public virtual Provincia Provincia { get; set; }
    }
}
