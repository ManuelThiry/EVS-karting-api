
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Services;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RaceController : ControllerBase
{
    private readonly RaceService _service;
    public RaceController(RaceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<RaceModel>>> GetAll() => await _service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<RaceModel?>> GetById(int id)
    {
        var race = await _service.GetByIdAsync(id);
        if (race == null) return NotFound();
        return race;
    }


    [HttpPost]
    public async Task<ActionResult<RaceModel>> Create([FromBody] RaceDto raceDto)
    {
        var race = new RaceModel
        {
            Date = raceDto.Date,
            Period = raceDto.Period,
            Price = raceDto.Price,
            Contact = raceDto.Contact,
            RaceFormat = raceDto.RaceFormat,
            Drivers = raceDto.Drivers,
            Results = raceDto.Results,
            TrackId = raceDto.TrackId
        };
        var created = await _service.CreateAsync(race);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] RaceDto raceDto)
    {
        if (id != raceDto.Id) return BadRequest();
        var race = new RaceModel
        {
            Id = raceDto.Id,
            Date = raceDto.Date,
            Period = raceDto.Period,
            Price = raceDto.Price,
            Contact = raceDto.Contact,
            RaceFormat = raceDto.RaceFormat,
            Drivers = raceDto.Drivers,
            Results = raceDto.Results,
            TrackId = raceDto.TrackId
        };
        var updated = await _service.UpdateAsync(race);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpPatch("{id}/drivers")]
    public async Task<IActionResult> UpdateDrivers(int id, [FromBody] string drivers)
    {
        var race = await _service.GetByIdAsync(id);
        if (race == null) return NotFound();
        race.Drivers = drivers;
        var updated = await _service.UpdateAsync(race);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpPatch("{id}/results")]
    public async Task<IActionResult> UpdateResults(int id, [FromBody] ResultsDto results)
    {
        var race = await _service.GetByIdAsync(id);
        if (race == null) return NotFound();
        race.Results = System.Text.Json.JsonSerializer.Serialize(results);
        var updated = await _service.UpdateAsync(race);
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


    public class ResultsDto
    {
        public List<QualifDto> Qualif { get; set; } = new();
        public List<RaceResultDto> Race { get; set; } = new();
    }

    public class QualifDto
    {
        public int Position { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
    }

    public class RaceResultDto
    {
        public int Position { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gap { get; set; } = string.Empty;
    }

    public class RaceDto
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Period { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Contact { get; set; } = string.Empty;
        public string RaceFormat { get; set; } = string.Empty;
        public string Drivers { get; set; } = string.Empty;
        public string Results { get; set; } = string.Empty;
        public int TrackId { get; set; }
    }
}
