using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories.Queries;

public class RaceQueries
{
    private readonly DbContext _context;
    public RaceQueries(DbContext context)
    {
        _context = context;
    }


    public async Task<List<RaceModel>> GetAllAsync()
        => await _context.Set<RaceModel>()
            .Include(r => r.Track)
            .OrderBy(r => r.Id)
            .ToListAsync();


    public async Task<RaceModel?> GetByIdAsync(int id)
        => await _context.Set<RaceModel>()
            .Include(r => r.Track)
            .FirstOrDefaultAsync(r => r.Id == id);

    public async Task<RaceModel> CreateAsync(RaceModel race)
    {
        _context.Set<RaceModel>().Add(race);
        await _context.SaveChangesAsync();
        return race;
    }

    public async Task<bool> UpdateAsync(RaceModel race)
    {
        _context.Set<RaceModel>().Update(race);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var race = await GetByIdAsync(id);
        if (race == null) return false;
        _context.Set<RaceModel>().Remove(race);
        return await _context.SaveChangesAsync() > 0;
    }
}
