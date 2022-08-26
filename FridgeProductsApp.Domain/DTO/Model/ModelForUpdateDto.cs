using System.ComponentModel.DataAnnotations;

namespace FridgeProductsApp.Domain.DTO.Model
{
    public class ModelForUpdateDto
    {
        [Required(ErrorMessage = "FridgeModel Id is a required field")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Model name is a required field")]
        public string Name { get; set; }

        public int YearOfRelease { get; set; }
    }
}
