using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementCore.Migrations
{
    public partial class ProductPhotoAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductPhotoPath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPhotoPath",
                table: "Products");
        }
    }
}
