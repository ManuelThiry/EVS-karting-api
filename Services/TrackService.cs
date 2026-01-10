using Repositories.Models;
using Repositories.Queries;

namespace Services;

public class TrackService
{
    private readonly TrackQueries _queries;
    public TrackService(TrackQueries queries)
    {
        _queries = queries;
    }

    public Task<List<TrackModel>> GetAllAsync() => _queries.GetAllAsync();
    public Task<TrackModel?> GetByIdAsync(int id) => _queries.GetByIdAsync(id);
    public Task<TrackModel> CreateAsync(TrackModel track) => _queries.CreateAsync(track);
    public Task<bool> UpdateAsync(TrackModel track) => _queries.UpdateAsync(track);
    public Task<bool> DeleteAsync(int id) => _queries.DeleteAsync(id);
}
