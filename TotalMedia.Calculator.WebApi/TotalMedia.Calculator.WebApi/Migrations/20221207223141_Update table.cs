using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotalMedia.Calculator.WebApi.Migrations
{
    public partial class Updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VatRates_Countries_CountryId",
                table: "VatRates");

            migrationBuilder.DropIndex(
                name: "IX_VatRates_CountryId",
                table: "VatRates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VatRates_CountryId",
                table: "VatRates",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VatRates_Countries_CountryId",
                table: "VatRates",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
