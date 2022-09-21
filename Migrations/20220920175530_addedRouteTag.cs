using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyMvc.Migrations
{
    public partial class addedRouteTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouteTag",
                table: "BusRoutes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "BusRoutes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteTag",
                table: "BusRoutes");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "BusRoutes");
        }
    }
}
