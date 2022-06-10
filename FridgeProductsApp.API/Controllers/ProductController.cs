using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ProductController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _repository.FridgeProduct.GetAllFridgesProducts(trackChanges: false);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetProducts)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
