using PortfolioApi.Models;

namespace PortfolioApi.Services;

public class BlogpostService
{
    private readonly List<Blogpost> _blogposts = new()
    {
        new Blogpost { Id = 1, Titel = "Leren programmeren", Inhoud = "In dit blog deel ik mijn ervaringen met leren programmeren. Ik vertel over de eerste stappen die ik zette, de uitdagingen die ik tegenkwam en de lessen die ik leerde. Hopelijk kan mijn verhaal anderen inspireren en helpen bij hun eigen leerproces.", Publicatiedatum = new DateTime(2025, 1, 1) },
        new Blogpost { Id = 2, Titel = "Python of C#?", Inhoud = "In dit blog deel ik mijn ervaringen met het kiezen tussen Python en C#. Ik bespreek de voordelen en nadelen van beide talen en hoe ik mijn keuze bepaal.", Publicatiedatum = new DateTime(2025, 1, 1) },
        new Blogpost { Id = 3, Titel = "Mijn eerste website", Inhoud = "In dit blog deel ik mijn ervaringen met het bouwen van mijn eerste website. Ik vertel over de uitdagingen die ik tegenkwam, de lessen die ik leerde en de tips die ik zou geven aan anderen die net beginnen.", Publicatiedatum = new DateTime(2026, 1, 1) },
        new Blogpost { Id = 4, Titel = "Code schoon houden", Inhoud = "In dit blog deel ik mijn ervaringen met het onderhouden van schoon code. Ik bespreek drie gewoontes die mij helpen om mijn projecten ook na maanden nog leesbaar en onderhoudbaar te houden.", Publicatiedatum = new DateTime(2026, 1, 1) },
        new Blogpost { Id = 5, Titel = "De kracht van kleine projecten", Inhoud = "In dit blog deel ik mijn ervaringen met het bouwen van kleine projecten. Ik bespreek de voordelen van kleine projecten, de lessen die ik leerde en hoe ze mijn vaardigheden als ontwikkelaar hebben verbeterd.", Publicatiedatum = new DateTime(2024, 1, 1) },
        new Blogpost { Id = 6, Titel = "Samenwerken in code", Inhoud = "In dit blog deel ik mijn ervaringen met het samenwerken in code. Ik bespreek de uitdagingen die ik tegenkwam, de tools die ik gebruikte en de lessen die ik leerde over effectief samenwerken.", Publicatiedatum = new DateTime(2025, 1, 1) },
    };

    public List<Blogpost> GetAll() => _blogposts;
}