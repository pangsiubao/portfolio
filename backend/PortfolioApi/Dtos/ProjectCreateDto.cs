using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.Dtos;

// Wat de API ontvangt bij POST en PUT. Geen Id: die bepaalt de database.
public class ProjectCreateDto
{
    [Required, MaxLength(100)]
    public string Titel { get; set; } = string.Empty;

    [Required]
    public string Beschrijving { get; set; } = string.Empty;

    [Required]
    public string Categorie { get; set; } = string.Empty;

    [Url]
    public string? GitHubUrl { get; set; }

    public DateTime Datum { get; set; }
}
