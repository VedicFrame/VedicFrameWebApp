using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using VedicFrameWebApp.Models;

namespace VedicFrameWebApp.Controllers
{
        public class APIController : Controller
        {
            private readonly ApiService _apiService;

            public APIController(ApiService apiService)
            {
                _apiService = apiService;
            }

            public async Task<IActionResult> Index()
            {
                var apiData = await _apiService.GetApiDataAsync();

                List<Book> result = new List<Book>();

                result = JsonConvert.DeserializeObject<List<Book>>(apiData);

                return View(result);
            }
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
}
