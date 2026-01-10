

namespace Repositories.Models;

public class TrackModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Length {get; set;} = string.Empty;
    public string Image { get; set; } = string.Empty;
}