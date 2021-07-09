using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiShop.Migrations
{
    public partial class ShopItemTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopOwnerShop_ShopOwner_ShopOwnerId",
                table: "ShopOwnerShop");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopOwnerShop_Shops_ShopId",
                table: "ShopOwnerShop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopOwnerShop",
                table: "ShopOwnerShop");

            migrationBuilder.RenameTable(
                name: "ShopOwnerShop",
                newName: "ShopOwnerShops");

            migrationBuilder.RenameIndex(
                name: "IX_ShopOwnerShop_ShopOwnerId",
                table: "ShopOwnerShops",
                newName: "IX_ShopOwnerShops_ShopOwnerId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Vegetables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Vegetables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Fruits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Fruits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CrockeryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CrockeryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopOwnerShops",
                table: "ShopOwnerShops",
                columns: new[] { "ShopId", "ShopOwnerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopOwnerShops_ShopOwner_ShopOwnerId",
                table: "ShopOwnerShops",
                column: "ShopOwnerId",
                principalTable: "ShopOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopOwnerShops_Shops_ShopId",
                table: "ShopOwnerShops",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopOwnerShops_ShopOwner_ShopOwnerId",
                table: "ShopOwnerShops");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopOwnerShops_Shops_ShopId",
                table: "ShopOwnerShops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopOwnerShops",
                table: "ShopOwnerShops");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CrockeryItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CrockeryItems");

            migrationBuilder.RenameTable(
                name: "ShopOwnerShops",
                newName: "ShopOwnerShop");

            migrationBuilder.RenameIndex(
                name: "IX_ShopOwnerShops_ShopOwnerId",
                table: "ShopOwnerShop",
                newName: "IX_ShopOwnerShop_ShopOwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopOwnerShop",
                table: "ShopOwnerShop",
                columns: new[] { "ShopId", "ShopOwnerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShopOwnerShop_ShopOwner_ShopOwnerId",
                table: "ShopOwnerShop",
                column: "ShopOwnerId",
                principalTable: "ShopOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopOwnerShop_Shops_ShopId",
                table: "ShopOwnerShop",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
