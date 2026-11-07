using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.Dtos;
using PortfolioApi.Models;

namespace PortfolioApi.Services;

public class BlogpostService
{
    private readonly PortfolioDbContext _context;

    // De DbContext komt binnen via dependency injection (geregistreerd in Program.cs).
    public BlogpostService(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<BlogpostDto>> GetAllAsync()
    {
        var blogposts = await _context.Blogposts.AsNoTracking().ToListAsync();
        return blogposts.Select(ToDto).ToList();
    }

    public async Task<BlogpostDto?> GetByIdAsync(int id)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);
        return blogpost is null ? null : ToDto(blogpost);
    }

    public async Task<BlogpostDto> CreateAsync(BlogpostCreateDto dto)
    {
        var blogpost = new Blogpost
        {
            Titel = dto.Titel,
            Inhoud = dto.Inhoud,
            Publicatiedatum = dto.Publicatiedatum
        };

        _context.Blogposts.Add(blogpost);
        await _context.SaveChangesAsync();
        return ToDto(blogpost);
    }

    public async Task<bool> UpdateAsync(int id, BlogpostCreateDto dto)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);
        if (blogpost is null) return false;

        blogpost.Titel = dto.Titel;
        blogpost.Inhoud = dto.Inhoud;
        blogpost.Publicatiedatum = dto.Publicatiedatum;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);
        if (blogpost is null) return false;

        _context.Blogposts.Remove(blogpost);
        await _context.SaveChangesAsync();
        return true;
    }

    // Zet een EF Core-entiteit om naar een DTO, zodat de entiteit nooit de API verlaat.
    private static BlogpostDto ToDto(Blogpost b) => new()
    {
        Id = b.Id,
        Titel = b.Titel,
        Inhoud = b.Inhoud,
        Publicatiedatum = b.Publicatiedatum
    };
}
