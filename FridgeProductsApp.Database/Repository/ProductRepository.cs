using FridgeProducts.Domain.Models;
using FridgeProductsApp.Contracts.IRepositories;

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
    }
}
