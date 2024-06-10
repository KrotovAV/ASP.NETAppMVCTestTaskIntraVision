using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataBaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrdersDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemCount = table.Column<int>(type: "int", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemChange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[,]
                {
                    { 1, "Fanta" },
                    { 2, "Pepsi" },
                    { 3, "Coca-Cola" },
                    { 4, "Schweppes" },
                    { 5, "Sprite" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BrandId", "Count", "ImageUrl", "ItemType", "Price", "Title" },
                values: new object[,]
                {
                    { 1, null, 20, "/img/1.jpg", 0, 1m, "1 рубль" },
                    { 2, null, 20, "/img/2.jpg", 0, 2m, "2 рубля" },
                    { 3, null, 20, "/img/5.jpg", 0, 5m, "5 рублей" },
                    { 4, null, 20, "/img/10.jpg", 0, 10m, "10 рублей" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ActType", "DateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2024, 6, 9, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BrandId", "Count", "ImageUrl", "ItemType", "Price", "Title" },
                values: new object[,]
                {
                    { 5, 3, 20, "/img/coca-cola03.jpg", 1, 20m, "Coca-Cola 0.33" },
                    { 6, 3, 20, "/img/coca-cola05.jpg", 1, 25m, "Coca-Cola 0.5" },
                    { 7, 3, 20, "/img/coca-cola10.jpg", 1, 35m, "Coca-Cola 1.0" },
                    { 8, 3, 20, "/img/coca-colaLimon03.jpg", 1, 20m, "Coca-Cola Лимон 0.33" },
                    { 9, 3, 20, "/img/coca-colaLimon05.jpg", 1, 25m, "Coca-Cola Лимон 0.5" },
                    { 10, 3, 20, "/img/coca-colaLimon10.jpg", 1, 35m, "Coca-Cola Лимон 1.0" },
                    { 11, 1, 20, "/img/fantaApelsin03.jpg", 1, 21m, "Fanta Апельсин 0.33" },
                    { 12, 1, 20, "/img/fantaApelsin05.jpg", 1, 26m, "Fanta Апельсин 0.5" },
                    { 13, 1, 20, "/img/fantaApelsin10.jpg", 1, 34m, "Fanta Апельсин 1.0" },
                    { 14, 1, 20, "/img/fantaVinograd03.jpg", 1, 22m, "Fanta Виноград 0.33" },
                    { 15, 1, 20, "/img/fantaVinograd05.jpg", 1, 26m, "Fanta Виноград 0.5" },
                    { 16, 1, 20, "/img/fantaVinograd10.jpg", 1, 36m, "Fanta Виноград 1.0" },
                    { 17, 2, 20, "/img/pepsi03.jpg", 1, 20m, "Pepsi 0.33" },
                    { 18, 2, 25, "/img/pepsi05.jpg", 1, 20m, "Pepsi 0.5" },
                    { 19, 2, 35, "/img/pepsi10.jpg", 1, 20m, "Pepsi 1.0" },
                    { 20, 2, 24, "/img/pepsiZero03.jpg", 1, 20m, "Pepsi Zero 0.33" },
                    { 21, 2, 29, "/img/pepsiZero05.jpg", 1, 20m, "Pepsi Zero 0.5" },
                    { 22, 2, 48, "/img/pepsiZero10.jpg", 1, 20m, "Pepsi Zero 1.0" },
                    { 23, 4, 22, "/img/schweppesKlukva03.jpg", 1, 20m, "Schweppes Клюква 0.33" },
                    { 24, 4, 26, "/img/schweppesKlukva05.jpg", 1, 20m, "Schweppes Клюква 0.5" },
                    { 25, 4, 38, "/img/schweppesKlukva10.jpg", 1, 20m, "Schweppes Клюква 1.0" },
                    { 26, 4, 22, "/img/schweppesLimon03.jpg", 1, 20m, "Schweppes Лимон 0.33" },
                    { 27, 4, 27, "/img/schweppesLimon05.jpg", 1, 20m, "Schweppes Лимон 0.5" },
                    { 28, 4, 39, "/img/schweppesLimon10.jpg", 1, 20m, "Schweppes Лимон 1.0" },
                    { 29, 5, 20, "/img/sprite03.jpg", 1, 20m, "Sprite 0.33" },
                    { 30, 5, 28, "/img/sprite05.jpg", 1, 20m, "Sprite 0.5" },
                    { 31, 5, 38, "/img/sprite10.jpg", 1, 20m, "Sprite 1.0" }
                });

            migrationBuilder.InsertData(
                table: "OrdersDetails",
                columns: new[] { "Id", "ItemChange", "ItemCount", "ItemId", "ItemPrice", "ItemType", "OrderId" },
                values: new object[,]
                {
                    { 1, 10, 10, 1, 1m, 0, 1 },
                    { 2, 1, 1, 4, 10m, 0, 1 },
                    { 3, -1, 1, 5, 20m, 1, 1 },
                    { 4, 10, 10, 1, 1m, 0, 2 },
                    { 5, 3, 3, 4, 10m, 0, 2 },
                    { 6, -2, 2, 5, 20m, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_BrandId",
                table: "Items",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetails_OrderId",
                table: "OrdersDetails",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "OrdersDetails");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
