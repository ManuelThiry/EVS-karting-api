using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories.Queries;

public class DriverQueries
{
    private readonly AppDbContext _context;
    public DriverQueries(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DriverModel>> GetAllAsync()
        => await _context.Drivers.ToListAsync();

    public async Task<DriverModel?> GetByNameAsync(string name)
        => await _context.Drivers.FirstOrDefaultAsync(d => d.Name == name);

    public async Task<List<DriverModel>> GetByNamesAsync(IEnumerable<string> names)
        => await _context.Drivers.Where(d => names.Contains(d.Name)).ToListAsync();
}
