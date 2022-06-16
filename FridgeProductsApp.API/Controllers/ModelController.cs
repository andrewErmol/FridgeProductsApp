﻿using AutoMapper;
using FridgeProducts.Domain.Models;
using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.DTO.Model;
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
        private readonly IMapper _mapper;

        public ModelController(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllModels()
        {
            var models = _repository.Model.GetAllModels(trackChanges: false);
            return Ok(models);
        }

        [HttpGet("{id}", Name = "ModelId")]
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

        [HttpPost]
        public IActionResult CreateModel([FromBody]ModelForCreationDto model)
        {
            if (model == null)
            {
                _logger.LogError("ModelForCreationDto object sent from client is null.");
                return BadRequest("ModelForCreationDto object is null");
            }

            var modelToReturn = _mapper.Map<Model>(model);

            _repository.Model.CreateModel(modelToReturn);
            _repository.Save();

            return CreatedAtRoute("ModelId", new {id = modelToReturn.Id}, modelToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteModel(Guid id)
        {
            var model = _repository.Model.GetModel(id, trackChanges: false);

            if (model == null)
            {
                _logger.LogInfo($"Model with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Model.DeleteModel(model);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateModel(Guid id, [FromBody]ModelForUpdateDto model)
        {
            if (model == null)
            {
                _logger.LogError($"ModelForUpdateDto object sent from client is null.");
                return BadRequest("ModelForUpdateDto object is null");
            }

            var modelEntity = _repository.Model.GetModel(id, trackChanges: true);

            if (modelEntity == null)
            {
                _logger.LogInfo($"Model with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(model, modelEntity);
            _repository.Save();

            return NoContent();
        }
    }
}
