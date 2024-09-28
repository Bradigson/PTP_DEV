using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BussinessLayer.Services.Contracts
{
    public interface IDgiiNcfService:IBaseService<DgiiNcfSecuencia>
    {
        Task<IEnumerable<DgiiNcfSecuencia>> GetLastSecuence();

        Task<string> GetSeqNcfByTipoNcf(int tipoNcf);
        Task<DgiiNcfSecuencia> FindNcfBySequencial(string ncfSeq);
    }
}