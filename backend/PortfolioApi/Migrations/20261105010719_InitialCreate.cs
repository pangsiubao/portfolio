using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogposts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inhoud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publicatiedatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogposts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitHubUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Blogposts",
                columns: new[] { "Id", "Inhoud", "Publicatiedatum", "Titel" },
                values: new object[,]
                {
                    { 1, "In dit blog deel ik mijn ervaringen met leren programmeren.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leren programmeren" },
                    { 2, "In dit blog deel ik mijn ervaringen met het kiezen tussen Python en C#. Ik bespreek de voordelen en nadelen van beide talen en hoe ik mijn keuze bepaal.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python of C#?" },
                    { 3, "In dit blog deel ik mijn ervaringen met het bouwen van mijn eerste website. Ik vertel over de uitdagingen die ik tegenkwam, de lessen die ik leerde en de tips die ik zou geven aan anderen die net beginnen.", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mijn eerste website" },
                    { 4, "In dit blog deel ik mijn ervaringen met het onderhouden van schoon code. Ik bespreek drie gewoontes die mij helpen om mijn projecten ook na maanden nog leesbaar en onderhoudbaar te houden.", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Code schoon houden" },
                    { 5, "In dit blog deel ik mijn ervaringen met het bouwen van kleine projecten. Ik bespreek de voordelen van kleine projecten, de lessen die ik leerde en hoe ze mijn vaardigheden als ontwikkelaar hebben verbeterd.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "De kracht van kleine projecten" },
                    { 6, "In dit blog deel ik mijn ervaringen met het samenwerken in code. Ik bespreek de uitdagingen die ik tegenkwam, de tools die ik gebruikte en de lessen die ik leerde over effectief samenwerken.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samenwerken in code" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Beschrijving", "Categorie", "Datum", "GitHubUrl", "Titel" },
                values: new object[,]
                {
                    { 1, "Een persoonlijke portfolio website gebouwd met HTML, CSS en JavaScript.", "JavaScript", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://github.com/pangsiubao/portfolio", "Portfolio Website" },
                    { 2, "Een persoonlijke portfolio website gebouwd met HTML, CSS en JavaScript.", "JavaScript", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://github.com/pangsiubao/portfolio", "Portfolio Website" },
                    { 3, "Een volledig functioneel e-commerce platform met winkelwagen en betalingsintegratie.", "Python", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://github.com/pangsiubao/portfolio", "E-commerce Platform" },
                    { 4, "Een mobiele game ontwikkeld met Unity en C#.", "C#", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://github.com/pangsiubao/portfolio", "Mobile Game" },
                    { 5, "Een tool voor het analyseren van grote datasets met behulp van Python en Pandas.", "Python", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://github.com/pangsiubao/portfolio", "Data Analysis Tool" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogposts");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
