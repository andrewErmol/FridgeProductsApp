using FridgeProductsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeProductsApp.Domain.Configuration
{
    public class FridgeConfiguration : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasData
            (
                new Fridge
                {
                    Id = new Guid("3f2966cc-c0d1-4c07-858d-e5191ef458a0"),
                    Name = "AlpicAir",
                    OwnerName = "Ladushka",
                    ModelId = new Guid("69682051-c967-4628-bdf0-ac7c06bd6113")
                },
                new Fridge
                {
                    Id = new Guid("5cc31465-a342-4b0f-a28c-6cd400a36bf5"),
                    Name = "Atlant",
                    OwnerName = "Andrew",
                    ModelId = new Guid("057f5256-f967-4dcb-ad44-6f8911998ed9")
                },
                new Fridge
                {
                    Id = new Guid("9818e43c-3e7f-48cd-9a2b-f2ca368d6efe"),
                    Name = "Philips",
                    OwnerName = "Leha",
                    ModelId = new Guid("94df093d-97ea-48a7-a0a4-f57904a95743")
                }
            );
        }
    }
}
