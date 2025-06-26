using Microsoft.AspNetCore.Mvc;
using NzWalksUI.Models.Dtos;
using System.Text;
using System.Text.Json;

namespace NzWalksUI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClient)
        {
            httpClientFactory = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            List<RegionsDto> Regionlist = new List<RegionsDto>();

            try
            {
                var client = httpClientFactory.CreateClient();
                var GetResponse = await client.GetAsync("https://localhost:7298/api/Region");  //call restapi using url
                GetResponse.EnsureSuccessStatusCode();
                Regionlist.AddRange(await GetResponse.Content.ReadFromJsonAsync<IEnumerable<RegionsDto>>());


            }
            catch (Exception)
            {

                throw;
            }
            return View(Regionlist);
        }
        [HttpGet]
        public IActionResult Add()
        {


            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(CreateRegion createRegion)
        {

            var client = httpClientFactory.CreateClient();
            var httpreq = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7298/api/Region"),
                Content = new StringContent(JsonSerializer.Serialize(createRegion), Encoding.UTF8, "application/json")
            };
            var httpResponsemsg = await client.SendAsync(httpreq);
            httpResponsemsg.EnsureSuccessStatusCode();
            var response = await httpResponsemsg.Content.ReadFromJsonAsync<RegionsDto>();
            if (response != null)
            {
                return RedirectToAction("Index", "Regions");
            }
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            //ViewBag.Id = id;    
            var client =httpClientFactory.CreateClient();
            var GetSingleRegion = await client.GetFromJsonAsync<RegionsDto>($"https://localhost:7298/api/Region/{id.ToString()}");//getting data in form of model regiondto
            if (GetSingleRegion != null) { 
            return View(GetSingleRegion);
            
            }

            return View(null);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(RegionsDto regionsDto) {

            var client = httpClientFactory.CreateClient();
            var httpreqmsg = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7298/api/Region/{regionsDto.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(regionsDto), Encoding.UTF8, "application/json")
            };
            var Responsemsg= await client.SendAsync(httpreqmsg);    
             Responsemsg.EnsureSuccessStatusCode(); 
            var Response = await Responsemsg.Content.ReadFromJsonAsync<RegionsDto>();
            if (Response != null)
            {
                return RedirectToAction("Edit", "Regions");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionsDto regionsDto)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var response = await client.DeleteAsync($"https://localhost:7298/api/Region/{regionsDto.Id}");
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index","Regions")   ;
            }
            catch (Exception ex)
            {


            }
            return View("Edit");

        }
    }
}
