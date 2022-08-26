using FridgeProductsApp.Domain.Models;

namespace FridgeProductsApp.Contracts.IRepositories
{
    public interface IModelRepository
    {
        IEnumerable<Model> GetAllModels(bool trackChanges);
        Model GetModel(Guid modelId, bool trackChanges);
        void CreateModel(Model model);
        void DeleteModel(Model model);
    }
}
