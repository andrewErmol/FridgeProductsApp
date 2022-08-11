using FridgeProductsApp.Domain.Models;
using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.DTO.Fridge;
using FridgeProductsApp.Domain.DTO.FridgeProduct;
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

        public IEnumerable<AllFridgesWithQuantityProductsInsideDto> GetAllFridgesWithProductsQuantity(bool trackChanges)
        {
            List<AllFridgesWithQuantityProductsInsideDto> allFridgesWithQuantityProductsInsideDto = new List<AllFridgesWithQuantityProductsInsideDto>();

            List<FridgeProduct> fridgeProducts = FindAll(trackChanges).Include(fp => fp.Fridge).ThenInclude(fr => fr.Model).ToList();

            for(int i = 0; i < fridgeProducts.Count; i++)
            {
                bool isExist = false;
                int j = 0;

                for(j = 0; j < allFridgesWithQuantityProductsInsideDto.Count; j++)
                {
                    if (fridgeProducts[i].FridgeId == allFridgesWithQuantityProductsInsideDto[j].FridgeId)
                    {
                        isExist = true;
                        break;
                    }
                }

                if (isExist)
                {
                    allFridgesWithQuantityProductsInsideDto[j].Quantity += fridgeProducts[i].Quantity;
                }
                else
                {
                    allFridgesWithQuantityProductsInsideDto.Add(new AllFridgesWithQuantityProductsInsideDto
                    {
                        FridgeId = fridgeProducts[i].FridgeId,
                        Quantity = fridgeProducts[i].Quantity,
                        FridgeName = $"{fridgeProducts[i].Fridge.Name} {fridgeProducts[i].Fridge.Model.Name}"
                    });
                }
            }

            return allFridgesWithQuantityProductsInsideDto;
        }

        public IEnumerable<FridgeProduct> GetProductsInsideFridgesWithFirstLetterModelNameA(IEnumerable<Fridge> fridges, bool trackChanges) =>
            GetAllFridgesProducts(trackChanges).Where(fp => fridges.Select(f => f.Id).Contains(fp.FridgeId));

        public void DefinitionDefaultQuantity() =>
            FridgeProductsDbContext.Database.ExecuteSqlRaw("EXECUTE dbo.DefinitionDefaultQuantity");

        public IEnumerable<Fridge> GetFridgeProductsWithQuantityLessThanDefaultQuantity(IEnumerable<Fridge> fridges, bool trackChanges)
        {
            List<FridgeProduct> fridgeProducts = GetAllFridgesProducts(trackChanges).Where(fp => fp.Quantity < fp.Product.DefaultQuantity).ToList();
            return fridges.Where(f => fridgeProducts.Select(fp => fp.FridgeId).Contains(f.Id));
        }

        public IEnumerable<Fridge> GetFridgeProductsWithQuantityMoreThanDefaultQuantity(IEnumerable<Fridge> fridges, bool trackChanges)
        {
            List<FridgeProduct> fridgeProducts = GetAllFridgesProducts(trackChanges).Where(fp => fp.Quantity > fp.Product.DefaultQuantity).ToList();
            return fridges.Where(f => fridgeProducts.Select(fp => fp.FridgeId).Contains(f.Id));
        }

        public IEnumerable<FridgeWithQuantityNameOfProductsDto> GetFridgeProductsWithQuantityNameOfProductsWithQuantityMoreThanDefaultQuantity(List<Fridge> fridges, bool trackChanges)
        {
            List<FridgeWithQuantityNameOfProductsDto> fridgeWithQuantityNameOfProductsDto = new List<FridgeWithQuantityNameOfProductsDto>();
            List<FridgeProduct> fridgeProducts = GetAllFridgesProducts(trackChanges).Where(fp => fp.Quantity > fp.Product.DefaultQuantity).ToList();

            for (int i = 0; i < fridgeProducts.Count; i++)
            {
                bool isExist = false;

                int j = 0;
                int k = 0;

                for (j = 0; j < fridgeWithQuantityNameOfProductsDto.Count; j++)
                {
                    if (fridgeProducts[i].FridgeId == fridgeWithQuantityNameOfProductsDto[j].Id)
                    {
                        isExist = true;
                        break;
                    }
                }

                if (isExist)
                {
                    fridgeWithQuantityNameOfProductsDto[j].QuantityNameOfProducts++;
                }

                else
                {
                    for (k = 0; k < fridges.Count; k++)
                    {
                        if (fridges[k].Id == fridgeProducts[i].FridgeId)
                        {
                            break;
                        }
                    }

                    fridgeWithQuantityNameOfProductsDto.Add(new FridgeWithQuantityNameOfProductsDto
                    {
                        Id = fridgeProducts[i].FridgeId,
                        Name = fridges[k].Name,
                        OwnerName = fridges[k].OwnerName,
                        ModelName = fridges[k].Model.Name,
                        YearOfRelease = fridges[k].Model.YearOfRelease,
                        QuantityNameOfProducts = 1
                    });
                }
            }

            return fridgeWithQuantityNameOfProductsDto.Where(f => fridgeProducts.Select(fp => fp.FridgeId).Contains(f.Id));
        }

        public ProductsAndOwnerNameDto GetProductsAndOwnerNameWithMaxCountNameOfProduct(bool trackChanges)
        {
            List<FridgeProduct> fridgeProducts = GetAllFridgesProducts(trackChanges).ToList();
            List<string> productsNames = new List<string>();
            List<string> productsNamesForOneFridge = new List<string>();
            int k = 0;

            for (int i = 0; i < fridgeProducts.Count; i++)
            {
                productsNamesForOneFridge = new List<string>();
                for (int j = 0; j < fridgeProducts.Count; j++)
                {
                    if (fridgeProducts[i].FridgeId == fridgeProducts[j].FridgeId)
                    {
                        productsNamesForOneFridge.Add(fridgeProducts[j].Product.Name);
                    }
                }
                if (productsNames.Count < productsNamesForOneFridge.Count)
                {
                    productsNames = productsNamesForOneFridge;
                    k = i;
                }
            }

            ProductsAndOwnerNameDto productsAndOwnerName = new ProductsAndOwnerNameDto
            {
                Id = fridgeProducts[k].FridgeId,
                FridgeName = fridgeProducts[k].Fridge.Name,
                OwnerName = fridgeProducts[k].Fridge.OwnerName,
                Products = productsNames
            };

            return productsAndOwnerName;
        }
    }
}
