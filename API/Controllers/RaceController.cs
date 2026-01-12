
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Services;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RaceController : ControllerBase
{
    private readonly RaceService _service;
    private readonly Repositories.Queries.DriverQueries _driverQueries;
    public RaceController(RaceService service, Repositories.Queries.DriverQueries driverQueries)
    {
        _service = service;
        _driverQueries = driverQueries;
    }


    [HttpGet]
    public async Task<ActionResult<List<object>>> GetAll()
    {
        var races = await _service.GetAllAsync();
        return Ok(await EnrichRacesWithTeams(races));
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<object>> GetById(int id)
    {
        var race = await _service.GetByIdAsync(id);
        if (race == null) return NotFound();
        return Ok(await EnrichRaceWithTeams(race));
    }



    [HttpPost]
    public async Task<ActionResult> Create([FromBody] System.Text.Json.JsonElement body)
    {
        var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        if (body.ValueKind == System.Text.Json.JsonValueKind.Array)
        {
            var raceDtos = System.Text.Json.JsonSerializer.Deserialize<List<RaceDto>>(body.GetRawText(), options);
            if (raceDtos == null || raceDtos.Count == 0) return BadRequest();
            var created = new List<RaceModel>();
            foreach (var raceDto in raceDtos)
            {
                var driverNames = raceDto.Drivers.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                var foundDrivers = await _driverQueries.GetByNamesAsync(driverNames);
                if (foundDrivers.Count != driverNames.Length)
                {
                    var notFound = driverNames.Except(foundDrivers.Select(d => d.Name)).ToList();
                    return BadRequest($"Drivers not found: {string.Join(", ", notFound)}");
                }
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
                created.Add(await _service.CreateAsync(race));
            }
            return Ok(created);
        }
        else if (body.ValueKind == System.Text.Json.JsonValueKind.Object)
        {
            var raceDto = System.Text.Json.JsonSerializer.Deserialize<RaceDto>(body.GetRawText(), options);
            if (raceDto == null) return BadRequest();
            var driverNames = raceDto.Drivers.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var foundDrivers = await _driverQueries.GetByNamesAsync(driverNames);
            if (foundDrivers.Count != driverNames.Length)
            {
                var notFound = driverNames.Except(foundDrivers.Select(d => d.Name)).ToList();
                return BadRequest($"Drivers not found: {string.Join(", ", notFound)}");
            }
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
        else
        {
            return BadRequest();
        }
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] RaceDto raceDto)
    {
        if (id != raceDto.Id) return BadRequest();
        var driverNames = raceDto.Drivers.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var foundDrivers = await _driverQueries.GetByNamesAsync(driverNames);
        if (foundDrivers.Count != driverNames.Length)
        {
            var notFound = driverNames.Except(foundDrivers.Select(d => d.Name)).ToList();
            return BadRequest($"Drivers not found: {string.Join(", ", notFound)}");
        }
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
        var driverNames = drivers.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var foundDrivers = await _driverQueries.GetByNamesAsync(driverNames);
        if (foundDrivers.Count != driverNames.Length)
        {
            var notFound = driverNames.Except(foundDrivers.Select(d => d.Name)).ToList();
            return BadRequest($"Drivers not found: {string.Join(", ", notFound)}");
        }
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
        var allNames = results.Qualif.Select(q => q.Name).Concat(results.Race.Select(r => r.Name)).Distinct().ToArray();
        var foundDrivers = await _driverQueries.GetByNamesAsync(allNames);
        if (foundDrivers.Count != allNames.Length)
        {
            var notFound = allNames.Except(foundDrivers.Select(d => d.Name)).ToList();
            return BadRequest($"Drivers not found: {string.Join(", ", notFound)}");
        }
        var race = await _service.GetByIdAsync(id);
        if (race == null) return NotFound();
        race.Results = System.Text.Json.JsonSerializer.Serialize(results);
        var updated = await _service.UpdateAsync(race);
        if (!updated) return NotFound();
        return NoContent();
    }

    private async Task<object> EnrichRaceWithTeams(RaceModel race)
    {
        var drivers = race.Drivers.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var driverEntities = await _driverQueries.GetByNamesAsync(drivers);
        var driversWithTeams = driverEntities.Select(d => new { d.Name, d.Team }).ToList();

        ResultsDto? results = null;
        object? resultsWithTeams = null;
        if (!string.IsNullOrWhiteSpace(race.Results))
        {
            try
            {
                results = System.Text.Json.JsonSerializer.Deserialize<ResultsDto>(race.Results);
            }
            catch { }
        }
        if (results != null)
        {
            var allNames = results.Qualif.Select(q => q.Name).Concat(results.Race.Select(r => r.Name)).Distinct().ToArray();
            var resultDrivers = await _driverQueries.GetByNamesAsync(allNames);
            var nameToTeam = resultDrivers.ToDictionary(d => d.Name, d => d.Team);
            resultsWithTeams = new
            {
                Qualif = results.Qualif.Select(q => new {
                    q.Position,
                    q.Name,
                    q.Time,
                    Team = nameToTeam.TryGetValue(q.Name, out var team) ? team : string.Empty
                }).ToList(),
                Race = results.Race.Select(r => new {
                    r.Position,
                    r.Name,
                    r.Gap,
                    r.BestLap,
                    Team = nameToTeam.TryGetValue(r.Name, out var team) ? team : string.Empty
                }).ToList()
            };
        }

        return new
        {
            race.Id,
            race.Date,
            race.Period,
            race.Contact,
            race.RaceFormat,
            race.Price,
            Drivers = driversWithTeams,
            Results = resultsWithTeams,
            race.TrackId,
            race.Track
        };
    }

    private async Task<List<object>> EnrichRacesWithTeams(List<RaceModel> races)
    {
        var result = new List<object>();
        foreach (var race in races)
        {
            result.Add(await EnrichRaceWithTeams(race));
        }
        return result;
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
        public string BestLap { get; set; } = string.Empty;
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
