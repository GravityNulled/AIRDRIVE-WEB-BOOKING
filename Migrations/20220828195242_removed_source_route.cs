using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyMvc.Migrations
{
    public partial class removed_source_route : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "BusRoutes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "BusRoutes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
