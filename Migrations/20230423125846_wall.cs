using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMvcApp.Migrations
{
    public partial class wall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AgencyFee",
                table: "PropertyList",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AgreementFee",
                table: "PropertyList",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CautionFee",
                table: "PropertyList",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "PropertyList",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgencyFee",
                table: "PropertyList");

            migrationBuilder.DropColumn(
                name: "AgreementFee",
                table: "PropertyList");

            migrationBuilder.DropColumn(
                name: "CautionFee",
                table: "PropertyList");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "PropertyList");
        }
    }
}
