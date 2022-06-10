using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeProductsApp.Database.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfRelease = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fridges_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FridgeProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FridgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeProducts_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Name", "YearOfRelease" },
                values: new object[,]
                {
                    { new Guid("057f5256-f967-4dcb-ad44-6f8911998ed9"), "bukaviicifari6", 1985 },
                    { new Guid("69682051-c967-4628-bdf0-ac7c06bd6113"), "145-buckavi62687-4521", 1123 },
                    { new Guid("94df093d-97ea-48a7-a0a4-f57904a95743"), "prostocifari123", 2018 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("0764d13f-7aea-4d58-a087-774b61041a08"), 3, "Banana" },
                    { new Guid("71ef7bc0-300b-40cc-b2e3-07123bec1137"), 1, "Milk" },
                    { new Guid("9e66f3fd-3d2d-4fb3-a0b3-be5a917dc424"), 4, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "ModelId", "Name", "OwnerName" },
                values: new object[] { new Guid("3f2966cc-c0d1-4c07-858d-e5191ef458a0"), new Guid("69682051-c967-4628-bdf0-ac7c06bd6113"), "AlpicAir", "Ladushka" });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "ModelId", "Name", "OwnerName" },
                values: new object[] { new Guid("5cc31465-a342-4b0f-a28c-6cd400a36bf5"), new Guid("057f5256-f967-4dcb-ad44-6f8911998ed9"), "Atlant", "Andrew" });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "ModelId", "Name", "OwnerName" },
                values: new object[] { new Guid("9818e43c-3e7f-48cd-9a2b-f2ca368d6efe"), new Guid("94df093d-97ea-48a7-a0a4-f57904a95743"), "Philips", "Leha" });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[] { new Guid("c2ae232e-ff5b-4965-b474-2d1095b6c8ce"), new Guid("3f2966cc-c0d1-4c07-858d-e5191ef458a0"), new Guid("71ef7bc0-300b-40cc-b2e3-07123bec1137"), 0 });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[] { new Guid("d2544737-b1d4-47a6-9d89-125c6f200809"), new Guid("9818e43c-3e7f-48cd-9a2b-f2ca368d6efe"), new Guid("0764d13f-7aea-4d58-a087-774b61041a08"), 0 });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[] { new Guid("f1cfc80d-f296-4184-b3b7-ef183256957d"), new Guid("5cc31465-a342-4b0f-a28c-6cd400a36bf5"), new Guid("9e66f3fd-3d2d-4fb3-a0b3-be5a917dc424"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProducts_FridgeId",
                table: "FridgeProducts",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProducts_ProductId",
                table: "FridgeProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_ModelId",
                table: "Fridges",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FridgeProducts");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
