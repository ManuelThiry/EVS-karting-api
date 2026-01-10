

using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<RaceModel> Races { get; set; } = null!;
    public DbSet<TrackModel> Tracks { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Tracks
        modelBuilder.Entity<TrackModel>().HasData(
            new TrackModel { Id = 2, Name = "Experience Factory Eupen", Location = "Industriestraße 37, 4700 Eupen", Length = "1.1 km", Image = "https://s3.eu-west-3.amazonaws.com/sport-finder.image/images/cache/full_hd/center/karting-eupen.jpeg" },
            new TrackModel { Id = 3, Name = "Liege Karting", Location = "Rue Eugène Vandenhoff 88, 4030 Liège", Length = "530 m", Image = "https://www.liegekarting.com/upload/liege-karting-5b3b97-large.jpg" },
            new TrackModel { Id = 4, Name = "RACB Karting Spa-Francorchamps", Location = "Rte de l' Eau Rouge 51, 4970 Stavelot", Length = "1.0 km", Image = "https://www.francorchamps-karting.be/images/site/2024121814_1734530354e2.jpg" },
            new TrackModel { Id = 5, Name = "Karting des Fagnes", Location = "Rue du Karting 13, 5660 Couvin", Length = "1.3 km", Image = "https://www.lavenir.net/resizer/v2/AVCT2F553ZEFJEXQ3SEYOQRKN4.jpg?auth=0b9be8d04b9e73a078e70838860f29bc40f18b1287b72d0af458d09e9fa95987&width=1620&height=1085&quality=85&focal=512%2C343" },
            new TrackModel { Id = 6, Name = "Hurricane Dolhain Karting", Location = "Av. Reine Astrid 97/A, 4831 Limbourg", Length = "600 m", Image = "https://i.pinimg.com/564x/90/7c/2f/907c2f8ecc87c1688948ed0dee503761.jpg" },
            new TrackModel { Id = 7, Name = "", Location = "", Length = "", Image = "" }
        );

        // Seed Races
        modelBuilder.Entity<RaceModel>().HasData(
            new RaceModel {
                Id = 2,
                Date = new DateTime(2026, 1, 15, 20, 0, 0, 585),
                Period = "January",
                Contact = "Manuel Thiry (MATH)",
                RaceFormat = "Q: 6min, R: 30min",
                Price = 56,
                Drivers = "Manuel THIRY, Maxime BECKERS, Simon MAUDOUX, Pierre MIGNOLET, Thibaut MARECHAL, Aubry HUYGHEBAERT, Jeremy MAHIAT, Pierre JACOBS, Quentin BOILEAU, Loic PETERS",
                Results = "",
                TrackId = 2
            },
            new RaceModel {
                Id = 3,
                Date = null,
                Period = "March",
                Contact = "",
                RaceFormat = "",
                Price = 0,
                Drivers = "",
                Results = "",
                TrackId = 3
            },
            new RaceModel {
                Id = 4,
                Date = null,
                Period = "May",
                Contact = "",
                RaceFormat = "",
                Price = 0,
                Drivers = "",
                Results = "",
                TrackId = 4
            },
            new RaceModel {
                Id = 5,
                Date = null,
                Period = "July",
                Contact = "",
                RaceFormat = "",
                Price = 0,
                Drivers = "",
                Results = "",
                TrackId = 5
            },
            new RaceModel {
                Id = 6,
                Date = null,
                Period = "September",
                Contact = "",
                RaceFormat = "",
                Price = 0,
                Drivers = "",
                Results = "",
                TrackId = 6
            },
            new RaceModel {
                Id = 7,
                Date = null,
                Period = "November",
                Contact = "",
                RaceFormat = "",
                Price = 0,
                Drivers = "",
                Results = "",
                TrackId = 7
            }
        );
    }
}
