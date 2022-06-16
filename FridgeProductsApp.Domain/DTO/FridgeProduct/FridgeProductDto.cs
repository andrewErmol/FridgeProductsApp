using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Domain.DTO.FridgeProduct
{
    public class FridgeProductDto
    {
        public Guid Id { get; set; }
        public string FridgeName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
