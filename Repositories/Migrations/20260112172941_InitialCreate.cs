using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Team = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Length = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Period = table.Column<string>(type: "TEXT", nullable: false),
                    Contact = table.Column<string>(type: "TEXT", nullable: false),
                    RaceFormat = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Drivers = table.Column<string>(type: "TEXT", nullable: false),
                    Results = table.Column<string>(type: "TEXT", nullable: false),
                    TrackId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Races_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Name", "Team" },
                values: new object[,]
                {
                    { 1, "Manuel THIRY", "A7 Core" },
                    { 2, "Maxime BECKERS", "A7 Core" },
                    { 3, "Simon MAUDOUX", "A7 Core" },
                    { 4, "Pierre MIGNOLET", "PGT" },
                    { 5, "Thibaut MARECHAL", "Enrich" },
                    { 6, "Aubry HUYGHEBAERT", "" },
                    { 7, "Jeremy MAHIAT", "PGT" },
                    { 8, "Pierre JACOBS", "" },
                    { 9, "Quentin BOILEAU", "" },
                    { 10, "Loic PETERS", "" },
                    { 11, "Florian GIARUSSO", "" },
                    { 12, "Mathieu WYZEN", "Enrich" },
                    { 13, "Raphael MONTESANTI", "" },
                    { 14, "Quentin VAN EYLEN", "PGT" },
                    { 15, "Cyril HARDY", "" },
                    { 16, "Nicolas PREUD'HOMME", "" },
                    { 17, "Arnaud SCHAAL", "A7 Core" },
                    { 18, "Xavier MAWET", "" },
                    { 19, "Michael HUTSEMAIKERS", "" },
                    { 20, "UNKNOWN", "" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Image", "Length", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "https://s3.eu-west-3.amazonaws.com/sport-finder.image/images/cache/full_hd/center/karting-eupen.jpeg", "1.1 km", "Industriestraße 37, 4700 Eupen", "Experience Factory Eupen" },
                    { 2, "https://www.liegekarting.com/upload/liege-karting-5b3b97-large.jpg", "530 m", "Rue Eugène Vandenhoff 88, 4030 Liège", "Liege Karting" },
                    { 3, "https://www.francorchamps-karting.be/images/site/2024121814_1734530354e2.jpg", "1.0 km", "Rte de l' Eau Rouge 51, 4970 Stavelot", "RACB Karting Spa-Francorchamps" },
                    { 4, "https://www.lavenir.net/resizer/v2/AVCT2F553ZEFJEXQ3SEYOQRKN4.jpg?auth=0b9be8d04b9e73a078e70838860f29bc40f18b1287b72d0af458d09e9fa95987&width=1620&height=1085&quality=85&focal=512%2C343", "1.3 km", "Rue du Karting 13, 5660 Couvin", "Karting des Fagnes" },
                    { 5, "https://i.pinimg.com/564x/90/7c/2f/907c2f8ecc87c1688948ed0dee503761.jpg", "600 m", "Av. Reine Astrid 97/A, 4831 Limbourg", "Hurricane Dolhain Karting" },
                    { 6, "", "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "Contact", "Date", "Drivers", "Period", "Price", "RaceFormat", "Results", "TrackId" },
                values: new object[,]
                {
                    { 1, "Manuel Thiry (MATH)", new DateTime(2026, 1, 15, 20, 0, 0, 585, DateTimeKind.Utc), "Manuel THIRY, Maxime BECKERS, Simon MAUDOUX, Pierre MIGNOLET, Thibaut MARECHAL, Aubry HUYGHEBAERT, Jeremy MAHIAT, Pierre JACOBS, Quentin BOILEAU, Loic PETERS, Florian GIARUSSO, Mathieu WYZEN, Raphael MONTESANTI, Quentin VAN EYLEN, Cyril HARDY, Nicolas PREUD'HOMME, Arnaud SCHAAL, Xavier MAWET, Michael HUTSEMAIKERS, UNKNOWN", "January", 56, "Q: 6min, R: 30min", "{\"Qualif\":[{\"Position\":1,\"Name\":\"Pierre JACOBS\",\"Time\":\"1:00.123\"},{\"Position\":2,\"Name\":\"Jeremy MAHIAT\",\"Time\":\"1:00.456\"},{\"Position\":3,\"Name\":\"Simon MAUDOUX\",\"Time\":\"1:00.789\"},{\"Position\":4,\"Name\":\"Maxime BECKERS\",\"Time\":\"1:01.012\"},{\"Position\":5,\"Name\":\"Raphael MONTESANTI\",\"Time\":\"1:01.345\"},{\"Position\":6,\"Name\":\"Aubry HUYGHEBAERT\",\"Time\":\"1:01.678\"},{\"Position\":7,\"Name\":\"Cyril HARDY\",\"Time\":\"1:02.001\"},{\"Position\":8,\"Name\":\"Quentin VAN EYLEN\",\"Time\":\"1:02.234\"},{\"Position\":9,\"Name\":\"Loic PETERS\",\"Time\":\"1:02.567\"},{\"Position\":10,\"Name\":\"Mathieu WYZEN\",\"Time\":\"1:02.890\"},{\"Position\":11,\"Name\":\"Michael HUTSEMAIKERS\",\"Time\":\"1:03.123\"},{\"Position\":12,\"Name\":\"Nicolas PREUD'HOMME\",\"Time\":\"1:03.456\"},{\"Position\":13,\"Name\":\"Pierre MIGNOLET\",\"Time\":\"1:03.789\"},{\"Position\":14,\"Name\":\"Xavier Mawet\",\"Time\":\"1:04.012\"},{\"Position\":15,\"Name\":\"Thibaut MARECHAL\",\"Time\":\"1:04.345\"},{\"Position\":16,\"Name\":\"Manuel THIRY\",\"Time\":\"1:04.678\"},{\"Position\":17,\"Name\":\"Arnaud SCHAAL\",\"Time\":\"1:05.001\"},{\"Position\":18,\"Name\":\"Florian GIARUSSO\",\"Time\":\"1:05.234\"},{\"Position\":19,\"Name\":\"Quentin BOILEAU\",\"Time\":\"1:05.567\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Time\":\"1:05.890\"}],\"Race\":[{\"Position\":1,\"Name\":\"Maxime BECKERS\",\"Gap\":\"+0.000\",\"BestLap\":\"1:00.200\"},{\"Position\":2,\"Name\":\"Pierre MIGNOLET\",\"Gap\":\"+2.123\",\"BestLap\":\"1:00.400\"},{\"Position\":3,\"Name\":\"Simon MAUDOUX\",\"Gap\":\"+4.456\",\"BestLap\":\"1:00.300\"},{\"Position\":4,\"Name\":\"Manuel THIRY\",\"Gap\":\"+6.789\",\"BestLap\":\"1:01.600\"},{\"Position\":5,\"Name\":\"Pierre JACOBS\",\"Gap\":\"+9.012\",\"BestLap\":\"1:00.100\"},{\"Position\":6,\"Name\":\"Jeremy MAHIAT\",\"Gap\":\"+11.345\",\"BestLap\":\"1:00.700\"},{\"Position\":7,\"Name\":\"Thibaut MARECHAL\",\"Gap\":\"+13.678\",\"BestLap\":\"1:01.500\"},{\"Position\":8,\"Name\":\"Quentin VAN EYLEN\",\"Gap\":\"+16.001\",\"BestLap\":\"1:00.800\"},{\"Position\":9,\"Name\":\"Cyril HARDY\",\"Gap\":\"+18.234\",\"BestLap\":\"1:01.700\"},{\"Position\":10,\"Name\":\"Aubry HUYGHEBAERT\",\"Gap\":\"+20.567\",\"BestLap\":\"1:00.600\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Gap\":\"+22.890\",\"BestLap\":\"1:01.200\"},{\"Position\":12,\"Name\":\"Florian GIARUSSO\",\"Gap\":\"+25.123\",\"BestLap\":\"1:01.800\"},{\"Position\":13,\"Name\":\"Raphael MONTESANTI\",\"Gap\":\"+27.456\",\"BestLap\":\"1:01.300\"},{\"Position\":14,\"Name\":\"Loic PETERS\",\"Gap\":\"+29.789\",\"BestLap\":\"1:01.000\"},{\"Position\":15,\"Name\":\"Nicolas PREUD'HOMME\",\"Gap\":\"+32.012\",\"BestLap\":\"1:01.900\"},{\"Position\":16,\"Name\":\"Michael HUTSEMAIKERS\",\"Gap\":\"+34.345\",\"BestLap\":\"1:02.000\"},{\"Position\":17,\"Name\":\"Xavier Mawet\",\"Gap\":\"+36.678\",\"BestLap\":\"1:01.400\"},{\"Position\":18,\"Name\":\"Quentin BOILEAU\",\"Gap\":\"+39.001\",\"BestLap\":\"1:01.100\"},{\"Position\":19,\"Name\":\"Raphael MONTESANTI\",\"Gap\":\"+41.234\",\"BestLap\":\"1:01.500\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Gap\":\"+43.567\",\"BestLap\":\"1:02.100\"}]}", 1 },
                    { 2, "", null, "Manuel THIRY, Maxime BECKERS, Simon MAUDOUX, Pierre MIGNOLET, Thibaut MARECHAL, Aubry HUYGHEBAERT, Jeremy MAHIAT, Pierre JACOBS, Quentin BOILEAU, Loic PETERS, Florian GIARUSSO, Mathieu WYZEN, Raphael MONTESANTI, Quentin VAN EYLEN, Cyril HARDY, Nicolas PREUD'HOMME, Arnaud SCHAAL, Xavier MAWET, Michael HUTSEMAIKERS, UNKNOWN", "March", 56, "Q: 6min, R: 30min", "{\"Qualif\":[{\"Position\":1,\"Name\":\"Simon MAUDOUX\",\"Time\":\"1:00.321\"},{\"Position\":2,\"Name\":\"Pierre MIGNOLET\",\"Time\":\"1:00.654\"},{\"Position\":3,\"Name\":\"Maxime BECKERS\",\"Time\":\"1:00.987\"},{\"Position\":4,\"Name\":\"Manuel THIRY\",\"Time\":\"1:01.210\"},{\"Position\":5,\"Name\":\"Thibaut MARECHAL\",\"Time\":\"1:01.543\"},{\"Position\":6,\"Name\":\"Raphael MONTESANTI\",\"Time\":\"1:01.876\"},{\"Position\":7,\"Name\":\"Pierre JACOBS\",\"Time\":\"1:02.209\"},{\"Position\":8,\"Name\":\"Jeremy MAHIAT\",\"Time\":\"1:02.542\"},{\"Position\":9,\"Name\":\"Quentin VAN EYLEN\",\"Time\":\"1:02.875\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Time\":\"1:03.108\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Time\":\"1:03.441\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Time\":\"1:03.774\"},{\"Position\":13,\"Name\":\"Florian GIARUSSO\",\"Time\":\"1:04.107\"},{\"Position\":14,\"Name\":\"Nicolas PREUD'HOMME\",\"Time\":\"1:04.440\"},{\"Position\":15,\"Name\":\"Cyril HARDY\",\"Time\":\"1:04.773\"},{\"Position\":16,\"Name\":\"Arnaud SCHAAL\",\"Time\":\"1:05.106\"},{\"Position\":17,\"Name\":\"Xavier MAWET\",\"Time\":\"1:05.439\"},{\"Position\":18,\"Name\":\"Michael HUTSEMAIKERS\",\"Time\":\"1:05.772\"},{\"Position\":19,\"Name\":\"Quentin BOILEAU\",\"Time\":\"1:06.105\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Time\":\"1:06.438\"}],\"Race\":[{\"Position\":1,\"Name\":\"Pierre MIGNOLET\",\"Gap\":\"+0.000\",\"BestLap\":\"1:00.654\"},{\"Position\":2,\"Name\":\"Simon MAUDOUX\",\"Gap\":\"+1.321\",\"BestLap\":\"1:00.321\"},{\"Position\":3,\"Name\":\"Maxime BECKERS\",\"Gap\":\"+2.654\",\"BestLap\":\"1:00.987\"},{\"Position\":4,\"Name\":\"Manuel THIRY\",\"Gap\":\"+3.987\",\"BestLap\":\"1:01.210\"},{\"Position\":5,\"Name\":\"Thibaut MARECHAL\",\"Gap\":\"+5.210\",\"BestLap\":\"1:01.543\"},{\"Position\":6,\"Name\":\"Raphael MONTESANTI\",\"Gap\":\"+6.543\",\"BestLap\":\"1:01.876\"},{\"Position\":7,\"Name\":\"Pierre JACOBS\",\"Gap\":\"+7.876\",\"BestLap\":\"1:02.209\"},{\"Position\":8,\"Name\":\"Jeremy MAHIAT\",\"Gap\":\"+9.209\",\"BestLap\":\"1:02.542\"},{\"Position\":9,\"Name\":\"Quentin VAN EYLEN\",\"Gap\":\"+10.542\",\"BestLap\":\"1:02.875\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Gap\":\"+11.875\",\"BestLap\":\"1:03.108\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Gap\":\"+13.108\",\"BestLap\":\"1:03.441\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Gap\":\"+14.441\",\"BestLap\":\"1:03.774\"},{\"Position\":13,\"Name\":\"Florian GIARUSSO\",\"Gap\":\"+15.774\",\"BestLap\":\"1:04.107\"},{\"Position\":14,\"Name\":\"Nicolas PREUD'HOMME\",\"Gap\":\"+17.107\",\"BestLap\":\"1:04.440\"},{\"Position\":15,\"Name\":\"Cyril HARDY\",\"Gap\":\"+18.440\",\"BestLap\":\"1:04.773\"},{\"Position\":16,\"Name\":\"Arnaud SCHAAL\",\"Gap\":\"+19.773\",\"BestLap\":\"1:05.106\"},{\"Position\":17,\"Name\":\"Xavier MAWET\",\"Gap\":\"+21.106\",\"BestLap\":\"1:05.439\"},{\"Position\":18,\"Name\":\"Michael HUTSEMAIKERS\",\"Gap\":\"+22.439\",\"BestLap\":\"1:05.772\"},{\"Position\":19,\"Name\":\"Quentin BOILEAU\",\"Gap\":\"+23.772\",\"BestLap\":\"1:06.105\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Gap\":\"+25.105\",\"BestLap\":\"1:06.438\"}]}", 2 },
                    { 3, "", null, "Manuel THIRY, Maxime BECKERS, Simon MAUDOUX, Pierre MIGNOLET, Thibaut MARECHAL, Aubry HUYGHEBAERT, Jeremy MAHIAT, Pierre JACOBS, Quentin BOILEAU, Loic PETERS, Florian GIARUSSO, Mathieu WYZEN, Raphael MONTESANTI, Quentin VAN EYLEN, Cyril HARDY, Nicolas PREUD'HOMME, Arnaud SCHAAL, Xavier MAWET, Michael HUTSEMAIKERS, UNKNOWN", "May", 56, "Q: 6min, R: 30min", "{\"Qualif\":[{\"Position\":1,\"Name\":\"Maxime BECKERS\",\"Time\":\"1:00.555\"},{\"Position\":2,\"Name\":\"Manuel THIRY\",\"Time\":\"1:00.888\"},{\"Position\":3,\"Name\":\"Pierre MIGNOLET\",\"Time\":\"1:01.111\"},{\"Position\":4,\"Name\":\"Simon MAUDOUX\",\"Time\":\"1:01.444\"},{\"Position\":5,\"Name\":\"Pierre JACOBS\",\"Time\":\"1:01.777\"},{\"Position\":6,\"Name\":\"Thibaut MARECHAL\",\"Time\":\"1:02.000\"},{\"Position\":7,\"Name\":\"Raphael MONTESANTI\",\"Time\":\"1:02.333\"},{\"Position\":8,\"Name\":\"Jeremy MAHIAT\",\"Time\":\"1:02.666\"},{\"Position\":9,\"Name\":\"Quentin BOILEAU\",\"Time\":\"1:02.999\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Time\":\"1:03.222\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Time\":\"1:03.555\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Time\":\"1:03.888\"},{\"Position\":13,\"Name\":\"Florian GIARUSSO\",\"Time\":\"1:04.111\"},{\"Position\":14,\"Name\":\"Nicolas PREUD'HOMME\",\"Time\":\"1:04.444\"},{\"Position\":15,\"Name\":\"Cyril HARDY\",\"Time\":\"1:04.777\"},{\"Position\":16,\"Name\":\"Arnaud SCHAAL\",\"Time\":\"1:05.000\"},{\"Position\":17,\"Name\":\"Xavier MAWET\",\"Time\":\"1:05.333\"},{\"Position\":18,\"Name\":\"Michael HUTSEMAIKERS\",\"Time\":\"1:05.666\"},{\"Position\":19,\"Name\":\"Quentin VAN EYLEN\",\"Time\":\"1:05.999\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Time\":\"1:06.222\"}],\"Race\":[{\"Position\":1,\"Name\":\"Manuel THIRY\",\"Gap\":\"+0.000\",\"BestLap\":\"1:00.888\"},{\"Position\":2,\"Name\":\"Maxime BECKERS\",\"Gap\":\"+1.555\",\"BestLap\":\"1:00.555\"},{\"Position\":3,\"Name\":\"Pierre MIGNOLET\",\"Gap\":\"+2.888\",\"BestLap\":\"1:01.111\"},{\"Position\":4,\"Name\":\"Simon MAUDOUX\",\"Gap\":\"+4.111\",\"BestLap\":\"1:01.444\"},{\"Position\":5,\"Name\":\"Pierre JACOBS\",\"Gap\":\"+5.444\",\"BestLap\":\"1:01.777\"},{\"Position\":6,\"Name\":\"Thibaut MARECHAL\",\"Gap\":\"+6.777\",\"BestLap\":\"1:02.000\"},{\"Position\":7,\"Name\":\"Raphael MONTESANTI\",\"Gap\":\"+8.000\",\"BestLap\":\"1:02.333\"},{\"Position\":8,\"Name\":\"Jeremy MAHIAT\",\"Gap\":\"+9.333\",\"BestLap\":\"1:02.666\"},{\"Position\":9,\"Name\":\"Quentin BOILEAU\",\"Gap\":\"+10.666\",\"BestLap\":\"1:02.999\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Gap\":\"+11.999\",\"BestLap\":\"1:03.222\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Gap\":\"+13.222\",\"BestLap\":\"1:03.555\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Gap\":\"+14.555\",\"BestLap\":\"1:03.888\"},{\"Position\":13,\"Name\":\"Florian GIARUSSO\",\"Gap\":\"+15.888\",\"BestLap\":\"1:04.111\"},{\"Position\":14,\"Name\":\"Nicolas PREUD'HOMME\",\"Gap\":\"+17.111\",\"BestLap\":\"1:04.444\"},{\"Position\":15,\"Name\":\"Cyril HARDY\",\"Gap\":\"+18.444\",\"BestLap\":\"1:04.777\"},{\"Position\":16,\"Name\":\"Arnaud SCHAAL\",\"Gap\":\"+19.777\",\"BestLap\":\"1:05.000\"},{\"Position\":17,\"Name\":\"Xavier MAWET\",\"Gap\":\"+21.333\",\"BestLap\":\"1:05.333\"},{\"Position\":18,\"Name\":\"Michael HUTSEMAIKERS\",\"Gap\":\"+22.666\",\"BestLap\":\"1:05.666\"},{\"Position\":19,\"Name\":\"Quentin VAN EYLEN\",\"Gap\":\"+23.999\",\"BestLap\":\"1:05.999\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Gap\":\"+25.222\",\"BestLap\":\"1:06.222\"}]}", 3 },
                    { 4, "", null, "Manuel THIRY, Maxime BECKERS, Simon MAUDOUX, Pierre MIGNOLET, Thibaut MARECHAL, Aubry HUYGHEBAERT, Jeremy MAHIAT, Pierre JACOBS, Quentin BOILEAU, Loic PETERS, Florian GIARUSSO, Mathieu WYZEN, Raphael MONTESANTI, Quentin VAN EYLEN, Cyril HARDY, Nicolas PREUD'HOMME, Arnaud SCHAAL, Xavier MAWET, Michael HUTSEMAIKERS, UNKNOWN", "July", 56, "Q: 6min, R: 30min", "{\"Qualif\":[{\"Position\":1,\"Name\":\"Jeremy MAHIAT\",\"Time\":\"1:00.777\"},{\"Position\":2,\"Name\":\"Pierre JACOBS\",\"Time\":\"1:01.000\"},{\"Position\":3,\"Name\":\"Pierre MIGNOLET\",\"Time\":\"1:01.333\"},{\"Position\":4,\"Name\":\"Simon MAUDOUX\",\"Time\":\"1:01.666\"},{\"Position\":5,\"Name\":\"Maxime BECKERS\",\"Time\":\"1:01.999\"},{\"Position\":6,\"Name\":\"Manuel THIRY\",\"Time\":\"1:02.222\"},{\"Position\":7,\"Name\":\"Thibaut MARECHAL\",\"Time\":\"1:02.555\"},{\"Position\":8,\"Name\":\"Raphael MONTESANTI\",\"Time\":\"1:02.888\"},{\"Position\":9,\"Name\":\"Quentin BOILEAU\",\"Time\":\"1:03.111\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Time\":\"1:03.444\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Time\":\"1:03.777\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Time\":\"1:04.000\"},{\"Position\":13,\"Name\":\"Florian GIARUSSO\",\"Time\":\"1:04.333\"},{\"Position\":14,\"Name\":\"Nicolas PREUD'HOMME\",\"Time\":\"1:04.666\"},{\"Position\":15,\"Name\":\"Cyril HARDY\",\"Time\":\"1:04.999\"},{\"Position\":16,\"Name\":\"Arnaud SCHAAL\",\"Time\":\"1:05.222\"},{\"Position\":17,\"Name\":\"Xavier MAWET\",\"Time\":\"1:05.555\"},{\"Position\":18,\"Name\":\"Michael HUTSEMAIKERS\",\"Time\":\"1:05.888\"},{\"Position\":19,\"Name\":\"Quentin VAN EYLEN\",\"Time\":\"1:06.111\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Time\":\"1:06.444\"}],\"Race\":[{\"Position\":1,\"Name\":\"Pierre JACOBS\",\"Gap\":\"+0.000\",\"BestLap\":\"1:01.000\"},{\"Position\":2,\"Name\":\"Jeremy MAHIAT\",\"Gap\":\"+1.777\",\"BestLap\":\"1:00.777\"},{\"Position\":3,\"Name\":\"Pierre MIGNOLET\",\"Gap\":\"+3.000\",\"BestLap\":\"1:01.333\"},{\"Position\":4,\"Name\":\"Simon MAUDOUX\",\"Gap\":\"+4.333\",\"BestLap\":\"1:01.666\"},{\"Position\":5,\"Name\":\"Maxime BECKERS\",\"Gap\":\"+5.666\",\"BestLap\":\"1:01.999\"},{\"Position\":6,\"Name\":\"Manuel THIRY\",\"Gap\":\"+6.999\",\"BestLap\":\"1:02.222\"},{\"Position\":7,\"Name\":\"Thibaut MARECHAL\",\"Gap\":\"+8.222\",\"BestLap\":\"1:02.555\"},{\"Position\":8,\"Name\":\"Raphael MONTESANTI\",\"Gap\":\"+9.555\",\"BestLap\":\"1:02.888\"},{\"Position\":9,\"Name\":\"Quentin BOILEAU\",\"Gap\":\"+10.888\",\"BestLap\":\"1:03.111\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Gap\":\"+12.111\",\"BestLap\":\"1:03.444\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Gap\":\"+13.444\",\"BestLap\":\"1:03.777\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Gap\":\"+14.777\",\"BestLap\":\"1:04.000\"},{\"Position\":13,\"Name\":\"Florian GIARUSSO\",\"Gap\":\"+16.111\",\"BestLap\":\"1:04.333\"},{\"Position\":14,\"Name\":\"Nicolas PREUD'HOMME\",\"Gap\":\"+17.444\",\"BestLap\":\"1:04.666\"},{\"Position\":15,\"Name\":\"Cyril HARDY\",\"Gap\":\"+18.777\",\"BestLap\":\"1:04.999\"},{\"Position\":16,\"Name\":\"Arnaud SCHAAL\",\"Gap\":\"+20.222\",\"BestLap\":\"1:05.222\"},{\"Position\":17,\"Name\":\"Xavier MAWET\",\"Gap\":\"+21.555\",\"BestLap\":\"1:05.555\"},{\"Position\":18,\"Name\":\"Michael HUTSEMAIKERS\",\"Gap\":\"+22.888\",\"BestLap\":\"1:05.888\"},{\"Position\":19,\"Name\":\"Quentin VAN EYLEN\",\"Gap\":\"+24.111\",\"BestLap\":\"1:06.111\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Gap\":\"+25.444\",\"BestLap\":\"1:06.444\"}]}", 4 },
                    { 5, "", null, "Manuel THIRY, Maxime BECKERS, Simon MAUDOUX, Pierre MIGNOLET, Thibaut MARECHAL, Aubry HUYGHEBAERT, Jeremy MAHIAT, Pierre JACOBS, Quentin BOILEAU, Loic PETERS, Florian GIARUSSO, Mathieu WYZEN, Raphael MONTESANTI, Quentin VAN EYLEN, Cyril HARDY, Nicolas PREUD'HOMME, Arnaud SCHAAL, Xavier MAWET, Michael HUTSEMAIKERS, UNKNOWN", "September", 56, "Q: 6min, R: 30min", "{\"Qualif\":[{\"Position\":1,\"Name\":\"Raphael MONTESANTI\",\"Time\":\"1:00.999\"},{\"Position\":2,\"Name\":\"Pierre MIGNOLET\",\"Time\":\"1:01.222\"},{\"Position\":3,\"Name\":\"Simon MAUDOUX\",\"Time\":\"1:01.555\"},{\"Position\":4,\"Name\":\"Maxime BECKERS\",\"Time\":\"1:01.888\"},{\"Position\":5,\"Name\":\"Pierre JACOBS\",\"Time\":\"1:02.111\"},{\"Position\":6,\"Name\":\"Thibaut MARECHAL\",\"Time\":\"1:02.444\"},{\"Position\":7,\"Name\":\"Manuel THIRY\",\"Time\":\"1:02.777\"},{\"Position\":8,\"Name\":\"Jeremy MAHIAT\",\"Time\":\"1:03.000\"},{\"Position\":9,\"Name\":\"Quentin BOILEAU\",\"Time\":\"1:03.333\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Time\":\"1:03.666\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Time\":\"1:03.999\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Time\":\"1:04.222\"},{\"Position\":13,\"Name\":\"Florian GIARUSSO\",\"Time\":\"1:04.555\"},{\"Position\":14,\"Name\":\"Nicolas PREUD'HOMME\",\"Time\":\"1:04.888\"},{\"Position\":15,\"Name\":\"Cyril HARDY\",\"Time\":\"1:05.111\"},{\"Position\":16,\"Name\":\"Arnaud SCHAAL\",\"Time\":\"1:05.444\"},{\"Position\":17,\"Name\":\"Xavier MAWET\",\"Time\":\"1:05.777\"},{\"Position\":18,\"Name\":\"Michael HUTSEMAIKERS\",\"Time\":\"1:06.000\"},{\"Position\":19,\"Name\":\"Quentin VAN EYLEN\",\"Time\":\"1:06.333\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Time\":\"1:06.666\"}],\"Race\":[{\"Position\":1,\"Name\":\"Raphael MONTESANTI\",\"Gap\":\"+0.000\",\"BestLap\":\"1:00.999\"},{\"Position\":2,\"Name\":\"Pierre MIGNOLET\",\"Gap\":\"+1.222\",\"BestLap\":\"1:01.222\"},{\"Position\":3,\"Name\":\"Simon MAUDOUX\",\"Gap\":\"+2.555\",\"BestLap\":\"1:01.555\"},{\"Position\":4,\"Name\":\"Maxime BECKERS\",\"Gap\":\"+3.888\",\"BestLap\":\"1:01.888\"},{\"Position\":5,\"Name\":\"Pierre JACOBS\",\"Gap\":\"+5.111\",\"BestLap\":\"1:02.111\"},{\"Position\":6,\"Name\":\"Thibaut MARECHAL\",\"Gap\":\"+6.444\",\"BestLap\":\"1:02.444\"},{\"Position\":7,\"Name\":\"Manuel THIRY\",\"Gap\":\"+7.777\",\"BestLap\":\"1:02.777\"},{\"Position\":8,\"Name\":\"Jeremy MAHIAT\",\"Gap\":\"+9.000\",\"BestLap\":\"1:03.000\"},{\"Position\":9,\"Name\":\"Quentin BOILEAU\",\"Gap\":\"+10.333\",\"BestLap\":\"1:03.333\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Gap\":\"+11.666\",\"BestLap\":\"1:03.666\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Gap\":\"+12.999\",\"BestLap\":\"1:03.999\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Gap\":\"+14.222\",\"BestLap\":\"1:04.222\"},{\"Position\":13,\"Name\":\"Florian GIARUSSO\",\"Gap\":\"+15.555\",\"BestLap\":\"1:04.555\"},{\"Position\":14,\"Name\":\"Nicolas PREUD'HOMME\",\"Gap\":\"+16.888\",\"BestLap\":\"1:04.888\"},{\"Position\":15,\"Name\":\"Cyril HARDY\",\"Gap\":\"+18.111\",\"BestLap\":\"1:05.111\"},{\"Position\":16,\"Name\":\"Arnaud SCHAAL\",\"Gap\":\"+19.444\",\"BestLap\":\"1:05.444\"},{\"Position\":17,\"Name\":\"Xavier MAWET\",\"Gap\":\"+20.777\",\"BestLap\":\"1:05.777\"},{\"Position\":18,\"Name\":\"Michael HUTSEMAIKERS\",\"Gap\":\"+22.000\",\"BestLap\":\"1:06.000\"},{\"Position\":19,\"Name\":\"Quentin VAN EYLEN\",\"Gap\":\"+23.333\",\"BestLap\":\"1:06.333\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Gap\":\"+24.666\",\"BestLap\":\"1:06.666\"}]}", 5 },
                    { 6, "", null, "Manuel THIRY, Maxime BECKERS, Simon MAUDOUX, Pierre MIGNOLET, Thibaut MARECHAL, Aubry HUYGHEBAERT, Jeremy MAHIAT, Pierre JACOBS, Quentin BOILEAU, Loic PETERS, Florian GIARUSSO, Mathieu WYZEN, Raphael MONTESANTI, Quentin VAN EYLEN, Cyril HARDY, Nicolas PREUD'HOMME, Arnaud SCHAAL, Xavier MAWET, Michael HUTSEMAIKERS, UNKNOWN", "November", 56, "Q: 6min, R: 30min", "{\"Qualif\":[{\"Position\":1,\"Name\":\"Quentin VAN EYLEN\",\"Time\":\"1:01.111\"},{\"Position\":2,\"Name\":\"Pierre MIGNOLET\",\"Time\":\"1:01.444\"},{\"Position\":3,\"Name\":\"Simon MAUDOUX\",\"Time\":\"1:01.777\"},{\"Position\":4,\"Name\":\"Maxime BECKERS\",\"Time\":\"1:02.000\"},{\"Position\":5,\"Name\":\"Pierre JACOBS\",\"Time\":\"1:02.333\"},{\"Position\":6,\"Name\":\"Thibaut MARECHAL\",\"Time\":\"1:02.666\"},{\"Position\":7,\"Name\":\"Manuel THIRY\",\"Time\":\"1:02.999\"},{\"Position\":8,\"Name\":\"Jeremy MAHIAT\",\"Time\":\"1:03.222\"},{\"Position\":9,\"Name\":\"Quentin BOILEAU\",\"Time\":\"1:03.555\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Time\":\"1:03.888\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Time\":\"1:04.111\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Time\":\"1:04.444\"},{\"Position\":13,\"Name\":\"Florian GIARUSSO\",\"Time\":\"1:04.777\"},{\"Position\":14,\"Name\":\"Nicolas PREUD'HOMME\",\"Time\":\"1:05.000\"},{\"Position\":15,\"Name\":\"Cyril HARDY\",\"Time\":\"1:05.333\"},{\"Position\":16,\"Name\":\"Arnaud SCHAAL\",\"Time\":\"1:05.666\"},{\"Position\":17,\"Name\":\"Xavier MAWET\",\"Time\":\"1:05.999\"},{\"Position\":18,\"Name\":\"Michael HUTSEMAIKERS\",\"Time\":\"1:06.222\"},{\"Position\":19,\"Name\":\"Raphael MONTESANTI\",\"Time\":\"1:06.555\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Time\":\"1:06.888\"}],\"Race\":[{\"Position\":1,\"Name\":\"Quentin VAN EYLEN\",\"Gap\":\"+0.000\",\"BestLap\":\"1:01.111\"},{\"Position\":2,\"Name\":\"Pierre MIGNOLET\",\"Gap\":\"+1.444\",\"BestLap\":\"1:01.444\"},{\"Position\":3,\"Name\":\"Simon MAUDOUX\",\"Gap\":\"+2.777\",\"BestLap\":\"1:01.777\"},{\"Position\":4,\"Name\":\"Maxime BECKERS\",\"Gap\":\"+4.000\",\"BestLap\":\"1:02.000\"},{\"Position\":5,\"Name\":\"Pierre JACOBS\",\"Gap\":\"+5.333\",\"BestLap\":\"1:02.333\"},{\"Position\":6,\"Name\":\"Thibaut MARECHAL\",\"Gap\":\"+6.666\",\"BestLap\":\"1:02.666\"},{\"Position\":7,\"Name\":\"Manuel THIRY\",\"Gap\":\"+7.999\",\"BestLap\":\"1:02.999\"},{\"Position\":8,\"Name\":\"Jeremy MAHIAT\",\"Gap\":\"+9.222\",\"BestLap\":\"1:03.222\"},{\"Position\":9,\"Name\":\"Quentin BOILEAU\",\"Gap\":\"+10.555\",\"BestLap\":\"1:03.555\"},{\"Position\":10,\"Name\":\"Loic PETERS\",\"Gap\":\"+11.888\",\"BestLap\":\"1:03.888\"},{\"Position\":11,\"Name\":\"Mathieu WYZEN\",\"Gap\":\"+13.111\",\"BestLap\":\"1:04.111\"},{\"Position\":12,\"Name\":\"Aubry HUYGHEBAERT\",\"Gap\":\"+14.444\",\"BestLap\":\"1:04.444\"},{\"Position\":13,\"Name\":\"Florian GIARUSSO\",\"Gap\":\"+15.777\",\"BestLap\":\"1:04.777\"},{\"Position\":14,\"Name\":\"Nicolas PREUD'HOMME\",\"Gap\":\"+17.000\",\"BestLap\":\"1:05.000\"},{\"Position\":15,\"Name\":\"Cyril HARDY\",\"Gap\":\"+18.333\",\"BestLap\":\"1:05.333\"},{\"Position\":16,\"Name\":\"Arnaud SCHAAL\",\"Gap\":\"+19.666\",\"BestLap\":\"1:05.666\"},{\"Position\":17,\"Name\":\"Xavier MAWET\",\"Gap\":\"+21.999\",\"BestLap\":\"1:05.999\"},{\"Position\":18,\"Name\":\"Michael HUTSEMAIKERS\",\"Gap\":\"+23.222\",\"BestLap\":\"1:06.222\"},{\"Position\":19,\"Name\":\"Raphael MONTESANTI\",\"Gap\":\"+24.555\",\"BestLap\":\"1:06.555\"},{\"Position\":20,\"Name\":\"UNKNOWN\",\"Gap\":\"+25.888\",\"BestLap\":\"1:06.888\"}]}", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Races_TrackId",
                table: "Races",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
