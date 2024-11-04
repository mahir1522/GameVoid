using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PROG3050_Team_Project.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WantsPromotions = table.Column<bool>(type: "bit", nullable: true),
                    FavoritePlatforms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteGameCategories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    profileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Members_Members_MemberID1",
                        column: x => x.MemberID1,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AptSuite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsShippingSameAsMailing = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventMember",
                columns: table => new
                {
                    RegisteredEventsEventId = table.Column<int>(type: "int", nullable: false),
                    RegiteredMembersMemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMember", x => new { x.RegisteredEventsEventId, x.RegiteredMembersMemberID });
                    table.ForeignKey(
                        name: "FK_EventMember_Events_RegisteredEventsEventId",
                        column: x => x.RegisteredEventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventMember_Members_RegiteredMembersMemberID",
                        column: x => x.RegiteredMembersMemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    WishListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.WishListId);
                    table.ForeignKey(
                        name: "FK_WishLists_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDownloadable = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Games_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "GameWishList",
                columns: table => new
                {
                    GamesGameID = table.Column<int>(type: "int", nullable: false),
                    WishListsWishListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameWishList", x => new { x.GamesGameID, x.WishListsWishListId });
                    table.ForeignKey(
                        name: "FK_GameWishList_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameWishList_WishLists_WishListsWishListId",
                        column: x => x.WishListsWishListId,
                        principalTable: "WishLists",
                        principalColumn: "WishListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Category", "Description", "ImageUrl", "IsDownloadable", "OrderId", "Platform", "Price", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "RPG", "An open-world, action-adventure story set in Night City.", "/img/default.jpg", true, null, "PC", 59.99m, 4.2m, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077" },
                    { 2, "RPG", "A story-driven, open-world RPG set in a visually stunning fantasy universe.", "/img/default.jpg", true, null, "Xbox", 39.99m, 4.9m, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher 3: Wild Hunt" },
                    { 3, "Action-Adventure", "An epic tale of life in America’s unforgiving heartland.", "/img/default.jpg", true, null, "PlayStation", 49.99m, 4.8m, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2" },
                    { 4, "Shooter", "Master Chief returns to confront the most ruthless foe he’s ever faced.", "/img/default.jpg", true, null, "Xbox", 59.99m, 4.4m, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halo Infinite" },
                    { 5, "Sandbox", "A game about placing blocks and going on adventures.", "/img/default.jpg", true, null, "PC", 26.95m, 4.7m, new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minecraft" },
                    { 6, "Party", "A multiplayer game where Crewmates work together to complete tasks while avoiding the Impostor.", "/img/default.jpg", true, null, "Mobile", 4.99m, 4.3m, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Among Us" },
                    { 7, "Adventure", "A game that reinvents the boundaries of an open-world adventure.", "/img/default.jpg", false, null, "Nintendo Switch", 59.99m, 4.9m, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Breath of the Wild" },
                    { 8, "Battle Royale", "A battle royale game where players fight to be the last one standing.", "/img/default.jpg", true, null, "PC", 0.00m, 4.5m, new DateTime(2017, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fortnite" },
                    { 9, "Action-Adventure", "An open-world game that allows players to explore Los Santos and complete missions.", "/img/default.jpg", true, null, "PC", 29.99m, 4.6m, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto V" },
                    { 10, "Shooter", "A team-based shooter set on a near-future Earth.", "/img/default.jpg", true, null, "PlayStation", 39.99m, 4.4m, new DateTime(2016, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overwatch" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberID", "BirthDate", "Email", "FavoriteGameCategories", "FavoritePlatforms", "FullName", "Gender", "IsEmailVerified", "MemberID1", "Password", "UserName", "WantsPromotions", "profileImage" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gamerone@example.com", "[]", "[]", "John Doe", "Male", true, null, "hello@1234", "GamerOne", true, "/img/profile.png" },
                    { 2, new DateTime(1988, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "gamertwo@example.com", "[]", "[]", "Jane Smith", "Female", true, null, "hello@1234", "GamerTwo", false, "/img/profile.png" },
                    { 3, new DateTime(1995, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "progamer@example.com", "[]", "[]", "Alex Johnson", "Non-binary", true, null, "hello@1234", "ProGamer", true, "/img/profile.png" },
                    { 4, new DateTime(1992, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "eliteplayer@example.com", "[]", "[]", "Emily Davis", "Female", true, null, "hello@1234", "ElitePlayer", true, "/img/profile.png" },
                    { 5, new DateTime(1985, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "gamemaster@example.com", "[]", "[]", "Michael Brown", "Male", true, null, "hello@1234", "GameMaster", false, "/img/profile.png" },
                    { 6, new DateTime(1993, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "speedygamer@example.com", "[]", "[]", "Sarah Wilson", "Female", true, null, "hello@1234", "SpeedyGamer", true, "/img/profile.png" },
                    { 7, new DateTime(1987, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "retrogamer@example.com", "[]", "[]", "Chris Miller", "Male", true, null, "hello@1234", "RetroGamer", false, "/img/profile.png" },
                    { 8, new DateTime(1994, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "arcadequeen@example.com", "[]", "[]", "Megan Taylor", "Female", true, null, "hello@1234", "ArcadeQueen", true, "/img/profile.png" },
                    { 9, new DateTime(1991, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "fpsking@example.com", "[]", "[]", "Luke Anderson", "Male", true, null, "hello@1234", "FPSKing", false, "/img/profile.png" },
                    { 10, new DateTime(1996, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "puzzlemaster@example.com", "[]", "[]", "Lisa Thomas", "Female", true, null, "hello@1234", "PuzzleMaster", true, "/img/profile.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_MemberID",
                table: "Address",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_EventMember_RegiteredMembersMemberID",
                table: "EventMember",
                column: "RegiteredMembersMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_OrderId",
                table: "Games",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GameWishList_WishListsWishListId",
                table: "GameWishList",
                column: "WishListsWishListId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberID1",
                table: "Members",
                column: "MemberID1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MemberID",
                table: "Orders",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_MemberID",
                table: "WishLists",
                column: "MemberID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "EventMember");

            migrationBuilder.DropTable(
                name: "GameWishList");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
