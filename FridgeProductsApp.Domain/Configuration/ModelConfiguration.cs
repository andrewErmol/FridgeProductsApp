using FridgeProducts.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Domain.Configuration
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasData
            (
                new Model
                {
                    Id = new Guid("69682051-c967-4628-bdf0-ac7c06bd6113"),
                    Name = "Milk",
                    YearOfRelease = 1
                },
                new Model
                {
                    Id = new Guid("057f5256-f967-4dcb-ad44-6f8911998ed9"),
                    Name = "Apple",
                    YearOfRelease = 4
                },
                new Model
                {
                    Id = new Guid("94df093d-97ea-48a7-a0a4-f57904a95743"),
                    Name = "Banana",
                    YearOfRelease = 3
                }
            );
        }
    }
}
