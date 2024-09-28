using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BussinessLayer.Services.Contracts
{
    public interface IDetalleFacturacionService:IBaseService<DetalleFacturacion>
    {
        Task<IEnumerable<DetalleFacturacion>> GetDetalleByFacturacionId(int facturacionId);
    }
}