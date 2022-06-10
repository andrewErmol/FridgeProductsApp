using FridgeProducts.Domain.Models;
using FridgeProductsApp.Contracts.IRepositories;

namespace FridgeProductsApp.Database.Repository
{
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(FridgeProductsDbContext fridgeProductsDbContext)
            : base(fridgeProductsDbContext)
        {
        }

        public IEnumerable<Fridge> GetAllFridges(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(f => f.Name).ToList();
    }
}
