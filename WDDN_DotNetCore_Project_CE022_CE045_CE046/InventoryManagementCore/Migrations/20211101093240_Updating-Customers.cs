using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementCore.Migrations
{
    public partial class UpdatingCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "totalOutstanding",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalOutstanding",
                table: "Customers");
        }
    }
}
