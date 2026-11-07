using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.Dtos;

// Wat de API ontvangt bij POST en PUT. Geen Id: die bepaalt de database.
public class BlogpostCreateDto
{
    [Required, MaxLength(100)]
    public string Titel { get; set; } = string.Empty;

    [Required]
    public string Inhoud { get; set; } = string.Empty;

    public DateTime Publicatiedatum { get; set; }
}
