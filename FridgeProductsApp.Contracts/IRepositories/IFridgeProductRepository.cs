using FridgeProducts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Contracts.IRepositories
{
    public interface IFridgeProductRepository
    {
        IEnumerable<FridgeProduct> GetAllFridgesProducts(bool trackChanges);
        FridgeProduct GetFridgeProduct(Guid fridgeProductId, bool trackChanges);
        IEnumerable<FridgeProduct> GetProductsInsideFridge(Guid fridgeId, bool trackChanges);
        void CreateFridgeProduct(FridgeProduct fridgeProduct);
        void DeleteFridgeProduct(FridgeProduct fridgeProduct);
    }
}
