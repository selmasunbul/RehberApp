using Business.Abstract;
using Business.Base;
using Core.Abstract;
using Core.Helpers;
using DataAccess;
using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RaporService : ServiseBase<Rapor, DBContext>, IRaporService
    {
        public RaporService(IIletisimService iletisimService, IBilgiTipiService bilgiTipiService)
        {
            IletisimService = iletisimService;
            BilgiTipiService = bilgiTipiService;
        }

        private readonly IIletisimService IletisimService;
        private readonly IBilgiTipiService BilgiTipiService;

        public async Task<IServiceOutput<RaporModel>> GetRequestRapor(Guid iletisimBilgiTipiId, string icerik)
        {
            RaporModel rapors = new();

            var bilgiTipi = await BilgiTipiService.GetAsync(x => x.Id == iletisimBilgiTipiId);
            if (bilgiTipi != null)
            {
                var kisiler = await IletisimService.GetAllAsync(x => x.KisiId != Guid.Empty && x.BilgiTipiId == bilgiTipi.Id && x.İcerik == icerik);

                rapors.KisiSayisi = kisiler.Count();
                rapors.TalepTarihi = DateTime.UtcNow;
                rapors.RaporDurumu = "tamamlandı";
                rapors.Konum = icerik;

                var telefonTypeId = await BilgiTipiService.GetAsync(x => x.Adı == "telefon");
                if (telefonTypeId != null && kisiler != null)
                {
                    var kisiIdList = kisiler.Select(x => x.KisiId).ToList();
                    var telefonlar = await IletisimService.GetAllAsync(x => kisiIdList.Contains(x.KisiId) && x.BilgiTipiId == telefonTypeId.Id);
                    rapors.TelefonNoSayisi = telefonlar.Count();
                }
            }

            var yeniRapor = new Rapor
            {
                Id = new Guid(),
                RaporDurumu = "tamamlandı" ,
                KisiSayisi = rapors.KisiSayisi,
                TelefonNoSayisi = rapors.TelefonNoSayisi,
                CreatedDate = rapors.TalepTarihi,
                Konum = rapors.Konum,
                
            };

            if (await AddAsync(yeniRapor) != null)
            {
                return await ServiceOutput<RaporModel>.GenerateAsync(200, true, "Başarılı", data: rapors);
            }
            return await ServiceOutput<RaporModel>.GenerateAsync(200, false, "Başarısız", data: rapors);
        }

        public async Task<IServiceOutput<List<Rapor>>> GetList()
        {
            var list = await GetAllAsync();

            if (list != null)
            {
                return await ServiceOutput<List<Rapor>>.GenerateAsync(200, true, "Listelendi", 1, list.Count(), data: list.ToList());
            }

            return await ServiceOutput<List<Rapor>>.GenerateAsync(200, false, "Başarısız");

        }



    }
}

