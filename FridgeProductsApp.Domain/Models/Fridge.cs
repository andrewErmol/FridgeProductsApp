using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProducts.Domain.Models
{
    public class Fridge
    {
        [Required(ErrorMessage = "Fridge Id is a required field")]
        public Guid Id;

        [Required(ErrorMessage = "Fridge name is a required field")]
        public string Name;

        public string OwnerName;

        [Required(ErrorMessage = "Model_id is a required field")]
        public Guid ModelId;
    }
}
