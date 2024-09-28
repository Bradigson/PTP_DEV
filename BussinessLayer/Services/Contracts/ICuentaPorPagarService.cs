using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BussinessLayer.Services.Contracts
{
    public interface ICuentaPorPagarService:IBaseService<CuentasPorPagar>
    {
        Task Create(CuentasPorPagar dcp);
    }
}
