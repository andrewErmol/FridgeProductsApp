using AutoMapper;
using FridgeProducts.Domain.Models;
using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.DTO.FridgeProduct;
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

        [HttpGet("{id}", Name = "FridgeProductId")]
        public IActionResult GetFridgeProduct(Guid id)
        {
            var fridgeProduct = _repository.FridgeProduct.GetFridgeProduct(id, trackChanges: false);
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

        [HttpPost]
        public IActionResult CreateFridgeProduct([FromBody]FridgeProductForCreationDto fridgeProduct)
        {
            if (fridgeProduct == null)
            {
                _logger.LogError("FridgeProductForCreationDto object sent from client is null.");
                return BadRequest("FridgeProductForCreationDto object is null");
            }

            var fridgeProductEntity = _mapper.Map<FridgeProduct>(fridgeProduct);

            _repository.FridgeProduct.CreateFridgeProduct(fridgeProductEntity);
            _repository.Save();

            var fridgeProductToReturn = _mapper.Map<FridgeProductDto>(fridgeProductEntity);

            return CreatedAtRoute("FridgeProductId", new { id = fridgeProductToReturn.Id },
                fridgeProductToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFridgeProduct(Guid id)
        {
            var fridgeProduct = _repository.FridgeProduct.GetFridgeProduct(id, trackChanges: false);
            
            if (fridgeProduct == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.FridgeProduct.DeleteFridgeProduct(fridgeProduct);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFridgeProduct(Guid id, [FromBody]FridgeProductForUpdateDto fridgeProduct)
        {
            if (fridgeProduct == null)
            {
                _logger.LogError($"FridgeProductForUpdateDto object sent from client is null.");
                return BadRequest("FridgeProductForUpdateDto object is null");
            }

            var fridgeProductEntity = _repository.FridgeProduct.GetFridgeProduct(id, trackChanges: true);

            if (fridgeProductEntity == null)
            {
                _logger.LogInfo($"FridgeProduct with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(fridgeProduct, fridgeProductEntity);
            _repository.Save();

            return NoContent();
        }
    }
}
