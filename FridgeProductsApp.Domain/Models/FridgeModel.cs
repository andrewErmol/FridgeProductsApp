using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProducts.Domain.Models
{
    public class FridgeModel
    {
        [Required(ErrorMessage = "FridgeModel Id is a required field")]
        public Guid Id;

        [Required(ErrorMessage = "Model name is a required field")]
        public string Name;

        public int YearOfRelease;
    }
}
