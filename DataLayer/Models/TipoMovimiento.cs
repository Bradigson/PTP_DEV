using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TipoMovimiento:BaseModel
    {
        public string Nombre { get; set; }
        public string IN_OUT { get; set; }


    }
}
