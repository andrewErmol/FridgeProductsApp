using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProducts.Domain.Models
{
    public class FridgeProducts
    {
        [Required(ErrorMessage = "FridgeProducts Id is a required field")]
        public Guid Id;

        [Required(ErrorMessage = "Product_id is a required field")]
        public Guid ProductId;

        [Required(ErrorMessage = "Fridge_if is a required field")]
        public Guid FridgeId;

        [Required(ErrorMessage = "Quantity is a required field")]
        public int Quantity;
    }
}
