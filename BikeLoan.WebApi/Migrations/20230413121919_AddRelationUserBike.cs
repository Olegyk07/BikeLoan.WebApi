using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeLoan.WebApi.Migrations
{
    public partial class AddRelationUserBike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BikeLoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BikeLoan_UserId",
                table: "BikeLoan",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BikeLoan_Users_UserId",
                table: "BikeLoan",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BikeLoan_Users_UserId",
                table: "BikeLoan");

            migrationBuilder.DropIndex(
                name: "IX_BikeLoan_UserId",
                table: "BikeLoan");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BikeLoan");
        }
    }
}
