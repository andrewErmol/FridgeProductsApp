using System.ComponentModel.DataAnnotations;

namespace FridgeProductsApp.Domain.DTO.FridgeProduct
{
    public class FridgeProductForUpdateDto
    {
        [Required(ErrorMessage = "FridgeProducts Id is a required field")]
        public Guid Id { get; set; }
                
        [Required(ErrorMessage = "Quantity is a required field")]
        public int Quantity { get; set; }
    }
}
