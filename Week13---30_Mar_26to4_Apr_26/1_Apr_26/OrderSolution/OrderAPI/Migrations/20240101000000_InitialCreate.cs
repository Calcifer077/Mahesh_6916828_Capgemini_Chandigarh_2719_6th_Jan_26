using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace OrderApi.Migrations
{
    [Migration("20240101000000_InitialCreate")]
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id   = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Categories", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id    = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name  = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Products", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id    = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name  = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId  = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey("FK_ProductCategories_Categories_CategoryId", x => x.CategoryId, "Categories", "Id", onDelete: ReferentialAction.Cascade);
                    table.ForeignKey("FK_ProductCategories_Products_ProductId",    x => x.ProductId,  "Products",   "Id", onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id        = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status    = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId    = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey("FK_Orders_Users_UserId", x => x.UserId, "Users", "Id", onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id      = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone   = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId  = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey("FK_UserProfiles_Users_UserId", x => x.UserId, "Users", "Id", onDelete: ReferentialAction.Cascade);
                });

            // ── Seed Data ──────────────────────────────────────────
            migrationBuilder.InsertData("Categories", new[] { "Id", "Name" }, new object[,]
            {
                { 1, "Electronics" },
                { 2, "Accessories" }
            });

            migrationBuilder.InsertData("Products", new[] { "Id", "Name", "Price", "Stock" }, new object[,]
            {
                { 1, "Laptop",   999.99m, 10 },
                { 2, "Mouse",    29.99m,  50 },
                { 3, "Keyboard", 79.99m,  30 }
            });

            migrationBuilder.InsertData("Users", new[] { "Id", "Name", "Email" }, new object[,]
            {
                { 1, "Alice", "alice@example.com" },
                { 2, "Bob",   "bob@example.com"   }
            });

            migrationBuilder.InsertData("ProductCategories", new[] { "ProductId", "CategoryId" }, new object[,]
            {
                { 1, 1 },
                { 2, 2 },
                { 3, 2 }
            });

            // ── Indexes ────────────────────────────────────────────
            migrationBuilder.CreateIndex("IX_Orders_UserId",          "Orders",          "UserId");
            migrationBuilder.CreateIndex("IX_ProductCategories_CategoryId", "ProductCategories", "CategoryId");
            migrationBuilder.CreateIndex("IX_UserProfiles_UserId",    "UserProfiles",    "UserId", unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("UserProfiles");
            migrationBuilder.DropTable("Orders");
            migrationBuilder.DropTable("ProductCategories");
            migrationBuilder.DropTable("Products");
            migrationBuilder.DropTable("Users");
            migrationBuilder.DropTable("Categories");
        }
    }
}
