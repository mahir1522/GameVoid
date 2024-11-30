using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PROG3050_Team_Project.Migrations
{
    /// <inheritdoc />
    public partial class reviewsystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IsDownloadable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
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
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID");
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
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewStatus = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Not Submitted"),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Members_MemberId",
                        column: x => x.MemberId,
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
                name: "CartGame",
                columns: table => new
                {
                    CartsCartId = table.Column<int>(type: "int", nullable: false),
                    GamesGameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartGame", x => new { x.CartsCartId, x.GamesGameID });
                    table.ForeignKey(
                        name: "FK_CartGame_Carts_CartsCartId",
                        column: x => x.CartsCartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartGame_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberEvents",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberEvents", x => new { x.MemberId, x.EventId });
                    table.ForeignKey(
                        name: "FK_MemberEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberEvents_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registration_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameOrder",
                columns: table => new
                {
                    GamesGameID = table.Column<int>(type: "int", nullable: false),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOrder", x => new { x.GamesGameID, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_GameOrder_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameOrder_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Events",
                columns: new[] { "EventId", "Description", "EndDate", "Location", "MemberID", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "It is a networking event for game to collabrate ", new DateTime(2024, 11, 11, 17, 0, 0, 0, DateTimeKind.Unspecified), "108 University Avenue East, Waterloo, Ontario, Canada", null, new DateTime(2024, 11, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Unity Developer Meet" },
                    { 2, "An interactive symposium exploring AI trends in the gaming industry.", new DateTime(2024, 12, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), "Tech Hall, 25 King Street West, Toronto, Ontario, Canada", null, new DateTime(2024, 12, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), "AI in Gaming Symposium" },
                    { 3, "A 48-hour event to create immersive VR gaming experiences.", new DateTime(2024, 11, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Conestoga College, Doon Campus, Kitchener, Ontario, Canada", null, new DateTime(2024, 11, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), "Virtual Reality Game Jam" },
                    { 4, "Competitive tournament for students to showcase their gaming skills.", new DateTime(2024, 11, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), "Recreation Center, 15 Elm Street, Waterloo, Ontario, Canada", null, new DateTime(2024, 11, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), "Esports Tournament 2024" },
                    { 5, "Hands-on workshop covering game design, coding, and art.", new DateTime(2024, 12, 3, 15, 30, 0, 0, DateTimeKind.Unspecified), "Innovation Hub, 99 Bloor Street, Toronto, Ontario, Canada", null, new DateTime(2024, 12, 3, 9, 30, 0, 0, DateTimeKind.Unspecified), "Game Development Workshop" },
                    { 6, "An event for indie game developers to present their latest projects.", new DateTime(2024, 12, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), "The Game Lounge, 50 King Street North, Kitchener, Ontario, Canada", null, new DateTime(2024, 12, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Indie Game Showcase" },
                    { 7, "A seminar discussing the impact of gaming on mental health.", new DateTime(2024, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "Wellness Center, 20 Queen Street West, Toronto, Ontario, Canada", null, new DateTime(2024, 11, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), "Gaming & Mental Health Seminar" },
                    { 8, "A conference celebrating and supporting women in the gaming industry.", new DateTime(2024, 11, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), "Unity Center, 60 Wellington Street, Waterloo, Ontario, Canada", null, new DateTime(2024, 11, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), "Women in Gaming Conference" },
                    { 9, "Learn about sound design and audio engineering for games.", new DateTime(2024, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), "Arts & Media Building, 101 College Street, Toronto, Ontario, Canada", null, new DateTime(2024, 12, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), "Game Sound Design Workshop" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Category", "Description", "ImageUrl", "IsDownloadable", "Platform", "Price", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "RPG", "An open-world, action-adventure story set in Night City.", "/img/default.jpg", true, "PC", 59.99m, 4.2m, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077" },
                    { 2, "RPG", "A story-driven, open-world RPG set in a visually stunning fantasy universe.", "/img/default.jpg", true, "Xbox", 39.99m, 4.9m, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher 3: Wild Hunt" },
                    { 3, "Action-Adventure", "An epic tale of life in America’s unforgiving heartland.", "/img/default.jpg", true, "PlayStation", 49.99m, 4.8m, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2" },
                    { 4, "Shooter", "Master Chief returns to confront the most ruthless foe he’s ever faced.", "/img/default.jpg", true, "Xbox", 59.99m, 4.4m, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halo Infinite" },
                    { 5, "Sandbox", "A game about placing blocks and going on adventures.", "/img/default.jpg", true, "PC", 26.95m, 4.7m, new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minecraft" },
                    { 6, "Party", "A multiplayer game where Crewmates work together to complete tasks while avoiding the Impostor.", "/img/default.jpg", true, "Mobile", 4.99m, 4.3m, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Among Us" },
                    { 7, "Adventure", "A game that reinvents the boundaries of an open-world adventure.", "/img/default.jpg", false, "Nintendo Switch", 59.99m, 4.9m, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Breath of the Wild" },
                    { 8, "Battle Royale", "A battle royale game where players fight to be the last one standing.", "/img/default.jpg", true, "PC", 0.00m, 4.5m, new DateTime(2017, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fortnite" },
                    { 9, "Action-Adventure", "An open-world game that allows players to explore Los Santos and complete missions.", "/img/default.jpg", true, "PC", 29.99m, 4.6m, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto V" },
                    { 10, "Shooter", "A team-based shooter set on a near-future Earth.", "/img/default.jpg", true, "PlayStation", 39.99m, 4.4m, new DateTime(2016, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overwatch" }
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

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewID", "GameId", "MemberId", "Rating", "ReviewDate", "ReviewStatus", "ReviewText" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "An incredible adventure that defines the genre." },
                    { 2, 1, 2, 0, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "A bit outdated, but still a classic." },
                    { 3, 1, 3, 0, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Challenging gameplay but rewarding!" },
                    { 4, 2, 1, 0, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "Timeless fun! The levels are brilliantly designed." },
                    { 5, 2, 2, 0, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "Could use better graphics, but the gameplay is top-notch." },
                    { 6, 2, 4, 0, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Enjoyable multiplayer mode, but the campaign is too short." },
                    { 7, 3, 2, 0, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "Creative and endlessly entertaining. Highly recommended!" },
                    { 8, 3, 3, 0, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejected", "I had high expectations, but the story was lackluster." },
                    { 9, 3, 4, 0, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "Visually stunning with a memorable soundtrack." },
                    { 10, 4, 1, 0, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "A refreshing take on the genre with innovative mechanics." },
                    { 11, 4, 5, 0, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved", "Repetitive gameplay but overall enjoyable." },
                    { 12, 4, 6, 0, new DateTime(2023, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Takes too long to get interesting, but worth the patience." }
                });

            migrationBuilder.InsertData(
                table: "WishLists",
                columns: new[] { "WishListId", "MemberID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_MemberID",
                table: "Address",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_CartGame_GamesGameID",
                table: "CartGame",
                column: "GamesGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_MemberID",
                table: "Carts",
                column: "MemberID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_MemberID",
                table: "Events",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_GameOrder_OrdersOrderId",
                table: "GameOrder",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GameWishList_WishListsWishListId",
                table: "GameWishList",
                column: "WishListsWishListId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberEvents_EventId",
                table: "MemberEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberID1",
                table: "Members",
                column: "MemberID1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MemberID",
                table: "Orders",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_EventId",
                table: "Registration",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_MemberId",
                table: "Registration",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_GameId",
                table: "Review",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MemberId",
                table: "Review",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_MemberID",
                table: "WishLists",
                column: "MemberID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "CartGame");

            migrationBuilder.DropTable(
                name: "GameOrder");

            migrationBuilder.DropTable(
                name: "GameWishList");

            migrationBuilder.DropTable(
                name: "MemberEvents");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
