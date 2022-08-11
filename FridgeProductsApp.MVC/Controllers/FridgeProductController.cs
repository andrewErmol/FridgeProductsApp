using Flurl.Http;
using Flurl.Http.Configuration;
using FridgeProductsApp.Domain.DTO.FridgeProduct;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.MVC.Controllers
{
    public class FridgeProductController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        private string _host = "https://localhost:5001/api/FridgeProduct/";

        public FridgeProductController(
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
            var result = await _flurlClient.Request("GetAllFridgesProducts").GetJsonAsync<List<FridgeProductDto>>();

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
                var result = await _flurlClient.Request($"GetFridgeProduct/{id}").GetJsonAsync<FridgeProductDto>();

                ViewData["Message"] = null;
                return View(result);
            }
            catch
            {
                ViewData["Message"] = "Fridge product not found!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FridgeProductForCreationDto fridgeProduct)
        {
            try
            {
                await _flurlClient.Request("CreateFridgeProduct/").PostJsonAsync(fridgeProduct);

                ViewData["Message"] = $"FridgeProduct was created";
            }
            catch
            {
                ViewData["Message"] = null;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(FridgeProductForUpdateDto fridgeProduct)
        {
            try
            {
                await _flurlClient.Request("UpdateFridgeProduct/").PutJsonAsync(fridgeProduct);

                ViewData["Message"] = $"FridgeProduct with Id = {fridgeProduct.Id} was updated";
            }
            catch
            {
                ViewData["Message"] = null;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _flurlClient.Request($"DeleteFridgeProduct/{id}").DeleteAsync();

                ViewData["Message"] = $"FridgeProduct with Id = {id} was deleted";
            }
            catch
            {
                ViewData["Message"] = "FridgeProduct not found!";
            }
            return View();
        }
    }
}
