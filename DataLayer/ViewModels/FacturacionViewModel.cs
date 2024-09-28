using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.ViewModels
{
   public class FacturacionViewModel
    {
        public Facturacion Facturacion { get; set; }

        public List<DetalleFacturacion> DetalleFacturacions { get; set; }

        public DateTime FechaLimite { get; set; }
        public decimal MontoInicial { get; set; }




    }
}
