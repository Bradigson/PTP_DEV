using DataLayer.Models;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Contracts
{
    public interface IMovimientoAlmacenService:IBaseService<MovimientoAlmacen>
    {
         Task Create();
    }
}