using Flurl.Http;
using Flurl.Http.Configuration;
using FridgeProductsApp.Domain.DTO.Product;
using FridgeProductsApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.MVC.Controllers
{
    [Route("[controller]/[action]/")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        private string _host = "https://localhost:5001/api/Product/";

        public ProductController(
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

        #region CRUD
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _flurlClient.Request("GetAllProducts").GetJsonAsync<List<Product>>();

                return View(result);
            }
            catch
            {
                ViewData["Message"] = "Product not found!";
                return View();
            }
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
                var result = await _flurlClient.Request($"GetProduct/{id}").GetJsonAsync<Product>();

                ViewData["Message"] = null;
                return View(result);
            }
            catch
            {
                ViewData["Message"] = "Product not found!";
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
        public async Task<IActionResult> Create(ProductForCreationDto product)
        {
            try
            {
                await _flurlClient.Request("CreateProduct/").PostJsonAsync(product);

                ViewData["Message"] = $"Product was created";
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
        public async Task<IActionResult> Update(ProductForUpdateDto product)
        {
            try
            {
                await _flurlClient.Request("UpdateProduct/").PutJsonAsync(product);

                ViewData["Message"] = $"Product {product.Name} was updated";
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
                await _flurlClient.Request($"DeleteProduct/{id}").DeleteAsync();

                ViewData["Message"] = $"Product with id = {id} was deleted";
            }
            catch
            {
                ViewData["Message"] = "Product not found!";
            }
            return View();
        }
        #endregion
    }
}
