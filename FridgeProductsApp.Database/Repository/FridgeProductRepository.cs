using FridgeProducts.Domain.Models;
using FridgeProductsApp.Contracts.IRepositories;

namespace FridgeProductsApp.Database.Repository
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(FridgeProductsDbContext fridgeProductsDbContext)
            : base(fridgeProductsDbContext)
        {
        }

        public IEnumerable<FridgeProduct> GetAllFridgesProducts(bool trackChanges) => 
            FindAll(trackChanges).ToList();
    }
}
