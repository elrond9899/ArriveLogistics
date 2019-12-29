using Microsoft.EntityFrameworkCore.Migrations;

namespace RoverAPI.Migrations
{
    public partial class InitialCreate_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompassDirections_Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompassDirections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarsRovers",
                columns: table => new
                {
                    RoverId = table.Column<string>(nullable: false),
                    XPosition = table.Column<int>(nullable: false),
                    YPosition = table.Column<int>(nullable: false),
                    FacingDirection = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarsRovers", x => x.RoverId);
                    table.ForeignKey("FK_CompassDirections", x => x.FacingDirection, "CompassDirections_Lookup", "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarsRovers");

            migrationBuilder.DropTable(
                name: "CompassDirections_Lookup");
        }
    }
}
