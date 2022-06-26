using FridgeProducts.Domain.Models;
using FridgeProductsApp.Domain.DTO.Fridge;
using FridgeProductsApp.Domain.DTO.FridgeProduct;
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
        IEnumerable<AllFridgesWithQuantityProductsInsideDto> GetAllFridgesWithProductsQuantity(bool trackChanges);
        IEnumerable<FridgeProduct> GetProductsInsideFridgesWithFirstLetterModelNameA(IEnumerable<Fridge> fridges, bool trackChanges);
        void DefinitionDefaultQuantity();
        IEnumerable<Fridge> GetFridgeProductsWithQuantityLessThanDefaultQuantity(IEnumerable<Fridge> fridges, bool trackChanges);
        IEnumerable<Fridge> GetFridgeProductsWithQuantityMoreThanDefaultQuantity(IEnumerable<Fridge> fridges, bool trackChanges);
        IEnumerable<FridgeWithQuantityNameOfProductsDto> GetFridgeProductsWithQuantityNameOfProductsWithQuantityMoreThanDefaultQuantity(List<Fridge> fridges, bool trackChanges);
        ProductsAndOwnerNameDto GetProductsAndOwnerNameWithMaxCountNameOfProduct(bool trackChanges);
    }
}
