using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Team = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Period = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    RaceFormat = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Drivers = table.Column<string>(type: "text", nullable: false),
                    Results = table.Column<string>(type: "text", nullable: false),
                    TrackId = table.Column<int>(type: "integer", nullable: false)
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
                    { 20, "Gauthier VERHEUGE", "" }
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
                    { 1, "Manuel Thiry (MATH)", new DateTime(2026, 1, 15, 20, 0, 0, 585, DateTimeKind.Utc), "", "January", 56, "Q: 6min, R: 30min", "", 1 },
                    { 2, "", null, "", "March", 56, "Q: 6min, R: 30min", "", 2 },
                    { 3, "", null, "", "May", 56, "Q: 6min, R: 30min", "", 3 },
                    { 4, "", null, "", "July", 56, "Q: 6min, R: 30min", "", 4 },
                    { 5, "", null, "", "September", 56, "Q: 6min, R: 30min", "", 5 },
                    { 6, "", null, "", "November", 56, "Q: 6min, R: 30min", "", 6 }
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
