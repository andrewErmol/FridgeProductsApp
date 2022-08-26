using FridgeProductsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    Name = "145-buckavi62687-4521",
                    YearOfRelease = 1123
                },
                new Model
                {
                    Id = new Guid("057f5256-f967-4dcb-ad44-6f8911998ed9"),
                    Name = "bukaviicifari6",
                    YearOfRelease = 1985
                },
                new Model
                {
                    Id = new Guid("94df093d-97ea-48a7-a0a4-f57904a95743"),
                    Name = "prostocifari123",
                    YearOfRelease = 2018
                }
            );
        }
    }
}
