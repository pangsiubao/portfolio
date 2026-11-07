using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Dtos;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogpostsController : ControllerBase
{
    private readonly BlogpostService _service;

    public BlogpostsController(BlogpostService service)
    {
        _service = service;
    }

    // GET api/blogposts
    [HttpGet]
    public async Task<ActionResult<List<BlogpostDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    // GET api/blogposts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BlogpostDto>> GetById(int id)
    {
        var blogpost = await _service.GetByIdAsync(id);
        return blogpost is null ? NotFound() : Ok(blogpost);
    }

    // POST api/blogposts
    [HttpPost]
    public async Task<ActionResult<BlogpostDto>> Create(BlogpostCreateDto dto)
    {
        var blogpost = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = blogpost.Id }, blogpost);
    }

    // PUT api/blogposts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, BlogpostCreateDto dto)
    {
        return await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();
    }

    // DELETE api/blogposts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
