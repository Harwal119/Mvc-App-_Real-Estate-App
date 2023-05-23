using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMvcApp.Migrations
{
    public partial class wallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletList_ClientList_ClientId",
                table: "WalletList");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "WalletList",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WalletList_ClientId",
                table: "WalletList",
                newName: "IX_WalletList_UserId");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "WalletList",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_WalletList_UserList_UserId",
                table: "WalletList",
                column: "UserId",
                principalTable: "UserList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletList_UserList_UserId",
                table: "WalletList");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "WalletList");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WalletList",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_WalletList_UserId",
                table: "WalletList",
                newName: "IX_WalletList_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletList_ClientList_ClientId",
                table: "WalletList",
                column: "ClientId",
                principalTable: "ClientList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
