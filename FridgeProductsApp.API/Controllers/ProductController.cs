using AutoMapper;
using FridgeProductsApp.Domain.Models;
using FridgeProductsApp.Contracts;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.DTO.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductController(IRepositoryManager repository, 
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _repository.Product.GetAllProducts(trackChanges: false);
            return Ok(products);
        }

        [HttpGet("{id}", Name = "ProductId")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _repository.Product.GetProduct(id, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductForCreationDto product)
        {
            if (product == null)
            {
                _logger.LogError("ProductForCreationDto object sent from client is null.");
                return BadRequest("ProductForCreationDto object is null");
            }

            var productToReturn = _mapper.Map<Product>(product);

            _repository.Product.CreateProduct(productToReturn);
            _repository.Save();

            return CreatedAtRoute("ModelId", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _repository.Product.GetProduct(id, trackChanges: false);

            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Product.DeleteProduct(product);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody]ProductForUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError($"ProductForUpdateDto object sent from client is null.");
                return BadRequest("ProductForUpdateDto object is null");
            }

            var productEntity = _repository.Product.GetProduct(id, trackChanges: true);

            if (productEntity == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(product, productEntity);
            _repository.Save();

            return NoContent();
        }
    }
}
