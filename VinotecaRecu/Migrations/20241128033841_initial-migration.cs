using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VinotecaRecu.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    WineIds = table.Column<string>(type: "TEXT", nullable: false),
                    Invitados = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Rol = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Variety = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CataWine",
                columns: table => new
                {
                    CataId = table.Column<int>(type: "INTEGER", nullable: false),
                    WineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CataWine", x => new { x.CataId, x.WineId });
                    table.ForeignKey(
                        name: "FK_CataWine_Catas_CataId",
                        column: x => x.CataId,
                        principalTable: "Catas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CataWine_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Rol", "Username" },
                values: new object[,]
                {
                    { 1, "Pa$$w0rd", 0, "mgs@gmail.com" },
                    { 2, "Cl4ve!", 0, "jhonwick@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Wines",
                columns: new[] { "Id", "CreatedAt", "Name", "Region", "Stock", "Variety", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 28, 3, 38, 40, 341, DateTimeKind.Utc).AddTicks(3543), "Cabernet Sauvignon", "Mendoza", 50, "Cabernet Sauvignon", 2018 },
                    { 2, new DateTime(2024, 11, 28, 3, 38, 40, 341, DateTimeKind.Utc).AddTicks(3972), "Malbec", "Mendoza", 30, "Malbec", 2020 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CataWine_WineId",
                table: "CataWine",
                column: "WineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CataWine");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Catas");

            migrationBuilder.DropTable(
                name: "Wines");
        }
    }
}
