using FridgeProductsApp.Domain.DTO.User;

namespace FridgeProductsApp.Contracts.IRepositories
{
    public interface IAuthenticationManagerRepository
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
