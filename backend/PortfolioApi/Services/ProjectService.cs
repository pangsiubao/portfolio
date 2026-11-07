using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.Dtos;
using PortfolioApi.Models;

namespace PortfolioApi.Services;

public class ProjectService
{
    private readonly PortfolioDbContext _context;

    // De DbContext komt binnen via dependency injection (geregistreerd in Program.cs).
    public ProjectService(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectDto>> GetAllAsync()
    {
        var projecten = await _context.Projects.AsNoTracking().ToListAsync();
        return projecten.Select(ToDto).ToList();
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        return project is null ? null : ToDto(project);
    }

    public async Task<ProjectDto> CreateAsync(ProjectCreateDto dto)
    {
        var project = new Project
        {
            Titel = dto.Titel,
            Beschrijving = dto.Beschrijving,
            Categorie = dto.Categorie,
            GitHubUrl = dto.GitHubUrl,
            Datum = dto.Datum
        };

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return ToDto(project);
    }

    public async Task<bool> UpdateAsync(int id, ProjectCreateDto dto)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is null) return false;

        project.Titel = dto.Titel;
        project.Beschrijving = dto.Beschrijving;
        project.Categorie = dto.Categorie;
        project.GitHubUrl = dto.GitHubUrl;
        project.Datum = dto.Datum;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is null) return false;

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return true;
    }

    // Zet een EF Core-entiteit om naar een DTO, zodat de entiteit nooit de API verlaat.
    private static ProjectDto ToDto(Project p) => new()
    {
        Id = p.Id,
        Titel = p.Titel,
        Beschrijving = p.Beschrijving,
        Categorie = p.Categorie,
        GitHubUrl = p.GitHubUrl,
        Datum = p.Datum
    };
}
