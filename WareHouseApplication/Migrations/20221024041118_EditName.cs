using Microsoft.EntityFrameworkCore.Migrations;

namespace WareHouseApplication.Migrations
{
    public partial class EditName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInPallets_PalletConfiguration_PalletId",
                table: "ProductInPallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PalletConfiguration",
                table: "PalletConfiguration");

            migrationBuilder.RenameTable(
                name: "PalletConfiguration",
                newName: "Pallet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pallet",
                table: "Pallet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInPallets_Pallet_PalletId",
                table: "ProductInPallets",
                column: "PalletId",
                principalTable: "Pallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInPallets_Pallet_PalletId",
                table: "ProductInPallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pallet",
                table: "Pallet");

            migrationBuilder.RenameTable(
                name: "Pallet",
                newName: "PalletConfiguration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PalletConfiguration",
                table: "PalletConfiguration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInPallets_PalletConfiguration_PalletId",
                table: "ProductInPallets",
                column: "PalletId",
                principalTable: "PalletConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
