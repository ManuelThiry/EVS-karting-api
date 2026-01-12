using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Services;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrackController : ControllerBase
{
    private readonly TrackService _service;
    public TrackController(TrackService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<TrackModel>>> GetAll() => await _service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<TrackModel?>> GetById(int id)
    {
        var track = await _service.GetByIdAsync(id);
        if (track == null) return NotFound();
        return track;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] TrackModel track)
    {
        if (track == null) return BadRequest();
        var created = await _service.CreateAsync(track);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TrackModel track)
    {
        if (id != track.Id) return BadRequest();
        var updated = await _service.UpdateAsync(track);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
