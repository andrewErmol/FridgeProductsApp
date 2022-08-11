using Flurl.Http;
using Flurl.Http.Configuration;
using FridgeProductsApp.Domain.DTO.Fridge;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.MVC.Controllers
{
    [Route("[controller]/[action]/")]
    public class FridgeController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        private string _host = "https://localhost:5001/api/Fridge/";

        public FridgeController(
            IFlurlClientFactory flurlClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _flurlClient = flurlClientFactory.Get(_host);
            _contextAccessor = httpContextAccessor;

            var token = _contextAccessor.HttpContext.Request.Cookies["X-Access-Token"];

            if (token != null)
                _flurlClient.WithOAuthBearerToken(token);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _flurlClient.Request("GetAllFridges").GetJsonAsync<List<FridgeDto>>();

            return View(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _flurlClient.Request($"GetFridge/{id}").GetJsonAsync<FridgeDto>();

                ViewData["Message"] = null;
                return View(result);
            }
            catch
            {
                ViewData["Message"] = "Fridge not found!";
                return View();
            }
        }
    }
}
