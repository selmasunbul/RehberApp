using Business.Base;
using Core.Abstract;
using DataAccess;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIletisimService : IServiceBase<IletisimBilgisi>
    {
        Task<IServiceOutput<IletisimBilgisi>> CreateAsync(IletisimBilgisiModel entity);
        Task<IServiceOutput<List<IletisimBilgisi>>> RemoveAsync(Guid id);
    }
}
