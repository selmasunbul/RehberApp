using Business.Base;
using Core.Abstract;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBilgiTipiService : IServiceBase<BilgiTipi>

    {
        Task<IServiceOutput<List<BilgiTipi>>> GetList();
        Task<IServiceOutput<BilgiTipi>> CreateAsync(string name);
    }
}
