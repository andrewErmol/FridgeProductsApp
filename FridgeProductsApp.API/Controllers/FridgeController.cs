using AutoMapper;
using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FridgeController(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFridges()
        {
            try
            {
                var fridges = _repository.Fridge.GetAllFridges(trackChanges: false);
                var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);
                
                return Ok(fridgesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetFridges)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
