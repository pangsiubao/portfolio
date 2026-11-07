using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;

namespace PortfolioApi.Data;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Blogpost> Blogposts => Set<Blogpost>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Titel = "Dummy project 1", Beschrijving = "Een webapp in C# waarmee teams taken verdelen en deadlines bijhouden.", Categorie = "C#", GitHubUrl = null, Datum = new DateTime(2025, 1, 1) },
            new Project { Id = 2, Titel = "Portfolio Website", Beschrijving = "Een persoonlijke portfolio website gebouwd met HTML, CSS en JavaScript.", Categorie = "JavaScript", GitHubUrl = "https://github.com/pangsiubao/portfolio", Datum = new DateTime(2026, 1, 1) },
            new Project { Id = 3, Titel = "E-commerce Platform", Beschrijving = "Een volledig functioneel e-commerce platform met winkelwagen en betalingsintegratie.", Categorie = "Python", GitHubUrl = "https://github.com/pangsiubao/portfolio", Datum = new DateTime(2023, 1, 1) },
            new Project { Id = 4, Titel = "Mobile Game", Beschrijving = "Een mobiele game ontwikkeld met Unity en C#.", Categorie = "C#", GitHubUrl = "https://github.com/pangsiubao/portfolio", Datum = new DateTime(2024, 1, 1) },
            new Project { Id = 5, Titel = "Data Analysis Tool", Beschrijving = "Een tool voor het analyseren van grote datasets met behulp van Python en Pandas.", Categorie = "Python", GitHubUrl = "https://github.com/pangsiubao/portfolio", Datum = new DateTime(2022, 1, 1) }
        );

        modelBuilder.Entity<Blogpost>().HasData(
            new Blogpost { Id = 1, Titel = "Leren programmeren", Inhoud = "In dit blog deel ik mijn ervaringen met leren programmeren.", Publicatiedatum = new DateTime(2025, 1, 1) },
            new Blogpost { Id = 2, Titel = "Python of C#?", Inhoud = "In dit blog deel ik mijn ervaringen met het kiezen tussen Python en C#. Ik bespreek de voordelen en nadelen van beide talen en hoe ik mijn keuze bepaal.", Publicatiedatum = new DateTime(2025, 1, 1) },
            new Blogpost { Id = 3, Titel = "Mijn eerste website", Inhoud = "In dit blog deel ik mijn ervaringen met het bouwen van mijn eerste website. Ik vertel over de uitdagingen die ik tegenkwam, de lessen die ik leerde en de tips die ik zou geven aan anderen die net beginnen.", Publicatiedatum = new DateTime(2026, 1, 1) },
            new Blogpost { Id = 4, Titel = "Code schoon houden", Inhoud = "In dit blog deel ik mijn ervaringen met het onderhouden van schoon code. Ik bespreek drie gewoontes die mij helpen om mijn projecten ook na maanden nog leesbaar en onderhoudbaar te houden.", Publicatiedatum = new DateTime(2026, 1, 1) },
            new Blogpost { Id = 5, Titel = "De kracht van kleine projecten", Inhoud = "In dit blog deel ik mijn ervaringen met het bouwen van kleine projecten. Ik bespreek de voordelen van kleine projecten, de lessen die ik leerde en hoe ze mijn vaardigheden als ontwikkelaar hebben verbeterd.", Publicatiedatum = new DateTime(2024, 1, 1) },
            new Blogpost { Id = 6, Titel = "Samenwerken in code", Inhoud = "In dit blog deel ik mijn ervaringen met het samenwerken in code. Ik bespreek de uitdagingen die ik tegenkwam, de tools die ik gebruikte en de lessen die ik leerde over effectief samenwerken.", Publicatiedatum = new DateTime(2025, 1, 1) }
        );
    }
}