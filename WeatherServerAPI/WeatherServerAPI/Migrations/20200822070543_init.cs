using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherServerAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentConditions",
                columns: table => new
                {
                    LocationKey = table.Column<string>(nullable: false),
                    WeatherText = table.Column<string>(nullable: true),
                    TemperatureInCelsius = table.Column<string>(nullable: true),
                    LocalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentConditions", x => x.LocationKey);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    CityKey = table.Column<string>(nullable: false),
                    LocalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.CityKey);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentConditions");

            migrationBuilder.DropTable(
                name: "Favorites");
        }
    }
}
