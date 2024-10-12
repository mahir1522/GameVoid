using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG3050_Team_Project.Migrations
{
    /// <inheritdoc />
    public partial class imageaddedgeame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://unsplash.com/photos/a-blue-and-white-nintendo-wii-game-system-bj6fp3AGSbM");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://unsplash.com/photos/a-blue-and-white-nintendo-wii-game-system-bj6fp3AGSbM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Games");
        }
    }
}
