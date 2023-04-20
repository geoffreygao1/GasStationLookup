using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GasStationLookupApi.Migrations
{
    public partial class UpdateTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GasPrice_Station_StationId",
                table: "GasPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_Station_Companies_CompanyId",
                table: "Station");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Station",
                table: "Station");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GasPrice",
                table: "GasPrice");

            migrationBuilder.RenameTable(
                name: "Station",
                newName: "Stations");

            migrationBuilder.RenameTable(
                name: "GasPrice",
                newName: "GasPrices");

            migrationBuilder.RenameIndex(
                name: "IX_Station_CompanyId",
                table: "Stations",
                newName: "IX_Stations_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_GasPrice_StationId",
                table: "GasPrices",
                newName: "IX_GasPrices_StationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stations",
                table: "Stations",
                column: "StationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GasPrices",
                table: "GasPrices",
                column: "GasPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_GasPrices_Stations_StationId",
                table: "GasPrices",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Companies_CompanyId",
                table: "Stations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GasPrices_Stations_StationId",
                table: "GasPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Companies_CompanyId",
                table: "Stations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stations",
                table: "Stations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GasPrices",
                table: "GasPrices");

            migrationBuilder.RenameTable(
                name: "Stations",
                newName: "Station");

            migrationBuilder.RenameTable(
                name: "GasPrices",
                newName: "GasPrice");

            migrationBuilder.RenameIndex(
                name: "IX_Stations_CompanyId",
                table: "Station",
                newName: "IX_Station_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_GasPrices_StationId",
                table: "GasPrice",
                newName: "IX_GasPrice_StationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Station",
                table: "Station",
                column: "StationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GasPrice",
                table: "GasPrice",
                column: "GasPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_GasPrice_Station_StationId",
                table: "GasPrice",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Station_Companies_CompanyId",
                table: "Station",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
