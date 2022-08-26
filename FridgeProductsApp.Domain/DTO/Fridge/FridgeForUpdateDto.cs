using System.ComponentModel.DataAnnotations;

namespace FridgeProductsApp.Domain.DTO.Fridge
{
    public class FridgeForUpdateDto
    {
        [Required(ErrorMessage = "Fridge Id is a required field")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge name is a required field")]
        public string Name { get; set; }

        public string OwnerName { get; set; }
    }
}
