using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMvcApp.Migrations
{
    public partial class them3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "PropertyList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "PropertyList");
        }
    }
}
