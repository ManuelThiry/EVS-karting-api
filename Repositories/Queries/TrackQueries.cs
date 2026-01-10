using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories.Queries;

public class TrackQueries
{
    private readonly DbContext _context;
    public TrackQueries(DbContext context)
    {
        _context = context;
    }

    public async Task<List<TrackModel>> GetAllAsync()
        => await _context.Set<TrackModel>().ToListAsync();

    public async Task<TrackModel?> GetByIdAsync(int id)
        => await _context.Set<TrackModel>().FindAsync(id);

    public async Task<TrackModel> CreateAsync(TrackModel track)
    {
        _context.Set<TrackModel>().Add(track);
        await _context.SaveChangesAsync();
        return track;
    }

    public async Task<bool> UpdateAsync(TrackModel track)
    {
        _context.Set<TrackModel>().Update(track);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var track = await GetByIdAsync(id);
        if (track == null) return false;
        _context.Set<TrackModel>().Remove(track);
        return await _context.SaveChangesAsync() > 0;
    }
}
