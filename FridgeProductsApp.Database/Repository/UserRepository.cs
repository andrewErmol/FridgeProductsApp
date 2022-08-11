using FridgeProductsApp.Domain.Models;
using FridgeProductsApp.Contracts.IRepositories;

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
