﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Domain.DTO
{
    public class FridgeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Model { get; set; }
    }
}
