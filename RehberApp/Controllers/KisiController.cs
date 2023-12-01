using Business.Abstract;
using Core.Abstract;
using Core.Helpers;
using DataAccess;
using DataAccess.ViewModel;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RehberApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisiController : ControllerBase
    {

        public KisiController(IKisiService kisiService) 
        {
            KisiService = kisiService;
        }
        private readonly IKisiService KisiService;



        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromForm] KisiModel kisi)
        {

            IServiceOutput<Kisi> output = await KisiService.CreateAsync(kisi);

            return await ActionOutput<Kisi>.GenerateAsync<Kisi>(200, true, message: output.Message, data: output.Data);

        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromForm] Guid id)
        {

            IServiceOutput<List<Kisi>> output = await KisiService.RemoveAsync(id);

            return await ActionOutput<List<Kisi>>.GenerateAsync(output);
        }


        [HttpGet]
        [Route("get-list")]
        public async Task<IActionResult> GetList()
        {

            IServiceOutput<List<Kisi>> output = await KisiService.GetList();

            return await ActionOutput<Kisi>.GenerateAsync(output);
        }


    }
}
