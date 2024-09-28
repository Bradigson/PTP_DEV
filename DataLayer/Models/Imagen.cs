using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Imagen : BaseModel
    {
        public Imagen()
        {
            FechaModificacion = DateTime.Now;
        }
        public byte[] Image { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Ruta { get; set; }
    }
}
