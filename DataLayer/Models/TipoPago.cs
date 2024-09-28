using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
   public  class TipoPago:BaseModel
    {
        [StringLength(30)]
        public string Name { get; set; }
        public string IN_OUT { get; set; }
    }
}
