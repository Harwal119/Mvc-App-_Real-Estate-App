using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMvcApp.Migrations
{
    public partial class fin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "TransactiontList",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "PropertyList",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PropertyDocument",
                table: "PropertyList",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TransactiontList_ClientId",
                table: "TransactiontList",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactiontList_ClientList_ClientId",
                table: "TransactiontList",
                column: "ClientId",
                principalTable: "ClientList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactiontList_ClientList_ClientId",
                table: "TransactiontList");

            migrationBuilder.DropIndex(
                name: "IX_TransactiontList_ClientId",
                table: "TransactiontList");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "TransactiontList");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "PropertyList");

            migrationBuilder.DropColumn(
                name: "PropertyDocument",
                table: "PropertyList");
        }
    }
}
