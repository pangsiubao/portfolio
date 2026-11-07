using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApi.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Beschrijving", "Categorie", "Datum", "GitHubUrl", "Titel" },
                values: new object[] { "Een webapp in C# waarmee teams taken verdelen en deadlines bijhouden.", "C#", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dummy project 1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Beschrijving", "Categorie", "Datum", "GitHubUrl", "Titel" },
                values: new object[] { "Een persoonlijke portfolio website gebouwd met HTML, CSS en JavaScript.", "JavaScript", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://github.com/pangsiubao/portfolio", "Portfolio Website" });
        }
    }
}
