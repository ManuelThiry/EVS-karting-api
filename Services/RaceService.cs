using Repositories.Models;
using Repositories.Queries;

namespace Services;

public class RaceService
{
    private readonly RaceQueries _queries;
    public RaceService(RaceQueries queries)
    {
        _queries = queries;
    }

    public Task<List<RaceModel>> GetAllAsync() => _queries.GetAllAsync();
    public Task<RaceModel?> GetByIdAsync(int id) => _queries.GetByIdAsync(id);
    public Task<RaceModel> CreateAsync(RaceModel race) => _queries.CreateAsync(race);
    public Task<bool> UpdateAsync(RaceModel race) => _queries.UpdateAsync(race);
    public Task<bool> DeleteAsync(int id) => _queries.DeleteAsync(id);
}
