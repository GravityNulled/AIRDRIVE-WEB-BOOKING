using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyMvc.Migrations
{
    public partial class relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_BusRoutes_BusRouteId",
                table: "Buses");

            migrationBuilder.DropIndex(
                name: "IX_Buses_BusRouteId",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "BusRouteId",
                table: "Buses");

            migrationBuilder.CreateIndex(
                name: "IX_BusRoutes_BusId",
                table: "BusRoutes",
                column: "BusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusRoutes_Buses_BusId",
                table: "BusRoutes",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusRoutes_Buses_BusId",
                table: "BusRoutes");

            migrationBuilder.DropIndex(
                name: "IX_BusRoutes_BusId",
                table: "BusRoutes");

            migrationBuilder.AddColumn<int>(
                name: "BusRouteId",
                table: "Buses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusRouteId",
                table: "Buses",
                column: "BusRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_BusRoutes_BusRouteId",
                table: "Buses",
                column: "BusRouteId",
                principalTable: "BusRoutes",
                principalColumn: "BusRouteId");
        }
    }
}
