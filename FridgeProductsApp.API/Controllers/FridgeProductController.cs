using AutoMapper;
using FridgeProductsApp.Domain.Models;
using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.DTO.Fridge;
using FridgeProductsApp.Domain.DTO.FridgeProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FridgeProductsApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class FridgeProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FridgeProductController(IRepositoryManager repository, 
            ILoggerManager logger,
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

        [HttpPut]
        public IActionResult UpdateFridgeProduct([FromBody]FridgeProductForUpdateDto fridgeProduct)
        {
            if (fridgeProduct == null)
            {
                _logger.LogError($"FridgeProductForUpdateDto object sent from client is null.");
                return BadRequest("FridgeProductForUpdateDto object is null");
            }

            var fridgeProductEntity = _repository.FridgeProduct.GetFridgeProduct(fridgeProduct.Id, trackChanges: true);

            if (fridgeProductEntity == null)
            {
                _logger.LogInfo($"FridgeProduct with id: {fridgeProduct.Id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(fridgeProduct, fridgeProductEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllFridgesWithProductsQuantity()
        {
            var fridgesProducts = _repository.FridgeProduct.GetAllFridgesWithProductsQuantity(false);

            return Ok(fridgesProducts);
        }

        [HttpGet]
        public IActionResult GetProductsInsideFridgesByFirstLetterOfModelA()
        {
            var selectedFridges = _repository.Fridge.GetFridgesByFirstLetterOfModelA(trackChanges: false);

            if (selectedFridges.Count() == 0)
            {
                return Ok("Fridges with first letter A or a not found.");
            }

            var selectedFridgeProduct = _repository.FridgeProduct.GetProductsInsideFridgesWithFirstLetterModelNameA(selectedFridges, trackChanges: false);
            var fridgeProductsDto = _mapper.Map<IEnumerable<FridgeProductDto>>(selectedFridgeProduct);

            return Ok(fridgeProductsDto);
        }

        [HttpPost]
        public void DefinitionDefaultQuantity()
        {
            _repository.FridgeProduct.DefinitionDefaultQuantity();
        }

        [HttpGet]
        public IActionResult GetFridgesWithQuantityLessThanDeaultQuantity()
        {
            var allFridges = _repository.Fridge.GetAllFridges(false);
            var fridges = _repository.FridgeProduct.GetFridgeProductsWithQuantityLessThanDefaultQuantity(allFridges, trackChanges: false);

            if (fridges.Count() == 0)
            {
                _logger.LogInfo("Fridges with quantity products less than default quantity of this products.");
                return NotFound();
            }

            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);

            return Ok(fridgesDto);
        }

        [HttpGet]
        public IActionResult GetFridgesWithQuantityMoreThanDeaultQuantity()
        {
            var allFridges = _repository.Fridge.GetAllFridges(false);
            var fridges = _repository.FridgeProduct.GetFridgeProductsWithQuantityMoreThanDefaultQuantity(allFridges, trackChanges: false);

            if (fridges.Count() == 0)
            {
                _logger.LogInfo("Fridges with quantity products less than default quantity of this products.");
                return NotFound();
            }

            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);

            return Ok(fridgesDto);
        }

        [HttpGet]
        public IActionResult GetFridgeProductsWithQuantityNameOfProductsWithQuantityMoreThanDefaultQuantity()
        {
            var allFridges = _repository.Fridge.GetAllFridges(false).ToList();
            var fridges = _repository.FridgeProduct.GetFridgeProductsWithQuantityNameOfProductsWithQuantityMoreThanDefaultQuantity(allFridges, trackChanges: false);

            if (fridges.Count() == 0)
            {
                _logger.LogInfo("Fridges with quantity products less than default quantity of this products.");
                return NotFound();
            }

            return Ok(fridges);
        }

        [HttpGet]
        public IActionResult GetProductsAndOwnerNameWithMaxCountNameOfProduct()
        {
            var objectToReturn = _repository.FridgeProduct.GetProductsAndOwnerNameWithMaxCountNameOfProduct(trackChanges: false);

            if (objectToReturn == null)
            {
                _logger.LogInfo("In the database not Found fridges");
                return NotFound();
            }

            return Ok(objectToReturn);
        }
    }
}
