

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

        modelBuilder.Entity<TrackModel>().HasData(
            new TrackModel { Id = 1, Name = "Experience Factory Eupen", Location = "Industriestraße 37, 4700 Eupen", Length = "1.1 km", Image = "https://s3.eu-west-3.amazonaws.com/sport-finder.image/images/cache/full_hd/center/karting-eupen.jpeg" },
            new TrackModel { Id = 2, Name = "Liege Karting", Location = "Rue Eugène Vandenhoff 88, 4030 Liège", Length = "530 m", Image = "https://www.liegekarting.com/upload/liege-karting-5b3b97-large.jpg" },
            new TrackModel { Id = 3, Name = "RACB Karting Spa-Francorchamps", Location = "Rte de l' Eau Rouge 51, 4970 Stavelot", Length = "1.0 km", Image = "https://www.francorchamps-karting.be/images/site/2024121814_1734530354e2.jpg" },
            new TrackModel { Id = 4, Name = "Karting des Fagnes", Location = "Rue du Karting 13, 5660 Couvin", Length = "1.3 km", Image = "https://www.lavenir.net/resizer/v2/AVCT2F553ZEFJEXQ3SEYOQRKN4.jpg?auth=0b9be8d04b9e73a078e70838860f29bc40f18b1287b72d0af458d09e9fa95987&width=1620&height=1085&quality=85&focal=512%2C343" },
            new TrackModel { Id = 5, Name = "Hurricane Dolhain Karting", Location = "Av. Reine Astrid 97/A, 4831 Limbourg", Length = "600 m", Image = "https://i.pinimg.com/564x/90/7c/2f/907c2f8ecc87c1688948ed0dee503761.jpg" },
            new TrackModel { Id = 6, Name = "", Location = "", Length = "", Image = "" }
        );

        modelBuilder.Entity<DriverModel>().HasData(
            new DriverModel { Id = 1, Name = "Manuel THIRY", Team = "A7 Core" },
            new DriverModel { Id = 2, Name = "Maxime BECKERS", Team = "A7 Core" },
            new DriverModel { Id = 3, Name = "Simon MAUDOUX", Team = "A7 Core" },
            new DriverModel { Id = 4, Name = "Pierre MIGNOLET", Team = "PGT" },
            new DriverModel { Id = 5, Name = "Thibaut MARECHAL", Team = "Enrich" },
            new DriverModel { Id = 6, Name = "Aubry HUYGHEBAERT", Team = string.Empty },
            new DriverModel { Id = 7, Name = "Jeremy MAHIAT", Team = "PGT" },
            new DriverModel { Id = 8, Name = "Pierre JACOBS", Team = string.Empty },
            new DriverModel { Id = 9, Name = "Quentin BOILEAU", Team = string.Empty },
            new DriverModel { Id = 10, Name = "Loic PETERS", Team = string.Empty },
            new DriverModel { Id = 11, Name = "Florian GIARUSSO", Team = string.Empty },
            new DriverModel { Id = 12, Name = "Mathieu WYZEN", Team = "Enrich" },
            new DriverModel { Id = 13, Name = "Nicolas VINCENT", Team = string.Empty },
            new DriverModel { Id = 14, Name = "Quentin VAN EYLEN", Team = "PGT" },
            new DriverModel { Id = 15, Name = "Cyril HARDY", Team = string.Empty },
            new DriverModel { Id = 16, Name = "Nicolas PREUD'HOMME", Team = string.Empty },
            new DriverModel { Id = 17, Name = "Arnaud SCHAAL", Team = "A7 Core" },
            new DriverModel { Id = 18, Name = "Xavier MAWET", Team = string.Empty },
            new DriverModel { Id = 19, Name = "Michael HUTSEMAIKERS", Team = string.Empty },
            new DriverModel { Id = 20, Name = "Gauthier VERHEUGE", Team = string.Empty },
            new DriverModel { Id = 21, Name = "Yannis ATIF", Team = string.Empty }
        );

        modelBuilder.Entity<RaceModel>().HasData(
           new RaceModel {
                Id = 1,
                Date = new DateTime(2026, 1, 15, 20, 0, 0, 585, DateTimeKind.Utc),
                Period = "January",
                Contact = "Manuel Thiry (MATH)",
                RaceFormat = "Q: 6min, R: 30min",
                Price = 56,
                Drivers = "Manuel THIRY, Maxime BECKERS, Simon MAUDOUX, Pierre MIGNOLET, Thibaut MARECHAL, Aubry HUYGHEBAERT, Jeremy MAHIAT, Pierre JACOBS, Quentin BOILEAU, Loic PETERS, Florian GIARUSSO, Mathieu WYZEN, Nicolas VINCENT, Quentin VAN EYLEN, Cyril HARDY, Nicolas PREUD'HOMME, Arnaud SCHAAL, Xavier MAWET, Michael HUTSEMAIKERS, Gauthier VERHEUGE, Yannis ATIF",
                Results = "{\"Qualif\":[{\"Position\":1,\"Name\":\"Manuel THIRY\",\"Time\":\"1:02.995\"},{\"Position\":2,\"Name\":\"Cyril HARDY\",\"Time\":\"1:03.203\"},{\"Position\":3,\"Name\":\"Gauthier VERHEUGE\",\"Time\":\"1:03.496\"},{\"Position\":4,\"Name\":\"Xavier MAWET\",\"Time\":\"1:03.946\"},{\"Position\":5,\"Name\":\"Nicolas PREUD'HOMME\",\"Time\":\"1:05.916\"},{\"Position\":6,\"Name\":\"Simon MAUDOUX\",\"Time\":\"1:06.004\"},{\"Position\":7,\"Name\":\"Thibaut MARECHAL\",\"Time\":\"1:06.570\"},{\"Position\":8,\"Name\":\"Loic PETERS\",\"Time\":\"1:06.631\"},{\"Position\":9,\"Name\":\"Quentin BOILEAU\",\"Time\":\"1:07.040\"},{\"Position\":10,\"Name\":\"Michael HUTSEMAIKERS\",\"Time\":\"1:07.154\"},{\"Position\":11,\"Name\":\"Pierre MIGNOLET\",\"Time\":\"1:07.370\"},{\"Position\":12,\"Name\":\"Jeremy MAHIAT\",\"Time\":\"1:07.656\"},{\"Position\":13,\"Name\":\"Pierre JACOBS\",\"Time\":\"1:08.575\"},{\"Position\":14,\"Name\":\"Yannis ATIF\",\"Time\":\"1:08.682\"},{\"Position\":15,\"Name\":\"Nicolas VINCENT\",\"Time\":\"1:08.984\"},{\"Position\":16,\"Name\":\"Florian GIARUSSO\",\"Time\":\"1:09.441\"},{\"Position\":17,\"Name\":\"Quentin VAN EYLEN\",\"Time\":\"1:09.472\"},{\"Position\":18,\"Name\":\"Maxime BECKERS\",\"Time\":\"1:10.494\"},{\"Position\":19,\"Name\":\"Aubry HUYGHEBAERT\",\"Time\":\"1:11.636\"},{\"Position\":20,\"Name\":\"Arnaud SCHAAL\",\"Time\":\"1:11.673\"},{\"Position\":21,\"Name\":\"Mathieu WYZEN\",\"Time\":\"1:21.777\"}],\"Race\":[{\"Position\":1,\"Name\":\"Cyril HARDY\",\"Gap\":\"\",\"BestLap\":\"1:01.648\"},{\"Position\":2,\"Name\":\"Manuel THIRY\",\"Gap\":\"1.748\",\"BestLap\":\"1:01.830\"},{\"Position\":3,\"Name\":\"Gauthier VERHEUGE\",\"Gap\":\"10.003\",\"BestLap\":\"1:02.157\"},{\"Position\":4,\"Name\":\"Xavier MAWET\",\"Gap\":\"10.716\",\"BestLap\":\"1:02.016\"},{\"Position\":5,\"Name\":\"Nicolas PREUD'HOMME\",\"Gap\":\"1 Laps\",\"BestLap\":\"1:03.929\"},{\"Position\":6,\"Name\":\"Simon MAUDOUX\",\"Gap\":\"1 Laps\",\"BestLap\":\"1:04.162\"},{\"Position\":7,\"Name\":\"Michael HUTSEMAIKERS\",\"Gap\":\"1 Laps\",\"BestLap\":\"1:04.187\"},{\"Position\":8,\"Name\":\"Quentin BOILEAU\",\"Gap\":\"1 Laps\",\"BestLap\":\"1:04.147\"},{\"Position\":9,\"Name\":\"Pierre MIGNOLET\",\"Gap\":\"1 Laps\",\"BestLap\":\"1:05.113\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Gap\":\"1 Laps\",\"BestLap\":\"1:04.908\"},{\"Position\":11,\"Name\":\"Pierre JACOBS\",\"Gap\":\"2 Laps\",\"BestLap\":\"1:05.418\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Gap\":\"2 Laps\",\"BestLap\":\"1:06.152\"},{\"Position\":13,\"Name\":\"Thibaut MARECHAL\",\"Gap\":\"2 Laps\",\"BestLap\":\"1:06.008\"},{\"Position\":14,\"Name\":\"Maxime BECKERS\",\"Gap\":\"2 Laps\",\"BestLap\":\"1:05.491\"},{\"Position\":15,\"Name\":\"Quentin VAN EYLEN\",\"Gap\":\"2 Laps\",\"BestLap\":\"1:05.536\"},{\"Position\":16,\"Name\":\"Yannis ATIF\",\"Gap\":\"2 Laps\",\"BestLap\":\"1:07.123\"},{\"Position\":17,\"Name\":\"Jeremy MAHIAT\",\"Gap\":\"2 Laps\",\"BestLap\":\"1:07.223\"},{\"Position\":18,\"Name\":\"Nicolas VINCENT\",\"Gap\":\"3 Laps\",\"BestLap\":\"1:07.626\"},{\"Position\":19,\"Name\":\"Florian GIARUSSO\",\"Gap\":\"3 Laps\",\"BestLap\":\"1:08.280\"},{\"Position\":20,\"Name\":\"Arnaud SCHAAL\",\"Gap\":\"3 Laps\",\"BestLap\":\"1:08.626\"},{\"Position\":21,\"Name\":\"Mathieu WYZEN\",\"Gap\":\"4 Laps\",\"BestLap\":\"1:13.238\"}]} ",
                TrackId = 1
            },
            new RaceModel {
                Id = 2,
                Date = null,
                Period = "March",
                Contact = "",
                RaceFormat = "Q: 6min, R: 30min",
                Price = 56,
                Drivers = "",
                Results = "",
                TrackId = 2
            },
            new RaceModel {
                Id = 3,
                Date = null,
                Period = "May",
                Contact = "",
                RaceFormat = "Q: 6min, R: 30min",
                Price = 56,
                Drivers = "",
                Results = "",
                TrackId = 3
            },
            new RaceModel {
                Id = 4,
                Date = null,
                Period = "July",
                Contact = "",
                RaceFormat = "Q: 6min, R: 30min",
                Price = 56,
                Drivers = "",
                Results = "",
                TrackId = 4
            },
            new RaceModel {
                Id = 5,
                Date = null,
                Period = "September",
                Contact = "",
                RaceFormat = "Q: 6min, R: 30min",
                Price = 56,
                Drivers = "",
                Results = "",
                TrackId = 5
            },
            new RaceModel {
                Id = 6,
                Date = null,
                Period = "November",
                Contact = "",
                RaceFormat = "Q: 6min, R: 30min",
                Price = 56,
                Drivers = "",
                Results = "",
                TrackId = 6
            }
        );
    }
}
