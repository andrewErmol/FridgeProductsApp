using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public FridgeProductController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetFridgesProducts()
        {
            try
            {
                var fridgesProducts = _repository.FridgeProduct.GetAllFridgesProducts(trackChanges: false);
                return Ok(fridgesProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetFridgesProducts)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
