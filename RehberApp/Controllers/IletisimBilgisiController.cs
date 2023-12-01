using Business.Abstract;
using Business.Concrete;
using Core.Abstract;
using Core.Helpers;
using DataAccess.ViewModel;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RehberApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IletisimBilgisiController : ControllerBase
    {
        public IletisimBilgisiController(IIletisimService iletisimService)
        {
            IletisimService = iletisimService;
        }

        private readonly IIletisimService IletisimService;


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromForm] IletisimBilgisiModel kisi)
        {

            IServiceOutput<IletisimBilgisi> output = await IletisimService.CreateAsync(kisi);

            return await ActionOutput<IletisimBilgisi>.GenerateAsync<IletisimBilgisi>(200, true, message: output.Message, data: output.Data);

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromForm] Guid id)
        {

            IServiceOutput<List<IletisimBilgisi>> output = await IletisimService.RemoveAsync(id);

            return await ActionOutput<List<IletisimBilgisi>>.GenerateAsync(output);
        }

    }
}
