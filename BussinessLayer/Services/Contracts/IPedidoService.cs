using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BussinessLayer.Services.Contracts
{
    public interface IPedidoService : IBaseService<Pedido>
    {
        Task<IList<DetallePedido>> GetDetallesByPedido(int pedidoId, long idEMpresa);
    }
}