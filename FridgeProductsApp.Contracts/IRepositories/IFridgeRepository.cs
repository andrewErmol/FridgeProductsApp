using FridgeProducts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
