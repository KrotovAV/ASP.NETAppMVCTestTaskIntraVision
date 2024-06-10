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
                    { 3, "Cola" },
                    { 4, "Merinda 0.33" },
                    { 5, "Sprite 0.5" },
                    { 6, "Shweps 0.5" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BrandId", "Count", "ImageUrl", "ItemType", "Price", "Title" },
                values: new object[,]
                {
                    { 1, null, 20, null, 0, 1m, "1 рубль" },
                    { 2, null, 20, null, 0, 2m, "2 рубля" },
                    { 3, null, 20, null, 0, 5m, "5 рублей" },
                    { 4, null, 20, null, 0, 10m, "10 рублей" },
                    { 5, null, 20, null, 1, 20m, "Fanta 0.33" },
                    { 6, null, 20, null, 1, 25m, "Fanta 0.5" },
                    { 7, null, 20, null, 1, 22m, "Pepsi 0.33" },
                    { 8, null, 20, null, 1, 27m, "Pepsi 0.35" },
                    { 9, null, 20, null, 1, 25m, "Cola 0.33" },
                    { 10, null, 20, null, 1, 30m, "Cola 0.5" },
                    { 11, null, 20, null, 1, 25m, "Merinda 0.33" },
                    { 12, null, 20, null, 1, 25m, "Merinda 0.5" }
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
