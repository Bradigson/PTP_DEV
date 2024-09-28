using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.ViewModels
{
   public  class CotizacionViewModel
    {
        public Cotizacion Cotizacion { get; set; }

        public DetalleCotizacion[] DetalleCotizacion { get; set; }
    }
}
