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
    public async Task<ActionResult> Create([FromBody] DriverModel driver)
    {
        if (driver == null) return BadRequest();
        var exists = await _context.Drivers.AnyAsync(d => d.Name.ToLower() == driver.Name.ToLower());
        if (exists)
            return Conflict($"Driver with name '{driver.Name}' already exists.");
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = driver.Id }, driver);
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
