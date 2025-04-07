using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceManager.Migrations
{
    /// <inheritdoc />
    public partial class editmisssion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimateTime",
                table: "timeTracking");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EstimateTime",
                table: "missions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimateTime",
                table: "missions");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EstimateTime",
                table: "timeTracking",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
