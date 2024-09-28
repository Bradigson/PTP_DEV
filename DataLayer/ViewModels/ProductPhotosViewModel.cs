using System.Collections.Generic;
using DataLayer.Models;

namespace DataLayer.ViewModels
{
    public class ProductPhotosViewModel
    {
        public ICollection<Imagen> Imagens { get; set; }
        public int ProductoId { get; set; }
        public int ImagenId { get; set; }
        public int MaxImagenes { get; set; } = 3;
    }
}
