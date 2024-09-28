using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels
{
    public class MovimientoAlmacenViewModel
    {
        public MovimientoAlmacen MovimientoAlmacen { get; set; }

        public DetalleMovimientoAlmacen DetalleMovimiento { get; set; }
        
    }

}
