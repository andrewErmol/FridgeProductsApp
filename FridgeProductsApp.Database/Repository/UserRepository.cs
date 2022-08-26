using FridgeProductsApp.Contracts.IRepositories;
using FridgeProductsApp.Domain.Models;

namespace FridgeProductsApp.Database.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(FridgeProductsDbContext fridgeProductsDbContext)
            : base(fridgeProductsDbContext)
        {
        }
    }
}
