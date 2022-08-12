﻿using System.ComponentModel.DataAnnotations;

namespace FridgeProductsApp.Domain.Models
{
    public class Fridge
    {
        [Required(ErrorMessage = "Fridge Id is a required field")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fridge name is a required field")]
        public string Name { get; set; }

        public string OwnerName { get; set; }

        [Required(ErrorMessage = "Model_id is a required field")]
        public Guid ModelId { get; set; }

        public virtual Model Model { get; set; }
    }
}
