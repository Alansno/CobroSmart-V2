using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CobroSmart.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClientAndPaymentChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePayment",
                table: "payments",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "HisPayment",
                table: "payments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HisPayment",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "clients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePayment",
                table: "payments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
