using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMvcApp.Migrations
{
    public partial class them : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentList");

            migrationBuilder.CreateTable(
                name: "TransactiontList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    RentalId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurchaseId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactiontList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactiontList_ClientList_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactiontList_PurchaseList_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactiontList_RentalList_RentalId",
                        column: x => x.RentalId,
                        principalTable: "RentalList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TransactiontList_ClientId",
                table: "TransactiontList",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactiontList_PurchaseId",
                table: "TransactiontList",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactiontList_RentalId",
                table: "TransactiontList",
                column: "RentalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactiontList");

            migrationBuilder.CreateTable(
                name: "PaymentList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurchaseId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RentalId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentList_ClientList_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentList_PurchaseList_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentList_ClientId",
                table: "PaymentList",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentList_PurchaseId",
                table: "PaymentList",
                column: "PurchaseId");
        }
    }
}
