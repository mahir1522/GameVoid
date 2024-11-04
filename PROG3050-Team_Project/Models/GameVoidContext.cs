﻿using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace PROG3050_Team_Project.Models
{
    public class GameVoidContext : DbContext
    {
        public GameVoidContext(DbContextOptions<GameVoidContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Games
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameID = 1,
                    Title = "Cyberpunk 2077",
                    Description = "An open-world, action-adventure story set in Night City.",
                    Platform = "PC",
                    Category = "RPG",
                    ReleaseDate = new DateTime(2020, 12, 10),
                    Price = 59.99M,
                    Rating = 4.2M,
                    IsDownloadable = true
                },
                new Game
                {
                    GameID = 2,
                    Title = "The Witcher 3: Wild Hunt",
                    Description = "A story-driven, open-world RPG set in a visually stunning fantasy universe.",
                    Platform = "Xbox",
                    Category = "RPG",
                    ReleaseDate = new DateTime(2015, 5, 19),
                    Price = 39.99M,
                    Rating = 4.9M,
                    IsDownloadable = true
                },
                new Game
                {
                    GameID = 3,
                    Title = "Red Dead Redemption 2",
                    Description = "An epic tale of life in America’s unforgiving heartland.",
                    Platform = "PlayStation",
                    Category = "Action-Adventure",
                    ReleaseDate = new DateTime(2018, 10, 26),
                    Price = 49.99M,
                    Rating = 4.8M,
                    IsDownloadable = true
                },
new Game
{
    GameID = 4,
    Title = "Halo Infinite",
    Description = "Master Chief returns to confront the most ruthless foe he’s ever faced.",
    Platform = "Xbox",
    Category = "Shooter",
    ReleaseDate = new DateTime(2021, 12, 8),
    Price = 59.99M,
    Rating = 4.4M,
    IsDownloadable = true
},
new Game
{
    GameID = 5,
    Title = "Minecraft",
    Description = "A game about placing blocks and going on adventures.",
    Platform = "PC",
    Category = "Sandbox",
    ReleaseDate = new DateTime(2011, 11, 18),
    Price = 26.95M,
    Rating = 4.7M,
    IsDownloadable = true
},
new Game
{
    GameID = 6,
    Title = "Among Us",
    Description = "A multiplayer game where Crewmates work together to complete tasks while avoiding the Impostor.",
    Platform = "Mobile",
    Category = "Party",
    ReleaseDate = new DateTime(2018, 6, 15),
    Price = 4.99M,
    Rating = 4.3M,
    IsDownloadable = true
},
new Game
{
    GameID = 7,
    Title = "The Legend of Zelda: Breath of the Wild",
    Description = "A game that reinvents the boundaries of an open-world adventure.",
    Platform = "Nintendo Switch",
    Category = "Adventure",
    ReleaseDate = new DateTime(2017, 3, 3),
    Price = 59.99M,
    Rating = 4.9M,
    IsDownloadable = false
},
new Game
{
    GameID = 8,
    Title = "Fortnite",
    Description = "A battle royale game where players fight to be the last one standing.",
    Platform = "PC",
    Category = "Battle Royale",
    ReleaseDate = new DateTime(2017, 7, 21),
    Price = 0.00M,
    Rating = 4.5M,
    IsDownloadable = true
},
new Game
{
    GameID = 9,
    Title = "Grand Theft Auto V",
    Description = "An open-world game that allows players to explore Los Santos and complete missions.",
    Platform = "PC",
    Category = "Action-Adventure",
    ReleaseDate = new DateTime(2013, 9, 17),
    Price = 29.99M,
    Rating = 4.6M,
    IsDownloadable = true
},
new Game
{
    GameID = 10,
    Title = "Overwatch",
    Description = "A team-based shooter set on a near-future Earth.",
    Platform = "PlayStation",
    Category = "Shooter",
    ReleaseDate = new DateTime(2016, 5, 24),
    Price = 39.99M,
    Rating = 4.4M,
    IsDownloadable = true
}


            );

            // Seed data for Members
            modelBuilder.Entity<Member>().HasData(
             new Member
             {
                 MemberID = 1,
                 UserName = "GamerOne",
                 Email = "gamerone@example.com",
                 Password = "hello@1234",
                 FullName = "John Doe",
                 Gender = "Male",
                 BirthDate = new DateTime(1990, 1, 1),
                 WantsPromotions = true,
                 IsEmailVerified = true
             },
new Member
{
    MemberID = 2,
    UserName = "GamerTwo",
    Email = "gamertwo@example.com",
    Password = "hello@1234",
    FullName = "Jane Smith",
    Gender = "Female",
    BirthDate = new DateTime(1988, 7, 15),
    WantsPromotions = false,
    IsEmailVerified = true
},
new Member
{
    MemberID = 3,
    UserName = "ProGamer",
    Email = "progamer@example.com",
    Password = "hello@1234",
    FullName = "Alex Johnson",
    Gender = "Non-binary",
    BirthDate = new DateTime(1995, 3, 22),
    WantsPromotions = true,
    IsEmailVerified = true
},
new Member
{
    MemberID = 4,
    UserName = "ElitePlayer",
    Email = "eliteplayer@example.com",
    Password = "hello@1234",
    FullName = "Emily Davis",
    Gender = "Female",
    BirthDate = new DateTime(1992, 5, 10),
    WantsPromotions = true,
    IsEmailVerified = true
},
new Member
{
    MemberID = 5,
    UserName = "GameMaster",
    Email = "gamemaster@example.com",
    Password = "hello@1234",
    FullName = "Michael Brown",
    Gender = "Male",
    BirthDate = new DateTime(1985, 11, 2),
    WantsPromotions = false,
    IsEmailVerified = true
},
new Member
{
    MemberID = 6,
    UserName = "SpeedyGamer",
    Email = "speedygamer@example.com",
    Password = "hello@1234",
    FullName = "Sarah Wilson",
    Gender = "Female",
    BirthDate = new DateTime(1993, 9, 28),
    WantsPromotions = true,
    IsEmailVerified = true
},
new Member
{
    MemberID = 7,
    UserName = "RetroGamer",
    Email = "retrogamer@example.com",
    Password = "hello@1234",
    FullName = "Chris Miller",
    Gender = "Male",
    BirthDate = new DateTime(1987, 12, 14),
    WantsPromotions = false,
    IsEmailVerified = true
},
new Member
{
    MemberID = 8,
    UserName = "ArcadeQueen",
    Email = "arcadequeen@example.com",
    Password = "hello@1234",
    FullName = "Megan Taylor",
    Gender = "Female",
    BirthDate = new DateTime(1994, 6, 5),
    WantsPromotions = true,
    IsEmailVerified = true
},
new Member
{
    MemberID = 9,
    UserName = "FPSKing",
    Email = "fpsking@example.com",
    Password = "hello@1234",
    FullName = "Luke Anderson",
    Gender = "Male",
    BirthDate = new DateTime(1991, 2, 18),
    WantsPromotions = false,
    IsEmailVerified = true
},
new Member
{
    MemberID = 10,
    UserName = "PuzzleMaster",
    Email = "puzzlemaster@example.com",
    Password = "hello@1234",
    FullName = "Lisa Thomas",
    Gender = "Female",
    BirthDate = new DateTime(1996, 4, 25),
    WantsPromotions = true,
    IsEmailVerified = true
}

            );

            // Define relationships between WishList and Member(Many to one)
            modelBuilder.Entity<WishList>()
                .HasOne(w => w.Member)
                .WithMany(m => m.WishLists)
                .HasForeignKey(w => w.MemberID);

            modelBuilder.Entity<Address>().
                HasKey(a => a.AddressID);

            modelBuilder.Entity<Member>()
                .HasMany(m => m.Addresses)
                .WithOne(a => a.Member)
                .HasForeignKey(a => a.MemberID);


            // Define relationships between Order and Member (Many to one)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Member)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.MemberID);

            // Define relationships between Event and Members who have registered (many to many)
            modelBuilder.Entity<Event>()
                .HasMany(e => e.RegiteredMembers)
                .WithMany(m => m.RegisteredEvents);

            // Define relationships between Game and WishList (many to many)
            modelBuilder.Entity<WishList>()
                .HasMany(w => w.Games)
                .WithMany(g => g.WishLists);
        }
    }
}