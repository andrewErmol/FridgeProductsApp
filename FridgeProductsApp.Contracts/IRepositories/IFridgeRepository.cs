using FridgeProducts.Domain.Models;

namespace FridgeProductsApp.Contracts.IRepositories
{
    public interface IFridgeRepository
    {
        IEnumerable<Fridge> GetAllFridges(bool trackChanges);
        Fridge GetFridge(Guid fridgeId, bool trackChanges);
        void CreateFridge(Fridge fridge);
        void DeleteFridge(Fridge fridge);
        IEnumerable<Fridge> GetFridgesByFirstLetterOfModelA(bool trackChanges);
        int GetYearOfReleaseForFridgeWithMaxProductsCount();
    }
}
