﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROG3050_Team_Project.Models;

#nullable disable

namespace PROG3050_Team_Project.Migrations
{
    [DbContext(typeof(GameVoidContext))]
    partial class GameVoidContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CartGame", b =>
                {
                    b.Property<int>("CartsCartId")
                        .HasColumnType("int");

                    b.Property<int>("GamesGameID")
                        .HasColumnType("int");

                    b.HasKey("CartsCartId", "GamesGameID");

                    b.HasIndex("GamesGameID");

                    b.ToTable("CartGame");
                });

            modelBuilder.Entity("GameWishList", b =>
                {
                    b.Property<int>("GamesGameID")
                        .HasColumnType("int");

                    b.Property<int>("WishListsWishListId")
                        .HasColumnType("int");

                    b.HasKey("GamesGameID", "WishListsWishListId");

                    b.HasIndex("WishListsWishListId");

                    b.ToTable("GameWishList");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressID"));

                    b.Property<string>("AptSuite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsShippingSameAsMailing")
                        .HasColumnType("bit");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressID");

                    b.HasIndex("MemberID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("MemberID")
                        .IsUnique();

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            CartId = 1,
                            MemberID = 1
                        },
                        new
                        {
                            CartId = 2,
                            MemberID = 2
                        });
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.HasIndex("MemberID");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Description = "It is a networking event for game to collabrate ",
                            EndDate = new DateTime(2024, 11, 11, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "108 University Avenue East, Waterloo, Ontario, Canada",
                            StartDate = new DateTime(2024, 11, 11, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Unity Developer Meet"
                        },
                        new
                        {
                            EventId = 2,
                            Description = "An interactive symposium exploring AI trends in the gaming industry.",
                            EndDate = new DateTime(2024, 12, 5, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Tech Hall, 25 King Street West, Toronto, Ontario, Canada",
                            StartDate = new DateTime(2024, 12, 5, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "AI in Gaming Symposium"
                        },
                        new
                        {
                            EventId = 3,
                            Description = "A 48-hour event to create immersive VR gaming experiences.",
                            EndDate = new DateTime(2024, 11, 20, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Conestoga College, Doon Campus, Kitchener, Ontario, Canada",
                            StartDate = new DateTime(2024, 11, 18, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Virtual Reality Game Jam"
                        },
                        new
                        {
                            EventId = 4,
                            Description = "Competitive tournament for students to showcase their gaming skills.",
                            EndDate = new DateTime(2024, 11, 25, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Recreation Center, 15 Elm Street, Waterloo, Ontario, Canada",
                            StartDate = new DateTime(2024, 11, 25, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Esports Tournament 2024"
                        },
                        new
                        {
                            EventId = 5,
                            Description = "Hands-on workshop covering game design, coding, and art.",
                            EndDate = new DateTime(2024, 12, 3, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            Location = "Innovation Hub, 99 Bloor Street, Toronto, Ontario, Canada",
                            StartDate = new DateTime(2024, 12, 3, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            Title = "Game Development Workshop"
                        },
                        new
                        {
                            EventId = 6,
                            Description = "An event for indie game developers to present their latest projects.",
                            EndDate = new DateTime(2024, 12, 10, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "The Game Lounge, 50 King Street North, Kitchener, Ontario, Canada",
                            StartDate = new DateTime(2024, 12, 10, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Indie Game Showcase"
                        },
                        new
                        {
                            EventId = 7,
                            Description = "A seminar discussing the impact of gaming on mental health.",
                            EndDate = new DateTime(2024, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Wellness Center, 20 Queen Street West, Toronto, Ontario, Canada",
                            StartDate = new DateTime(2024, 11, 15, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Gaming & Mental Health Seminar"
                        },
                        new
                        {
                            EventId = 8,
                            Description = "A conference celebrating and supporting women in the gaming industry.",
                            EndDate = new DateTime(2024, 11, 30, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Unity Center, 60 Wellington Street, Waterloo, Ontario, Canada",
                            StartDate = new DateTime(2024, 11, 30, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Women in Gaming Conference"
                        },
                        new
                        {
                            EventId = 9,
                            Description = "Learn about sound design and audio engineering for games.",
                            EndDate = new DateTime(2024, 12, 8, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Arts & Media Building, 101 College Street, Toronto, Ontario, Canada",
                            StartDate = new DateTime(2024, 12, 8, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Game Sound Design Workshop"
                        });
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameID"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDownloadable")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameID");

                    b.HasIndex("OrderId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameID = 1,
                            Category = "RPG",
                            Description = "An open-world, action-adventure story set in Night City.",
                            ImageUrl = "/img/default.jpg",
                            IsDownloadable = true,
                            Platform = "PC",
                            Price = 59.99m,
                            Rating = 4.2m,
                            ReleaseDate = new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Cyberpunk 2077"
                        },
                        new
                        {
                            GameID = 2,
                            Category = "RPG",
                            Description = "A story-driven, open-world RPG set in a visually stunning fantasy universe.",
                            ImageUrl = "/img/default.jpg",
                            IsDownloadable = true,
                            Platform = "Xbox",
                            Price = 39.99m,
                            Rating = 4.9m,
                            ReleaseDate = new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Witcher 3: Wild Hunt"
                        },
                        new
                        {
                            GameID = 3,
                            Category = "Action-Adventure",
                            Description = "An epic tale of life in America’s unforgiving heartland.",
                            ImageUrl = "/img/default.jpg",
                            IsDownloadable = true,
                            Platform = "PlayStation",
                            Price = 49.99m,
                            Rating = 4.8m,
                            ReleaseDate = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            GameID = 4,
                            Category = "Shooter",
                            Description = "Master Chief returns to confront the most ruthless foe he’s ever faced.",
                            ImageUrl = "/img/default.jpg",
                            IsDownloadable = true,
                            Platform = "Xbox",
                            Price = 59.99m,
                            Rating = 4.4m,
                            ReleaseDate = new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Halo Infinite"
                        },
                        new
                        {
                            GameID = 5,
                            Category = "Sandbox",
                            Description = "A game about placing blocks and going on adventures.",
                            ImageUrl = "/img/default.jpg",
                            IsDownloadable = true,
                            Platform = "PC",
                            Price = 26.95m,
                            Rating = 4.7m,
                            ReleaseDate = new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Minecraft"
                        },
                        new
                        {
                            GameID = 6,
                            Category = "Party",
                            Description = "A multiplayer game where Crewmates work together to complete tasks while avoiding the Impostor.",
                            ImageUrl = "/img/default.jpg",
                            IsDownloadable = true,
                            Platform = "Mobile",
                            Price = 4.99m,
                            Rating = 4.3m,
                            ReleaseDate = new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Among Us"
                        },
                        new
                        {
                            GameID = 7,
                            Category = "Adventure",
                            Description = "A game that reinvents the boundaries of an open-world adventure.",
                            ImageUrl = "/img/default.jpg",
                            IsDownloadable = false,
                            Platform = "Nintendo Switch",
                            Price = 59.99m,
                            Rating = 4.9m,
                            ReleaseDate = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Legend of Zelda: Breath of the Wild"
                        },
                        new
                        {
                            GameID = 8,
                            Category = "Battle Royale",
                            Description = "A battle royale game where players fight to be the last one standing.",
                            ImageUrl = "/img/default.jpg",
                            IsDownloadable = true,
                            Platform = "PC",
                            Price = 0.00m,
                            Rating = 4.5m,
                            ReleaseDate = new DateTime(2017, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Fortnite"
                        },
                        new
                        {
                            GameID = 9,
                            Category = "Action-Adventure",
                            Description = "An open-world game that allows players to explore Los Santos and complete missions.",
                            ImageUrl = "/img/default.jpg",
                            IsDownloadable = true,
                            Platform = "PC",
                            Price = 29.99m,
                            Rating = 4.6m,
                            ReleaseDate = new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Grand Theft Auto V"
                        },
                        new
                        {
                            GameID = 10,
                            Category = "Shooter",
                            Description = "A team-based shooter set on a near-future Earth.",
                            ImageUrl = "/img/default.jpg",
                            IsDownloadable = true,
                            Platform = "PlayStation",
                            Price = 39.99m,
                            Rating = 4.4m,
                            ReleaseDate = new DateTime(2016, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Overwatch"
                        });
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Member", b =>
                {
                    b.Property<int?>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("MemberID"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavoriteGameCategories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavoritePlatforms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberID1")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("WantsPromotions")
                        .HasColumnType("bit");

                    b.Property<string>("profileImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberID");

                    b.HasIndex("MemberID1");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "gamerone@example.com",
                            FavoriteGameCategories = "[]",
                            FavoritePlatforms = "[]",
                            FullName = "John Doe",
                            Gender = "Male",
                            IsEmailVerified = true,
                            Password = "hello@1234",
                            UserName = "GamerOne",
                            WantsPromotions = true,
                            profileImage = "/img/profile.png"
                        },
                        new
                        {
                            MemberID = 2,
                            BirthDate = new DateTime(1988, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "gamertwo@example.com",
                            FavoriteGameCategories = "[]",
                            FavoritePlatforms = "[]",
                            FullName = "Jane Smith",
                            Gender = "Female",
                            IsEmailVerified = true,
                            Password = "hello@1234",
                            UserName = "GamerTwo",
                            WantsPromotions = false,
                            profileImage = "/img/profile.png"
                        },
                        new
                        {
                            MemberID = 3,
                            BirthDate = new DateTime(1995, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "progamer@example.com",
                            FavoriteGameCategories = "[]",
                            FavoritePlatforms = "[]",
                            FullName = "Alex Johnson",
                            Gender = "Non-binary",
                            IsEmailVerified = true,
                            Password = "hello@1234",
                            UserName = "ProGamer",
                            WantsPromotions = true,
                            profileImage = "/img/profile.png"
                        },
                        new
                        {
                            MemberID = 4,
                            BirthDate = new DateTime(1992, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "eliteplayer@example.com",
                            FavoriteGameCategories = "[]",
                            FavoritePlatforms = "[]",
                            FullName = "Emily Davis",
                            Gender = "Female",
                            IsEmailVerified = true,
                            Password = "hello@1234",
                            UserName = "ElitePlayer",
                            WantsPromotions = true,
                            profileImage = "/img/profile.png"
                        },
                        new
                        {
                            MemberID = 5,
                            BirthDate = new DateTime(1985, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "gamemaster@example.com",
                            FavoriteGameCategories = "[]",
                            FavoritePlatforms = "[]",
                            FullName = "Michael Brown",
                            Gender = "Male",
                            IsEmailVerified = true,
                            Password = "hello@1234",
                            UserName = "GameMaster",
                            WantsPromotions = false,
                            profileImage = "/img/profile.png"
                        },
                        new
                        {
                            MemberID = 6,
                            BirthDate = new DateTime(1993, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "speedygamer@example.com",
                            FavoriteGameCategories = "[]",
                            FavoritePlatforms = "[]",
                            FullName = "Sarah Wilson",
                            Gender = "Female",
                            IsEmailVerified = true,
                            Password = "hello@1234",
                            UserName = "SpeedyGamer",
                            WantsPromotions = true,
                            profileImage = "/img/profile.png"
                        },
                        new
                        {
                            MemberID = 7,
                            BirthDate = new DateTime(1987, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "retrogamer@example.com",
                            FavoriteGameCategories = "[]",
                            FavoritePlatforms = "[]",
                            FullName = "Chris Miller",
                            Gender = "Male",
                            IsEmailVerified = true,
                            Password = "hello@1234",
                            UserName = "RetroGamer",
                            WantsPromotions = false,
                            profileImage = "/img/profile.png"
                        },
                        new
                        {
                            MemberID = 8,
                            BirthDate = new DateTime(1994, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "arcadequeen@example.com",
                            FavoriteGameCategories = "[]",
                            FavoritePlatforms = "[]",
                            FullName = "Megan Taylor",
                            Gender = "Female",
                            IsEmailVerified = true,
                            Password = "hello@1234",
                            UserName = "ArcadeQueen",
                            WantsPromotions = true,
                            profileImage = "/img/profile.png"
                        },
                        new
                        {
                            MemberID = 9,
                            BirthDate = new DateTime(1991, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "fpsking@example.com",
                            FavoriteGameCategories = "[]",
                            FavoritePlatforms = "[]",
                            FullName = "Luke Anderson",
                            Gender = "Male",
                            IsEmailVerified = true,
                            Password = "hello@1234",
                            UserName = "FPSKing",
                            WantsPromotions = false,
                            profileImage = "/img/profile.png"
                        },
                        new
                        {
                            MemberID = 10,
                            BirthDate = new DateTime(1996, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "puzzlemaster@example.com",
                            FavoriteGameCategories = "[]",
                            FavoritePlatforms = "[]",
                            FullName = "Lisa Thomas",
                            Gender = "Female",
                            IsEmailVerified = true,
                            Password = "hello@1234",
                            UserName = "PuzzleMaster",
                            WantsPromotions = true,
                            profileImage = "/img/profile.png"
                        });
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.MemberEvent", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("MemberEvents");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("MemberID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegistrationId"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RegistrationId");

                    b.HasIndex("EventId");

                    b.HasIndex("MemberId");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.WishList", b =>
                {
                    b.Property<int>("WishListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WishListId"));

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.HasKey("WishListId");

                    b.HasIndex("MemberID")
                        .IsUnique();

                    b.ToTable("WishLists");

                    b.HasData(
                        new
                        {
                            WishListId = 1,
                            MemberID = 1
                        },
                        new
                        {
                            WishListId = 2,
                            MemberID = 2
                        });
                });

            modelBuilder.Entity("CartGame", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartsCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROG3050_Team_Project.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameWishList", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROG3050_Team_Project.Models.WishList", null)
                        .WithMany()
                        .HasForeignKey("WishListsWishListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Address", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Member", "Member")
                        .WithMany("Addresses")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Cart", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Member", "Member")
                        .WithOne("Cart")
                        .HasForeignKey("PROG3050_Team_Project.Models.Cart", "MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Event", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Member", null)
                        .WithMany("RegisteredEvents")
                        .HasForeignKey("MemberID");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Game", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Order", null)
                        .WithMany("Games")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Member", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Member", null)
                        .WithMany("FriendsAndFamily")
                        .HasForeignKey("MemberID1");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.MemberEvent", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Event", "Event")
                        .WithMany("MemberEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROG3050_Team_Project.Models.Member", "Member")
                        .WithMany("MemberEvents")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Order", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Member", "Member")
                        .WithMany("Orders")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Registration", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROG3050_Team_Project.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.WishList", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Member", "Member")
                        .WithOne("WishList")
                        .HasForeignKey("PROG3050_Team_Project.Models.WishList", "MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Event", b =>
                {
                    b.Navigation("MemberEvents");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Member", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Cart");

                    b.Navigation("FriendsAndFamily");

                    b.Navigation("MemberEvents");

                    b.Navigation("Orders");

                    b.Navigation("RegisteredEvents");

                    b.Navigation("WishList");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Order", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
