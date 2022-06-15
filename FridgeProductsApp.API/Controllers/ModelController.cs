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
        public IActionResult GetAllModels()
        {
            var models = _repository.Model.GetAllModels(trackChanges: false);
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetModel(Guid id)
        {
            var model = _repository.Model.GetModel(id, trackChanges: false);
            if (model == null)
            {
                _logger.LogInfo($"Model with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(model);
            }
        }
    }
}
