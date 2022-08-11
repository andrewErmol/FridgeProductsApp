using FridgeProductsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Domain.Configuration
{
    public class FridgeProductConfiguration : IEntityTypeConfiguration<FridgeProduct>
    {
        public void Configure(EntityTypeBuilder<FridgeProduct> builder)
        {
            builder.HasData
            (
                new FridgeProduct
                {
                    Id = new Guid("c2ae232e-ff5b-4965-b474-2d1095b6c8ce"),
                    ProductId = new Guid("71ef7bc0-300b-40cc-b2e3-07123bec1137"),
                    FridgeId = new Guid("3f2966cc-c0d1-4c07-858d-e5191ef458a0"),
                    Quantity = 2
                },
                new FridgeProduct
                {
                    Id = new Guid("f1cfc80d-f296-4184-b3b7-ef183256957d"),
                    ProductId = new Guid("9e66f3fd-3d2d-4fb3-a0b3-be5a917dc424"),
                    FridgeId = new Guid("5cc31465-a342-4b0f-a28c-6cd400a36bf5"),
                    Quantity = 3
                },
                new FridgeProduct
                {
                    Id = new Guid("d2544737-b1d4-47a6-9d89-125c6f200809"),
                    ProductId = new Guid("0764d13f-7aea-4d58-a087-774b61041a08"),
                    FridgeId = new Guid("9818e43c-3e7f-48cd-9a2b-f2ca368d6efe")
                }
            );
        }
    }
}
