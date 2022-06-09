using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProducts.Domain.Models
{
    public class FridgeProduct
    {
        [Required(ErrorMessage = "FridgeProducts Id is a required field")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product_id is a required field")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Fridge_if is a required field")]
        public Guid FridgeId { get; set; }

        [Required(ErrorMessage = "Quantity is a required field")]
        public int Quantity { get; set; }

        public virtual Fridge Fridge { get; set; }

        public virtual Product Product { get; set; }
    }
}
