using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinotecaRecu.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 21, 17, 56, 7, 649, DateTimeKind.Utc).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 21, 17, 56, 7, 649, DateTimeKind.Utc).AddTicks(5114));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 21, 16, 58, 27, 166, DateTimeKind.Utc).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 21, 16, 58, 27, 166, DateTimeKind.Utc).AddTicks(5039));
        }
    }
}
