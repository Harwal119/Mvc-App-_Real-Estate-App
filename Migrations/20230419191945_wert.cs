using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMvcApp.Migrations
{
    public partial class wert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TransactiontList");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TransactiontList",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TransactiontList");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "TransactiontList",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
