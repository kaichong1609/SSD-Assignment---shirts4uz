using Microsoft.EntityFrameworkCore.Migrations;

namespace SSD_Assignment___shirts4uz.Migrations
{
    public partial class ListedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ListedBy",
                table: "Shirt",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Order",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListedBy",
                table: "Shirt");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Order",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
