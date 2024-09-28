using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.ViewModels;

namespace BussinessLayer.Services.Contracts
{
    public interface IFacturacionService:IBaseService<Facturacion>
    {
        Task Create(FacturacionViewModel vm);
    }
}
