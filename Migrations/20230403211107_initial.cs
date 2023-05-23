using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMvcApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PurchaseId",
                table: "PaymentList",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentList_PurchaseId",
                table: "PaymentList",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentList_PurchaseList_PurchaseId",
                table: "PaymentList",
                column: "PurchaseId",
                principalTable: "PurchaseList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentList_PurchaseList_PurchaseId",
                table: "PaymentList");

            migrationBuilder.DropIndex(
                name: "IX_PaymentList_PurchaseId",
                table: "PaymentList");

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseId",
                table: "PaymentList",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
