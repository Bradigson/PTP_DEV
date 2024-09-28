using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Provincia:BaseModel
    {
        public string Nombre { get; set; }

        public int IdRegion { get; set; }
        [ForeignKey("IdRegion")]
        public virtual Region Region { get; set; }
    }
}
