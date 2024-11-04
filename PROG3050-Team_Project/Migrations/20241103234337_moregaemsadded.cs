using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PROG3050_Team_Project.Migrations
{
    /// <inheritdoc />
    public partial class moregaemsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Category", "Description", "ImageUrl", "IsDownloadable", "OrderId", "Platform", "Price", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 3, "Action-Adventure", "An epic tale of life in America’s unforgiving heartland.", "/img/default.jpg", true, null, "PlayStation", 49.99m, 4.8m, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2" },
                    { 4, "Shooter", "Master Chief returns to confront the most ruthless foe he’s ever faced.", "/img/default.jpg", true, null, "Xbox", 59.99m, 4.4m, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halo Infinite" },
                    { 5, "Sandbox", "A game about placing blocks and going on adventures.", "/img/default.jpg", true, null, "PC", 26.95m, 4.7m, new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minecraft" },
                    { 6, "Party", "A multiplayer game where Crewmates work together to complete tasks while avoiding the Impostor.", "/img/default.jpg", true, null, "Mobile", 4.99m, 4.3m, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Among Us" },
                    { 7, "Adventure", "A game that reinvents the boundaries of an open-world adventure.", "/img/default.jpg", false, null, "Nintendo Switch", 59.99m, 4.9m, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Breath of the Wild" },
                    { 8, "Battle Royale", "A battle royale game where players fight to be the last one standing.", "/img/default.jpg", true, null, "PC", 0.00m, 4.5m, new DateTime(2017, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fortnite" },
                    { 9, "Action-Adventure", "An open-world game that allows players to explore Los Santos and complete missions.", "/img/default.jpg", true, null, "PC", 29.99m, 4.6m, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto V" },
                    { 10, "Shooter", "A team-based shooter set on a near-future Earth.", "/img/default.jpg", true, null, "PlayStation", 39.99m, 4.4m, new DateTime(2016, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overwatch" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 10);
        }
    }
}
