using Business.Abstract;
using Business.Concrete;
using Core.Abstract;
using Core.Helpers;
using DataAccess;
using DataAccess.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RehberApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilgiTipiController : ControllerBase
    {
        public BilgiTipiController(IBilgiTipiService bilgiTipiService)
        {
            BilgiTipiService = bilgiTipiService;
        }
        private readonly IBilgiTipiService BilgiTipiService;


        [HttpGet]
        [Route("get-list")]
        public async Task<IActionResult> GetList()
        {

            IServiceOutput<List<BilgiTipi>> output = await BilgiTipiService.GetList();

            return await ActionOutput<BilgiTipi>.GenerateAsync(output);
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromForm] string name)
        {

            IServiceOutput<BilgiTipi> output = await BilgiTipiService.CreateAsync(name);

            return await ActionOutput<BilgiTipi>.GenerateAsync<BilgiTipi>(200, true, message: output.Message, data: output.Data);

        }
    }
}
