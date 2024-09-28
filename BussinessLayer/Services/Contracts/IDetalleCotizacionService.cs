using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BussinessLayer.Services.Contracts
{
    public interface IDetalleCotizacionService:IBaseService<DetalleCotizacion>
    {
       Task< IEnumerable<DetalleCotizacion> >GetAllByCotizacionId(int cotizacionId);
    }
}