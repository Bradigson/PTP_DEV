using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BussinessLayer.Services.Contracts
{
    public interface IVersionService : IBaseService<Versiones>
    {
        Task<IList<Versiones>> GetVersionesByMarca(int? id, long idempresa);
    }
}