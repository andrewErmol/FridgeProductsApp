using Flurl.Http;
using Flurl.Http.Configuration;
using FridgeProductsApp.Domain.DTO.Model;
using FridgeProductsApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.MVC.Controllers
{
    public class ModelController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        private string _host = "https://localhost:5001/api/Model/";

        public ModelController(
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
            var result = await _flurlClient.Request("GetAllModels").GetJsonAsync<List<Model>>();

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
                var result = await _flurlClient.Request($"GetModel/{id}").GetJsonAsync<Model>();

                ViewData["Message"] = null;
                return View(result);
            }
            catch
            {
                ViewData["Message"] = "Model not found!";
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
        public async Task<IActionResult> Create(ModelForCreationDto model)
        {
            try
            {
                await _flurlClient.Request("CreateModel/").PostJsonAsync(model);

                ViewData["Message"] = $"Model was created";
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
        public async Task<IActionResult> Update(ModelForUpdateDto model)
        {
            try
            {
                await _flurlClient.Request("UpdateModel/").PutJsonAsync(model);

                ViewData["Message"] = $"Model {model.Name} was updated";
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
                await _flurlClient.Request($"DeleteModel/{id}").DeleteAsync();

                ViewData["Message"] = $"Model with id = {id} was deleted";
            }
            catch
            {
                ViewData["Message"] = "Model not found!";
            }
            return View();
        }
    }
}
