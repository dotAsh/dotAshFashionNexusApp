using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotAshFashionNexus.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TablesCreationAndSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SearchEngineFriendlyName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseID);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    VariantID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Size = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.VariantID);
                    table.ForeignKey(
                        name: "FK_Variants_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VariantID = table.Column<int>(type: "integer", nullable: false),
                    WarehouseID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockID);
                    table.ForeignKey(
                        name: "FK_Stocks_Variants_VariantID",
                        column: x => x.VariantID,
                        principalTable: "Variants",
                        principalColumn: "VariantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Warehouses_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CreatedOn", "Name", "SearchEngineFriendlyName" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 5, 8, 20, 5, 2, 718, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 0, 0, 0, 0)), "Product 1", "product-1" },
                    { 2, new DateTimeOffset(new DateTime(2024, 5, 8, 20, 5, 2, 718, DateTimeKind.Unspecified).AddTicks(4694), new TimeSpan(0, 0, 0, 0, 0)), "Product 2", "product-2" },
                    { 3, new DateTimeOffset(new DateTime(2024, 5, 8, 20, 5, 2, 718, DateTimeKind.Unspecified).AddTicks(4697), new TimeSpan(0, 0, 0, 0, 0)), "Product 3", "product-3" },
                    { 4, new DateTimeOffset(new DateTime(2024, 5, 8, 20, 5, 2, 718, DateTimeKind.Unspecified).AddTicks(4700), new TimeSpan(0, 0, 0, 0, 0)), "Product 4", "product-4" },
                    { 5, new DateTimeOffset(new DateTime(2024, 5, 8, 20, 5, 2, 718, DateTimeKind.Unspecified).AddTicks(4704), new TimeSpan(0, 0, 0, 0, 0)), "Product 5", "product-5" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseID", "Name" },
                values: new object[,]
                {
                    { 1, "Warehouse 1" },
                    { 2, "Warehouse 2" },
                    { 3, "Warehouse 3" },
                    { 4, "Warehouse 4" },
                    { 5, "Warehouse 5" }
                });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "VariantID", "Color", "ProductID", "Size" },
                values: new object[,]
                {
                    { 1, "Red", 1, "Small" },
                    { 2, "Blue", 1, "Medium" },
                    { 3, "Green", 2, "Large" },
                    { 4, "Black", 3, "Small" },
                    { 5, "White", 4, "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockID", "Quantity", "VariantID", "WarehouseID" },
                values: new object[,]
                {
                    { 1, 10, 1, 1 },
                    { 2, 20, 2, 2 },
                    { 3, 30, 3, 3 },
                    { 4, 40, 4, 4 },
                    { 5, 50, 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_VariantID",
                table: "Stocks",
                column: "VariantID");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_WarehouseID",
                table: "Stocks",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductID",
                table: "Variants",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
