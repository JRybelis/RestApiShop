using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiShop.Migrations
{
    public partial class ShopForeignKeyConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Vegetables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Fruits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "CrockeryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vegetables_ShopId",
                table: "Vegetables",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_ShopId",
                table: "Fruits",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_CrockeryItems_ShopId",
                table: "CrockeryItems",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrockeryItems_Shops_ShopId",
                table: "CrockeryItems",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fruits_Shops_ShopId",
                table: "Fruits",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vegetables_Shops_ShopId",
                table: "Vegetables",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrockeryItems_Shops_ShopId",
                table: "CrockeryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Fruits_Shops_ShopId",
                table: "Fruits");

            migrationBuilder.DropForeignKey(
                name: "FK_Vegetables_Shops_ShopId",
                table: "Vegetables");

            migrationBuilder.DropIndex(
                name: "IX_Vegetables_ShopId",
                table: "Vegetables");

            migrationBuilder.DropIndex(
                name: "IX_Fruits_ShopId",
                table: "Fruits");

            migrationBuilder.DropIndex(
                name: "IX_CrockeryItems_ShopId",
                table: "CrockeryItems");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "CrockeryItems");
        }
    }
}
