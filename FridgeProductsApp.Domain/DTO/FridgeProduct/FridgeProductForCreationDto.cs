﻿using System.ComponentModel.DataAnnotations;

namespace FridgeProductsApp.Domain.DTO.FridgeProduct
{
    public class FridgeProductForCreationDto
    {
        [Required(ErrorMessage = "Product_id is a required field")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Fridge_if is a required field")]
        public Guid FridgeId { get; set; }

        [Required(ErrorMessage = "Quantity is a required field")]
        public int Quantity { get; set; }
    }
}
