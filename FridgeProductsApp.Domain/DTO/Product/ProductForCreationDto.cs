using System.ComponentModel.DataAnnotations;

namespace FridgeProductsApp.Domain.DTO.Product
{
    public class ProductForCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; }

        public int DefaultQuantity { get; set; }

        public string Url { get; set; }
    }
}
