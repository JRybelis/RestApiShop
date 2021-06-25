using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiShop.Migrations
{
    public partial class AddDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Vegetables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Shops",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Fruits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CrockeryItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CrockeryItems");
        }
    }
}
