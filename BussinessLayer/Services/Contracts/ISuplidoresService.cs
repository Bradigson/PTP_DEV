using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.ViewModels;

namespace BussinessLayer.Services.Contracts
{
    public interface ISuplidoresService:IBaseService<Suplidores>
    {
        Task Add(Suplidores entity);
    }
}