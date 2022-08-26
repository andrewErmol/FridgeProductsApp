using FridgeProductsApp.Domain.Models;

namespace FridgeProductsApp.Contracts.IRepositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product GetProduct(Guid productId, bool trackChanges);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
