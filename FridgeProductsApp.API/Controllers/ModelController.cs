using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ModelController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetModels()
        {
            try
            {
                var models = _repository.Model.GetAllModels(trackChanges: false);
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetModels)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
