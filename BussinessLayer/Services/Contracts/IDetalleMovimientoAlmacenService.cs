using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Contracts
{
    public interface IDetalleMovimientoAlmacenService:IBaseService<DetalleMovimientoAlmacen>
    {
        Task<IEnumerable<DetalleMovimientoAlmacen>> GetDetalleMovimientoByMovimientoId(int id, long idEmpresa);
    }
}