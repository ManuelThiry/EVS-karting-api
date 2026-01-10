using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using Repositories.Queries;
using Repositories;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriverController : ControllerBase
{
    private readonly DriverQueries _driverQueries;
    private readonly AppDbContext _context;
    public DriverController(DriverQueries driverQueries, AppDbContext context)
    {
        _driverQueries = driverQueries;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<DriverModel>>> GetAll()
        => await _driverQueries.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<DriverModel?>> GetById(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null) return NotFound();
        return driver;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] System.Text.Json.JsonElement body)
    {
        var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        if (body.ValueKind == System.Text.Json.JsonValueKind.Array)
        {
            var drivers = System.Text.Json.JsonSerializer.Deserialize<List<DriverModel>>(body.GetRawText(), options);
            if (drivers == null || drivers.Count == 0) return BadRequest();
            var existingNames = _context.Drivers.Select(d => d.Name).ToHashSet(StringComparer.OrdinalIgnoreCase);
            var duplicate = drivers.FirstOrDefault(d => existingNames.Contains(d.Name));
            if (duplicate != null)
                return Conflict($"Driver with name '{duplicate.Name}' already exists.");
            var batchNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var d in drivers)
                if (!batchNames.Add(d.Name))
                    return Conflict($"Duplicate name '{d.Name}' in the batch.");
            _context.Drivers.AddRange(drivers);
            await _context.SaveChangesAsync();
            return Ok(drivers);
        }
        else if (body.ValueKind == System.Text.Json.JsonValueKind.Object)
        {
            var driver = System.Text.Json.JsonSerializer.Deserialize<DriverModel>(body.GetRawText(), options);
            if (driver == null) return BadRequest();
            var exists = await _context.Drivers.AnyAsync(d => d.Name.ToLower() == driver.Name.ToLower());
            if (exists)
                return Conflict($"Driver with name '{driver.Name}' already exists.");
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = driver.Id }, driver);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DriverModel driver)
    {
        if (id != driver.Id) return BadRequest();
        var existing = await _context.Drivers.FindAsync(id);
        if (existing == null) return NotFound();
        existing.Name = driver.Name;
        existing.Team = driver.Team;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null) return NotFound();
        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
