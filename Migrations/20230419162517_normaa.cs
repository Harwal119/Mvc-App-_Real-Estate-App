using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMvcApp.Migrations
{
    public partial class normaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactiontList_ClientList_ClientId",
                table: "TransactiontList");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactiontList_PurchaseList_PurchaseId",
                table: "TransactiontList");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactiontList_RentalList_RentalId",
                table: "TransactiontList");

            migrationBuilder.DropIndex(
                name: "IX_TransactiontList_ClientId",
                table: "TransactiontList");

            migrationBuilder.DropIndex(
                name: "IX_TransactiontList_PurchaseId",
                table: "TransactiontList");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "TransactiontList");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "TransactiontList");

            migrationBuilder.RenameColumn(
                name: "RentalId",
                table: "TransactiontList",
                newName: "PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactiontList_RentalId",
                table: "TransactiontList",
                newName: "IX_TransactiontList_PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactiontList_PropertyList_PropertyId",
                table: "TransactiontList",
                column: "PropertyId",
                principalTable: "PropertyList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactiontList_PropertyList_PropertyId",
                table: "TransactiontList");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "TransactiontList",
                newName: "RentalId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactiontList_PropertyId",
                table: "TransactiontList",
                newName: "IX_TransactiontList_RentalId");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "TransactiontList",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseId",
                table: "TransactiontList",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TransactiontList_ClientId",
                table: "TransactiontList",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactiontList_PurchaseId",
                table: "TransactiontList",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactiontList_ClientList_ClientId",
                table: "TransactiontList",
                column: "ClientId",
                principalTable: "ClientList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactiontList_PurchaseList_PurchaseId",
                table: "TransactiontList",
                column: "PurchaseId",
                principalTable: "PurchaseList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactiontList_RentalList_RentalId",
                table: "TransactiontList",
                column: "RentalId",
                principalTable: "RentalList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
