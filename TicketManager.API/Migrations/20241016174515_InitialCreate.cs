using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketManager.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Date", "Description", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conférence sur l'IA Éthique et Responsable", "Open" },
                    { 2, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atelier sur les Techniques de Cybersécurité Avancées", "Open" },
                    { 3, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Séminaire sur les Applications de l'IA dans le Secteur de la Santé", "Closed" },
                    { 4, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forum sur les Menaces Cybernétiques et les Solutions", "Open" },
                    { 5, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Expo sur l'Innovation Technologique et le Futur", "Open" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
