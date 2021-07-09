using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiShop.Migrations
{
    public partial class ShopOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopOwnerShop",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ShopOwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOwnerShop", x => new { x.ShopId, x.ShopOwnerId });
                    table.ForeignKey(
                        name: "FK_ShopOwnerShop_ShopOwner_ShopOwnerId",
                        column: x => x.ShopOwnerId,
                        principalTable: "ShopOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopOwnerShop_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopOwnerShop_ShopOwnerId",
                table: "ShopOwnerShop",
                column: "ShopOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopOwnerShop");

            migrationBuilder.DropTable(
                name: "ShopOwner");
        }
    }
}
