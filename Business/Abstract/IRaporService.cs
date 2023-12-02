using Business.Base;
using Core.Abstract;
using DataAccess;
using DataAccess.Entity;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRaporService : IServiceBase<Rapor>
    {
        Task<IServiceOutput<RaporModel>> GetRequestRapor(Guid iletisimBilgiTipiId, string icerik);
        Task<IServiceOutput<List<Rapor>>> GetList();
    }
}
