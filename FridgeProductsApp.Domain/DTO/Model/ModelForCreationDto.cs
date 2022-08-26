using System.ComponentModel.DataAnnotations;

namespace FridgeProductsApp.Domain.DTO.Model
{
    public class ModelForCreationDto
    {
        [Required(ErrorMessage = "Model name is a required field")]
        public string Name { get; set; }

        public int YearOfRelease { get; set; }
    }
}
