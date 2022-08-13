using FridgeProductsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    DefaultQuantity = 1,
                    Url = "https://media.istockphoto.com/photos/blue-and-white-milk-box-picture-id489986642"
                },
                new Product
                {
                    Id = new Guid("9e66f3fd-3d2d-4fb3-a0b3-be5a917dc424"),
                    Name = "Apple",
                    DefaultQuantity = 4,
                    Url = "https://healthjade.com/wp-content/uploads/2017/10/apple-fruit.jpg"
                },
                new Product
                {
                    Id = new Guid("0764d13f-7aea-4d58-a087-774b61041a08"),
                    Name = "Banana",
                    DefaultQuantity = 3,
                    Url = "https://images.immediate.co.uk/production/volatile/sites/30/2017/01/Bananas-218094b-scaled.jpg"
                }
            );
        }
    }
}
