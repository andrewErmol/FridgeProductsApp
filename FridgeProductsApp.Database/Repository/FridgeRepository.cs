using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.Models;
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

        public IEnumerable<Fridge> GetFridgesByFirstLetterOfModelA(bool trackChanges) =>
            GetAllFridges(trackChanges).Where(f => f.Model.Name[0] == 'A' || f.Model.Name[0] == 'a');

        public int GetYearOfReleaseForFridgeWithMaxProductsCount()
        {
            var param = new Microsoft.Data.SqlClient.SqlParameter
            {
                ParameterName = "@year",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
                Size = 50
            };
            return (int)ExecuteScalar("dbo.GetYearOfReleaseForFridgeWithMaxProductsCount @year OUT", param);
        }
    }
}
