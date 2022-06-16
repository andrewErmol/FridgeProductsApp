using FridgeProducts.Domain.Models;
using FridgeProductsApp.Contracts.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FridgeProductsApp.Database.Repository
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(FridgeProductsDbContext fridgeProductsDbContext)
            : base(fridgeProductsDbContext)
        {
        }

        public IEnumerable<FridgeProduct> GetAllFridgesProducts(bool trackChanges) => 
            FindAll(trackChanges).Include(fp => fp.Fridge).Include(fp => fp.Product).ToList();

        public FridgeProduct GetFridgeProduct(Guid fridgeProductId, bool trackChanges) =>
            FindByCondition(fp => fp.Id.Equals(fridgeProductId), trackChanges)
            .Include(fp => fp.Fridge).Include(fp => fp.Product)
            .SingleOrDefault();

        public IEnumerable<FridgeProduct> GetProductsInsideFridge(Guid fridgeId, bool trackChanges) =>
            FindAll(trackChanges).Where(fp => fp.FridgeId == fridgeId)
            .Include(fp => fp.Fridge).Include(fp => fp.Product).ToList();

        public void CreateFridgeProduct(FridgeProduct fridgeProduct) => Create(fridgeProduct);

        public void DeleteFridgeProduct(FridgeProduct fridgeProduct) => Delete(fridgeProduct);
    }
}
