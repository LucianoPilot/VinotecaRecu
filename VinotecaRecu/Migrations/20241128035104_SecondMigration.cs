using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinotecaRecu.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CataWine_Catas_CataId",
                table: "CataWine");

            migrationBuilder.DropForeignKey(
                name: "FK_CataWine_Wines_WineId",
                table: "CataWine");

            migrationBuilder.RenameColumn(
                name: "WineId",
                table: "CataWine",
                newName: "WinesId");

            migrationBuilder.RenameColumn(
                name: "CataId",
                table: "CataWine",
                newName: "CatasId");

            migrationBuilder.RenameIndex(
                name: "IX_CataWine_WineId",
                table: "CataWine",
                newName: "IX_CataWine_WinesId");

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 28, 3, 51, 3, 706, DateTimeKind.Utc).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 28, 3, 51, 3, 706, DateTimeKind.Utc).AddTicks(8222));

            migrationBuilder.AddForeignKey(
                name: "FK_CataWine_Catas_CatasId",
                table: "CataWine",
                column: "CatasId",
                principalTable: "Catas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CataWine_Wines_WinesId",
                table: "CataWine",
                column: "WinesId",
                principalTable: "Wines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CataWine_Catas_CatasId",
                table: "CataWine");

            migrationBuilder.DropForeignKey(
                name: "FK_CataWine_Wines_WinesId",
                table: "CataWine");

            migrationBuilder.RenameColumn(
                name: "WinesId",
                table: "CataWine",
                newName: "WineId");

            migrationBuilder.RenameColumn(
                name: "CatasId",
                table: "CataWine",
                newName: "CataId");

            migrationBuilder.RenameIndex(
                name: "IX_CataWine_WinesId",
                table: "CataWine",
                newName: "IX_CataWine_WineId");

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 28, 3, 38, 40, 341, DateTimeKind.Utc).AddTicks(3543));

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 28, 3, 38, 40, 341, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.AddForeignKey(
                name: "FK_CataWine_Catas_CataId",
                table: "CataWine",
                column: "CataId",
                principalTable: "Catas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CataWine_Wines_WineId",
                table: "CataWine",
                column: "WineId",
                principalTable: "Wines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
