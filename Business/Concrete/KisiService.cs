using Business.Abstract;
using Business.Base;
using Core.Abstract;
using Core.Helpers;
using DataAccess;
using DataAccess.Context;
using DataAccess.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class KisiService : ServiseBase<Kisi, DBContext>, IKisiService
    {
        public async Task<IServiceOutput<List<Kisi>>> GetList()
        {
            var list = await GetAllAsync();

            if (list != null)
            {
                return await ServiceOutput<List<Kisi>>.GenerateAsync(200, true, "Listelendi", 1, list.Count(), data: list.ToList());
            }

            return await ServiceOutput<List<Kisi>>.GenerateAsync(200, false, "Başarısız");

        }


        public async Task<IServiceOutput<Kisi>> CreateAsync(KisiModel entity)
        {

            var kisi = new Kisi
            {
              Adı = entity.Adı,
              SoyAdi = entity.SoyAdi,
              Firma = entity.Firma,
              İletisimBilgisiId = entity.İletisimBilgisiId
            };

            if (await AddAsync(kisi) != null)
                {

                    return await ServiceOutput<Kisi>.GenerateAsync(200, true, "Başarılı", data: kisi);
                }

                return await ServiceOutput<Kisi>.GenerateAsync(200, false, "Başarısız", data: kisi);
        }

        public async Task<IServiceOutput<List<Kisi>>> RemoveAsync(Guid id)
        {

            bool isItemRemoved = SoftDelete(x => x.Id == id);

            if (isItemRemoved)
            {
                return await ServiceOutput<List<Kisi>>.GenerateAsync(200, true, "Silindi");
            }
            return await ServiceOutput<List<Kisi>>.GenerateAsync(200, false, "Başarısız");

        }


    }
}
