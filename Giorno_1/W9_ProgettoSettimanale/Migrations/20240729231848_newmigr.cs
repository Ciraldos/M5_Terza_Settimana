using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W9_ProgettoSettimanale.Migrations
{
    /// <inheritdoc />
    public partial class newmigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    idProducts = table.Column<int>(type: "int", nullable: false),
                    idOrders = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedProducts_Orders_idOrders",
                        column: x => x.idOrders,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedProducts_Products_idProducts",
                        column: x => x.idProducts,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_idOrders",
                table: "OrderedProducts",
                column: "idOrders");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProducts_idProducts",
                table: "OrderedProducts",
                column: "idProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedProducts");
        }
    }
}
