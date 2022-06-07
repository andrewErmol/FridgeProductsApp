using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProducts.Domain.Models
{
    public class User
    {
        [Required(ErrorMessage = "Login is a required field")]
        public string Login;

        [Required(ErrorMessage = "Password is a required field")]
        public string Password;
    }
}
