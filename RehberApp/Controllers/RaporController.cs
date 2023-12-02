using Business.Abstract;
using Business.Concrete;
using Core.Abstract;
using Core.Helpers;
using DataAccess;
using DataAccess.Entity;
using DataAccess.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RehberApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporController : ControllerBase
    {
        public RaporController(IRaporService raporService)
        {
            RaporService = raporService;
        }

        private readonly IRaporService RaporService;

        [HttpGet]
        [Route("get-request")]
        public async Task<IActionResult> GetRequest(Guid iletisimBilgiTipiId, string icerik)
        {

            IServiceOutput<RaporModel> output = await RaporService.GetRequestRapor(iletisimBilgiTipiId, icerik);

            return await ActionOutput<RaporModel>.GenerateAsync(output);
        }

        [HttpGet]
        [Route("get-list")]
        public async Task<IActionResult> GetListRapor()
        {


            IServiceOutput<List<Rapor>> output = await RaporService.GetList();

            return await ActionOutput<List<Rapor>>.GenerateAsync(output);
        }


        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(Guid raporId)
        {

            IServiceOutput<Rapor> output = await RaporService.GetById(raporId);

            return await ActionOutput<Rapor>.GenerateAsync(output);
        }


    }
}
