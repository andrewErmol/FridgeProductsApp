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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
            (
                new Product
                {
                    Id = new Guid("71ef7bc0-300b-40cc-b2e3-07123bec1137"),
                    Name = "Milk",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = new Guid("9e66f3fd-3d2d-4fb3-a0b3-be5a917dc424"),
                    Name = "Apple",
                    DefaultQuantity = 4
                },
                new Product
                {
                    Id = new Guid("0764d13f-7aea-4d58-a087-774b61041a08"),
                    Name = "Banana",
                    DefaultQuantity = 3
                }
            );
        }
    }
}
