

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public class RaceModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime? Date { get; set; }
    public string Period { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public string RaceFormat { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Drivers { get; set; } = string.Empty;
    public string Results { get; set; } = string.Empty;

    public int TrackId { get; set; }
    public TrackModel? Track { get; set; }
}