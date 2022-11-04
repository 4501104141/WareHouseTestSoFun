using Microsoft.EntityFrameworkCore.Migrations;

namespace WareHouseApplication.Migrations
{
    public partial class RemoveHaskeyTransferDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TransfersDetails",
                table: "TransfersDetails");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TransfersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransfersDetails",
                table: "TransfersDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransfersDetails_TransferId",
                table: "TransfersDetails",
                column: "TransferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TransfersDetails",
                table: "TransfersDetails");

            migrationBuilder.DropIndex(
                name: "IX_TransfersDetails_TransferId",
                table: "TransfersDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TransfersDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransfersDetails",
                table: "TransfersDetails",
                column: "TransferId");
        }
    }
}
