using Business.Abstract;
using Business.Base;
using Core.Abstract;
using Core.Helpers;
using DataAccess;
using DataAccess.Context;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class IletisimBilgisiService : ServiseBase<IletisimBilgisi, DBContext>, IIletisimService
    {
        public async Task<IServiceOutput<IletisimBilgisi>> CreateAsync(IletisimBilgisiModel entity)
        {

            var iletisimBilgisi = new IletisimBilgisi
            {
                BilgiTipiId = entity.BilgiTipiId,
                KisiId = entity.KisiId,
                İcerik = entity.İcerik,
            };

            if (await AddAsync(iletisimBilgisi) != null)
            {

                return await ServiceOutput<IletisimBilgisi>.GenerateAsync(200, true, "Başarılı", data: iletisimBilgisi);
            }

            return await ServiceOutput<IletisimBilgisi>.GenerateAsync(200, false, "Başarısız", data: iletisimBilgisi);
        }

        public async Task<IServiceOutput<List<IletisimBilgisi>>> RemoveAsync(Guid id)
        {

            bool isItemRemoved = SoftDelete(x => x.Id == id);

            if (isItemRemoved)
            {
                return await ServiceOutput<List<IletisimBilgisi>>.GenerateAsync(200, true, "Silindi");
            }
            return await ServiceOutput<List<IletisimBilgisi>>.GenerateAsync(200, false, "Başarısız");

        }
    }
}
