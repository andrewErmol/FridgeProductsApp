using FridgeProductsApp.Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Contracts.IRepositories
{
    public interface IAuthenticationManagerRepository
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
