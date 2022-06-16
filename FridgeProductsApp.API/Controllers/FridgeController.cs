﻿using AutoMapper;
using FridgeProducts.Domain.Models;
using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.DTO.Fridge;
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
        public IActionResult GetAllFridges()
        {
            var fridges = _repository.Fridge.GetAllFridges(trackChanges: false);
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);

            return Ok(fridgesDto);
        }

        [HttpGet("{id}", Name = "FridgeId")]
        public IActionResult GetFridge(Guid id)
        {
            var fridge = _repository.Fridge.GetFridge(id, trackChanges: false);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var fridgeDto = _mapper.Map<FridgeDto>(fridge);
                return Ok(fridgeDto);
            }
        }

        [HttpPost]
        public IActionResult CreateFridge([FromBody]FridgeForCreationDto fridge)
        {
            if(fridge == null)
            {
                _logger.LogError("FridgeForCreationDto object sent from client is null.");
                return BadRequest("FridgeForCreationDto object is null");
            }

            var fridgeEntity = _mapper.Map<Fridge>(fridge);

            _repository.Fridge.CreateFridge(fridgeEntity);
            _repository.Save();

            var fridgeToReturn = _mapper.Map<FridgeDto>(fridgeEntity);

            return CreatedAtRoute("FridgeId", new { id = fridgeToReturn.Id }, fridgeToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFridge(Guid id)
        {
            var fridge = _repository.Fridge.GetFridge(id, trackChanges: false);

            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Fridge.DeleteFridge(fridge);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFridge(Guid id, [FromBody]FridgeForUpdateDto fridge)
        {
            if (fridge == null)
            {
                _logger.LogError($"FridgeForUpdateDto object sent from client is null.");
                return BadRequest("FridgeForUpdateDto object is null");
            }

            var fridgeEntity = _repository.Fridge.GetFridge(id, trackChanges: true);

            if (fridgeEntity == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(fridge, fridgeEntity);
            _repository.Save();

            return NoContent();
        }
    }
}
