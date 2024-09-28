using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Caja
{
    public class TipoMovimientoBanco
    {
        [Key]
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string DebitoCreditootro { get; set; }
        public string InternoExterno { get; set; }
        public int IdUsuarioCrea { get; set; }
        [ForeignKey("IdUsuarioCrea")]
        public virtual SC_USUAR001 usuruario { get; set; }
        public bool Estado { get; set; }
        public long IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual SC_EMP001 empresa { get; set; }

    }
}
