﻿// <auto-generated />
using System;
using FridgeProductsApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FridgeProductsApp.Database.Migrations
{
    [DbContext(typeof(FridgeProductsDbContext))]
    [Migration("20220609085955_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FridgeProducts.Domain.Models.Fridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Fridges");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f2966cc-c0d1-4c07-858d-e5191ef458a0"),
                            ModelId = new Guid("69682051-c967-4628-bdf0-ac7c06bd6113"),
                            Name = "AlpicAir",
                            OwnerName = "Ladushka"
                        },
                        new
                        {
                            Id = new Guid("5cc31465-a342-4b0f-a28c-6cd400a36bf5"),
                            ModelId = new Guid("057f5256-f967-4dcb-ad44-6f8911998ed9"),
                            Name = "Atlant",
                            OwnerName = "Andrew"
                        },
                        new
                        {
                            Id = new Guid("9818e43c-3e7f-48cd-9a2b-f2ca368d6efe"),
                            ModelId = new Guid("94df093d-97ea-48a7-a0a4-f57904a95743"),
                            Name = "Philips",
                            OwnerName = "Leha"
                        });
                });

            modelBuilder.Entity("FridgeProducts.Domain.Models.FridgeProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FridgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.HasIndex("ProductId");

                    b.ToTable("FridgeProducts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2ae232e-ff5b-4965-b474-2d1095b6c8ce"),
                            FridgeId = new Guid("3f2966cc-c0d1-4c07-858d-e5191ef458a0"),
                            ProductId = new Guid("71ef7bc0-300b-40cc-b2e3-07123bec1137"),
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("f1cfc80d-f296-4184-b3b7-ef183256957d"),
                            FridgeId = new Guid("5cc31465-a342-4b0f-a28c-6cd400a36bf5"),
                            ProductId = new Guid("9e66f3fd-3d2d-4fb3-a0b3-be5a917dc424"),
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("d2544737-b1d4-47a6-9d89-125c6f200809"),
                            FridgeId = new Guid("9818e43c-3e7f-48cd-9a2b-f2ca368d6efe"),
                            ProductId = new Guid("0764d13f-7aea-4d58-a087-774b61041a08"),
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("FridgeProducts.Domain.Models.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = new Guid("69682051-c967-4628-bdf0-ac7c06bd6113"),
                            Name = "Milk",
                            YearOfRelease = 1
                        },
                        new
                        {
                            Id = new Guid("057f5256-f967-4dcb-ad44-6f8911998ed9"),
                            Name = "Apple",
                            YearOfRelease = 4
                        },
                        new
                        {
                            Id = new Guid("94df093d-97ea-48a7-a0a4-f57904a95743"),
                            Name = "Banana",
                            YearOfRelease = 3
                        });
                });

            modelBuilder.Entity("FridgeProducts.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DefaultQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("71ef7bc0-300b-40cc-b2e3-07123bec1137"),
                            DefaultQuantity = 1,
                            Name = "Milk"
                        },
                        new
                        {
                            Id = new Guid("9e66f3fd-3d2d-4fb3-a0b3-be5a917dc424"),
                            DefaultQuantity = 4,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = new Guid("0764d13f-7aea-4d58-a087-774b61041a08"),
                            DefaultQuantity = 3,
                            Name = "Banana"
                        });
                });

            modelBuilder.Entity("FridgeProducts.Domain.Models.Fridge", b =>
                {
                    b.HasOne("FridgeProducts.Domain.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("FridgeProducts.Domain.Models.FridgeProduct", b =>
                {
                    b.HasOne("FridgeProducts.Domain.Models.Fridge", "Fridge")
                        .WithMany()
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FridgeProducts.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
