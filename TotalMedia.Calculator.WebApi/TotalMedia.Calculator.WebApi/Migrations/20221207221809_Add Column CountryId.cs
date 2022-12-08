using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotalMedia.Calculator.WebApi.Migrations
{
    public partial class AddColumnCountryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VatRates_Countries_CountryId",
                table: "VatRates");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "VatRates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VatRates_Countries_CountryId",
                table: "VatRates",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VatRates_Countries_CountryId",
                table: "VatRates");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "VatRates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VatRates_Countries_CountryId",
                table: "VatRates",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
