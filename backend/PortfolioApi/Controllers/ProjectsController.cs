using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Dtos;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectService _service;

    public ProjectsController(ProjectService service)
    {
        _service = service;
    }

    // GET api/projects
    [HttpGet]
    public async Task<ActionResult<List<ProjectDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    // GET api/projects/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDto>> GetById(int id)
    {
        var project = await _service.GetByIdAsync(id);
        return project is null ? NotFound() : Ok(project);
    }

    // POST api/projects
    [HttpPost]
    public async Task<ActionResult<ProjectDto>> Create(ProjectCreateDto dto)
    {
        var project = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    // PUT api/projects/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProjectCreateDto dto)
    {
        return await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();
    }

    // DELETE api/projects/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
