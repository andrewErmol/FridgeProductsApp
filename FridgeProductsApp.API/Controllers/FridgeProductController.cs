using AutoMapper;
using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FridgeProductsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FridgeProductController(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFridgesProducts()
        {
            try
            {
                var fridgesProducts = _repository.FridgeProduct.GetAllFridgesProducts(trackChanges: false);
                var fridgesProductsDto = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgesProducts);
                
                return Ok(fridgesProductsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetFridgesProducts)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
