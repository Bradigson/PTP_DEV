using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.ViewModels;

namespace BussinessLayer.Services.Contracts
{
    public interface IPrecioService
    {

        Task<IList<ProductoPrecioInfoViewModel>> GetProductPricesInfo(long idEmpresa);
        Task AssignPrices(ProductoPrecioInfoViewModel productosPrecio, long idEmpresa);
        Task<ProductoPrecioInfoViewModel> GetPrecioViewModel(int idProducto, long idEmpresa);
        Task SetSamePrice(SetProductsPriceViewModel priceViewModel, long idEmpresa);
        Task<bool> SetPriceByNumber(int priceNumber, long idEmpresa);
    }
}