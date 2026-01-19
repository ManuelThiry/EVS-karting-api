

using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<RaceModel> Races { get; set; } = null!;
    public DbSet<TrackModel> Tracks { get; set; } = null!;
    public DbSet<DriverModel> Drivers { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TrackModel>()
            .Property(t => t.Id)
            .UseIdentityColumn();

        modelBuilder.Entity<DriverModel>()
            .Property(d => d.Id)
            .UseIdentityColumn();

        modelBuilder.Entity<RaceModel>()
            .Property(r => r.Id)
            .UseIdentityColumn();
    }
}
