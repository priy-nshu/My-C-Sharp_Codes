using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetupV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SALES");

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "SALES",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    order_status = table.Column<byte>(type: "tinyint", nullable: false),
                    order_date = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    required_date = table.Column<DateOnly>(type: "date", nullable: false),
                    shipped_date = table.Column<DateOnly>(type: "date", nullable: true),
                    store_id = table.Column<int>(type: "int", nullable: false),
                    staff_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders__46596229D0BB174E", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "SALES",
                columns: table => new
                {
                    Orderitem_id = table.Column<int>(type: "int", nullable: false)
                                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    list_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(4,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_it__837942D479E34F2F", x => new { x.order_id, x.Orderitem_id });
                    table.ForeignKey(
                        name: "FK__order_ite__order__619B8048",
                        column: x => x.order_id,
                        principalSchema: "SALES",
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_items",
                schema: "SALES");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "SALES");
        }
    }
}
