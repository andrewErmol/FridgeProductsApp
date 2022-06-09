using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProducts.Domain.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Products Id is a required field")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; }

        public int DefaultQuantity { get; set; }
    }
}
