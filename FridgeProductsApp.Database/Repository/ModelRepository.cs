using FridgeProducts.Domain.Models;
using FridgeProductsApp.Contracts.IRepositories;

namespace FridgeProductsApp.Database.Repository
{
    public class ModelRepository : RepositoryBase<Model>, IModelRepository
    {
        public ModelRepository(FridgeProductsDbContext fridgeProductsDbContext)
            : base(fridgeProductsDbContext)
        {
        }

        public IEnumerable<Model> GetAllModels(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(f => f.Name).ToList();
        
        public Model GetModel(Guid modelId, bool trackChanges) =>
            FindByCondition(m => m.Id.Equals(modelId), trackChanges)
            .SingleOrDefault();
    }
}
