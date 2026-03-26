using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class viewmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderDetailsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailsViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderDetailsViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemViewModel_OrderDetailsViewModel_OrderDetailsViewModelId",
                        column: x => x.OrderDetailsViewModelId,
                        principalTable: "OrderDetailsViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemViewModel_OrderDetailsViewModelId",
                table: "OrderItemViewModel",
                column: "OrderDetailsViewModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemViewModel");

            migrationBuilder.DropTable(
                name: "OrderDetailsViewModel");
        }
    }
}
