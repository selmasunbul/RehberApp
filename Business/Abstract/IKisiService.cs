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
    public interface IKisiService : IServiceBase<Kisi>
    {
        Task<IServiceOutput<List<Kisi>>> GetList();
        Task<IServiceOutput<Kisi>> CreateAsync(KisiModel entity);
        Task<IServiceOutput<List<Kisi>>> RemoveAsync(Guid id);
        Task<IServiceOutput<Kisi>> GetById(Guid kisiId);
    }
}
