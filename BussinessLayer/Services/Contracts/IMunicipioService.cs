using System.Collections.Generic;
using DataLayer.Models;

namespace BussinessLayer.Services.Contracts
{
    public interface IMunicipioService:IBaseService<Municipio>
    {
        IEnumerable<Municipio> GetMunicipiosByProvinciaId(int provinciaId);
    }
}