using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreelanceManager.Migrations
{
    /// <inheritdoc />
    public partial class clientSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "contact@acme.com", false, "Acme Corporation", "555-0101" },
                    { 2, "info@globex.com", false, "Globex Corporation", "555-0102" },
                    { 3, "support@soylent.com", false, "Soylent Corp", "555-0103" },
                    { 4, "hello@initech.com", false, "Initech", "555-0104" },
                    { 5, "contact@umbrella.com", false, "Umbrella Corporation", "555-0105" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "clients",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
