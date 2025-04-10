using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceManager.Migrations
{
    /// <inheritdoc />
    public partial class EditClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "invoices",
                newName: "InvoiceDate");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "invoices",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyName",
                table: "invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Hours",
                table: "invoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyName",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "invoices",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "InvoiceDate",
                table: "invoices",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "invoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
