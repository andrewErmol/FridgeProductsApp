using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Domain.Models
{
    public class Model
    {
        [Required(ErrorMessage = "FridgeModel Id is a required field")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Model name is a required field")]
        public string Name { get; set; }

        public int YearOfRelease { get; set; }
    }
}
