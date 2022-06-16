using FridgeProducts.Domain.Models;
using FridgeProductsApp.Contracts.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FridgeProductsApp.Database.Repository
{
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(FridgeProductsDbContext fridgeProductsDbContext)
            : base(fridgeProductsDbContext)
        {
        }

        public IEnumerable<Fridge> GetAllFridges(bool trackChanges) =>
            FindAll(trackChanges).Include(f => f.Model).OrderBy(f => f.Name).ToList();

        public Fridge GetFridge(Guid fridgeId, bool trackChanges) =>
            FindByCondition(f => f.Id.Equals(fridgeId), trackChanges).Include(f => f.Model)
            .SingleOrDefault();

        public void CreateFridge(Fridge fridge) => Create(fridge);

        public void DeleteFridge(Fridge fridge) => Delete(fridge);
    }
}
