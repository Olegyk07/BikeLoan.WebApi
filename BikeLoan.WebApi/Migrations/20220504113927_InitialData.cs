using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeLoan.WebApi.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeLoan",
                columns: table => new
                {
                    BikeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BikeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BikePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeLoan", x => x.BikeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeLoan");
        }
    }
}
