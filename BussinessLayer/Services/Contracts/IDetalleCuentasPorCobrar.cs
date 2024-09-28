﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace BussinessLayer.Services.Contracts
{
    public interface IDetalleCuentasPorCobrar:IBaseService<DetalleCuentasPorCobrar>
    {
        Task<IEnumerable<DetalleCuentasPorCobrar>> GetAllByCuentaPorCobrarId(int id);
    }
}
