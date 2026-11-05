using PortfolioApi.Models;

namespace PortfolioApi.Services;

public class ProjectService
{
    private readonly List<Project> _projecten = new()
    {
        new Project { Id = 1, Titel = "Dummy project 1", Beschrijving = "Een webapp in C# waarmee teams taken verdelen en deadlines bijhouden.", Categorie = "C#", Datum = new DateTime(2025, 1, 1) },
        new Project { Id = 2, Titel = "Portfolio Website", Beschrijving = "Een persoonlijke portfolio website gebouwd met HTML, CSS en JavaScript.", Categorie = "JavaScript", Datum = new DateTime(2026, 1, 1) },
        new Project { Id = 3, Titel = "E-commerce Platform", Beschrijving = "Een volledig functioneel e-commerce platform met winkelwagen en betalingsintegratie.", Categorie = "Python", Datum = new DateTime(2023, 1, 1) },
        new Project { Id = 4, Titel = "Mobile Game", Beschrijving = "Een mobiele game ontwikkeld met Unity en C#.", Categorie = "C#", Datum = new DateTime(2024, 1, 1) },
        new Project { Id = 5, Titel = "Data Analysis Tool", Beschrijving = "Een tool voor het analyseren van grote datasets met behulp van Python en Pandas.", Categorie = "Python", Datum = new DateTime(2022, 1, 1) },
    };

    public List<Project> GetAll() => _projecten;
}
