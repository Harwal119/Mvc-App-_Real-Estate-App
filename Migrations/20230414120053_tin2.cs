using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMvcApp.Migrations
{
    public partial class tin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "WalletList",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WalletList",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_WalletList_ClientId",
                table: "WalletList",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletList_ClientList_ClientId",
                table: "WalletList",
                column: "ClientId",
                principalTable: "ClientList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletList_ClientList_ClientId",
                table: "WalletList");

            migrationBuilder.DropIndex(
                name: "IX_WalletList_ClientId",
                table: "WalletList");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WalletList");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "WalletList",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
