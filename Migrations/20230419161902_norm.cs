using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMvcApp.Migrations
{
    public partial class norm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "TransactiontList");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "TransactiontList",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "TransactiontList",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "TransactiontList",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "TransactiontList");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "TransactiontList");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TransactiontList");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "TransactiontList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
