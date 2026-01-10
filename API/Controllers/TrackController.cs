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
    public async Task<ActionResult> Create([FromBody] System.Text.Json.JsonElement body)
    {
        var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        if (body.ValueKind == System.Text.Json.JsonValueKind.Array)
        {
            var tracks = System.Text.Json.JsonSerializer.Deserialize<List<TrackModel>>(body.GetRawText(), options);
            if (tracks == null || tracks.Count == 0) return BadRequest();
            var created = new List<TrackModel>();
            foreach (var track in tracks)
                created.Add(await _service.CreateAsync(track));
            return Ok(created);
        }
        else if (body.ValueKind == System.Text.Json.JsonValueKind.Object)
        {
            var track = System.Text.Json.JsonSerializer.Deserialize<TrackModel>(body.GetRawText(), options);
            if (track == null) return BadRequest();
            var created = await _service.CreateAsync(track);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        else
        {
            return BadRequest();
        }
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
