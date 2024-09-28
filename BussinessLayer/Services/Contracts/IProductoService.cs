using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.ViewModels;

namespace BussinessLayer.Services.Contracts
{
    public interface IProductoService : IBaseService<Producto>
    {
        Task Create(ProductoCreateViewModel producto);
        ProductoInfoViewModel GetInfoViewModel(Producto producto, long idEMpresa);
        Task<List<ProductoInfoViewModel>> GetInfoViewModelList(long idEMpresa);
        ProductoCreateViewModel GetCreateViewModel(Producto producto, long idEMpresa);
        Task<bool> CheckCodeExist(string productCode);
        Task<Producto> GetProductoByCB(long idEmpresa ,string cb = "");
        Task<List<Producto>> GetProductoWithPrice(int priceNumber, long idEMpresa);
        Task<List<ProductoInfoViewModel>> GetProductoBySuplidor(int idSuplidor, long idEMpresa);
        Producto GetProductoFromViewModel(ProductoCreateViewModel producto, long idEMpresa);
        Task<List<Producto>> GetProductListById(int[] productsIdList, long idEMpresa);
        Task<ProductPhotosViewModel> GetPhotoViewModel(int productId, long idEMpresa);
        Task<bool> SetProductPicture(int productId, string image, long idEMpresa);
        Task<bool> ChangeProductPicture(int imageId, string image, long idEMpresa);
    }
}