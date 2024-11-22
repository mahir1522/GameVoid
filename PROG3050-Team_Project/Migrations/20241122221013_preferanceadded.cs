using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG3050_Team_Project.Migrations
{
    /// <inheritdoc />
    public partial class preferanceadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PreferLanguage",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 1,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms", "PreferLanguage" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 2,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms", "PreferLanguage" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 3,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms", "PreferLanguage" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 4,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms", "PreferLanguage" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 5,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms", "PreferLanguage" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 6,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms", "PreferLanguage" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 7,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms", "PreferLanguage" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 8,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms", "PreferLanguage" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 9,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms", "PreferLanguage" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 10,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms", "PreferLanguage" },
                values: new object[] { "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreferLanguage",
                table: "Members");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 1,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms" },
                values: new object[] { "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 2,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms" },
                values: new object[] { "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 3,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms" },
                values: new object[] { "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 4,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms" },
                values: new object[] { "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 5,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms" },
                values: new object[] { "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 6,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms" },
                values: new object[] { "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 7,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms" },
                values: new object[] { "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 8,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms" },
                values: new object[] { "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 9,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms" },
                values: new object[] { "[]", "[]" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 10,
                columns: new[] { "FavoriteGameCategories", "FavoritePlatforms" },
                values: new object[] { "[]", "[]" });
        }
    }
}
