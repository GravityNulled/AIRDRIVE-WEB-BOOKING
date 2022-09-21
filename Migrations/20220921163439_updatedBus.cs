using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyMvc.Migrations
{
    public partial class updatedBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAvailable",
                table: "Buses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Buses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAvailable",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Buses");
        }
    }
}
