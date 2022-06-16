using FridgeProducts.Domain.Models;
using FridgeProductsApp.Contracts.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FridgeProductsApp.Database.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(FridgeProductsDbContext fridgeProductsDbContext)
            : base(fridgeProductsDbContext)
        {
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(f => f.Name).ToList();

        public Product GetProduct(Guid productId, bool trackChanges) =>
            FindByCondition(p => p.Id.Equals(productId), trackChanges)
            .SingleOrDefault();

        public void CreateProduct(Product product) => Create(product);

        public void DeleteProduct(Product product) => Delete(product);
    }
}
