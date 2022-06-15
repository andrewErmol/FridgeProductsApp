using AutoMapper;
using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FridgeProductsApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public IActionResult GetAllFridgesProducts()
        {
            var fridgesProducts = _repository.FridgeProduct.GetAllFridgesProducts(trackChanges: false);
            var fridgesProductsDto = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgesProducts);

            return Ok(fridgesProductsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetFridgeProduct(Guid id)
        {
            var fridgeProduct = _repository.FridgeProduct.GetProductsInsideFridge(id, trackChanges: false);
            if (fridgeProduct == null)
            {
                _logger.LogInfo($"FridgeProduct with id: {id} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                var fridgeProductDto = _mapper.Map<FridgeProductDto>(fridgeProduct);
                return Ok(fridgeProductDto);
            }
        }

        [HttpGet("{fridgeId}")]
        public IActionResult GetProductsInsideFridge(Guid fridgeId)
        {
            var fridgeProducts = _repository.FridgeProduct.GetProductsInsideFridge(fridgeId, trackChanges: false);
            if (fridgeProducts == null)
            {
                _logger.LogInfo($"FridgeProduct with fridgeId: {fridgeId} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                var fridgeProductsDto = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgeProducts);
                return Ok(fridgeProductsDto);
            }
        }
    }
}
