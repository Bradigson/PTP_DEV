using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Caja
{
    public class MovimientoBanco
    {
        [Key]
        public long Id { get; set; }
        public int IdBanco { get; set; }
        public DateTime Fecha_movimiento { get; set; }
        public string Detalle { get; set; }
        public int idTipoMovimientoBanco { get; set; }
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public virtual SC_USUAR001 usuruario { get; set; }
        public long IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual SC_EMP001 empresa { get; set; }
        public long IdSucursal { get; set; }
        [ForeignKey("IdSucursal")]
        public virtual SC_SUC001 sucursal { get; set; }
        public int IdMoneda { get; set; }

    }
}
