using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Domain.DTO.FridgeProduct
{
    public class AllFridgesWithQuantityProductsInsideDto
    {
        public Guid FridgeId { get; set; }
        public string FridgeName { get; set; }
        public int Quantity { get; set; }
    }
}
