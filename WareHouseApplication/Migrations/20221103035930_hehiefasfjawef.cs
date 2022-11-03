using Microsoft.EntityFrameworkCore.Migrations;

namespace WareHouseApplication.Migrations
{
    public partial class hehiefasfjawef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Pallet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Pallet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
