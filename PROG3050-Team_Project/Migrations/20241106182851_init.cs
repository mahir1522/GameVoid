using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PROG3050_Team_Project.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                columns: new[] { "EventId", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "It is a networking event for game to collabrate ", new DateTime(2024, 11, 11, 17, 0, 0, 0, DateTimeKind.Unspecified), "108 University Avenue East, Waterloo, Ontario, Canada", new DateTime(2024, 11, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Unity Developer Meet" },
                    { 2, "An interactive symposium exploring AI trends in the gaming industry.", new DateTime(2024, 12, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), "Tech Hall, 25 King Street West, Toronto, Ontario, Canada", new DateTime(2024, 12, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), "AI in Gaming Symposium" },
                    { 3, "A 48-hour event to create immersive VR gaming experiences.", new DateTime(2024, 11, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Conestoga College, Doon Campus, Kitchener, Ontario, Canada", new DateTime(2024, 11, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), "Virtual Reality Game Jam" },
                    { 4, "Competitive tournament for students to showcase their gaming skills.", new DateTime(2024, 11, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), "Recreation Center, 15 Elm Street, Waterloo, Ontario, Canada", new DateTime(2024, 11, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), "Esports Tournament 2024" },
                    { 5, "Hands-on workshop covering game design, coding, and art.", new DateTime(2024, 12, 3, 15, 30, 0, 0, DateTimeKind.Unspecified), "Innovation Hub, 99 Bloor Street, Toronto, Ontario, Canada", new DateTime(2024, 12, 3, 9, 30, 0, 0, DateTimeKind.Unspecified), "Game Development Workshop" },
                    { 6, "An event for indie game developers to present their latest projects.", new DateTime(2024, 12, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), "The Game Lounge, 50 King Street North, Kitchener, Ontario, Canada", new DateTime(2024, 12, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Indie Game Showcase" },
                    { 7, "A seminar discussing the impact of gaming on mental health.", new DateTime(2024, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "Wellness Center, 20 Queen Street West, Toronto, Ontario, Canada", new DateTime(2024, 11, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), "Gaming & Mental Health Seminar" },
                    { 8, "A conference celebrating and supporting women in the gaming industry.", new DateTime(2024, 11, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), "Unity Center, 60 Wellington Street, Waterloo, Ontario, Canada", new DateTime(2024, 11, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), "Women in Gaming Conference" },
                    { 9, "Learn about sound design and audio engineering for games.", new DateTime(2024, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), "Arts & Media Building, 101 College Street, Toronto, Ontario, Canada", new DateTime(2024, 12, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), "Game Sound Design Workshop" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Category", "Description", "ImageUrl", "IsDownloadable", "OrderId", "Platform", "Price", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "RPG", "An open-world, action-adventure story set in Night City.", "/img/default.jpg", true, null, "PC", 59.99m, 4.2m, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077" },
                    { 2, "RPG", "A story-driven, open-world RPG set in a visually stunning fantasy universe.", "/img/default.jpg", true, null, "Xbox", 39.99m, 4.9m, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher 3: Wild Hunt" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberID", "BirthDate", "Email", "FavoriteGameCategories", "FavoritePlatforms", "FullName", "Gender", "IsEmailVerified", "MemberID1", "Password", "UserName", "WantsPromotions", "profileImage" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gamerone@example.com", "[]", "[]", "John Doe", "Male", true, null, "hello@1234", "GamerOne", true, "/img/profile.png" },
                    { 2, new DateTime(1988, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "gamertwo@example.com", "[]", "[]", "Jane Smith", "Female", true, null, "hello@1234", "GamerTwo", false, "/img/profile.png" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "MemberID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "WishLists",
                columns: new[] { "WishListId", "MemberID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
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
                name: "IX_Games_OrderId",
                table: "Games",
                column: "OrderId");

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
                name: "GameWishList");

            migrationBuilder.DropTable(
                name: "MemberEvents");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
