using Microsoft.EntityFrameworkCore;
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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<MemberEvent> MemberEvents { get; set; }
        public DbSet<Review> Review { get; set; }


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
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 1,
                    Title = "Unity Developer Meet",
                    Description = "It is a networking event for game to collabrate ",
                    StartDate = new DateTime(2024, 11, 11, 09,00,00),
                    EndDate = new DateTime(2024, 11, 11, 17, 00, 00), 
                    Location = "108 University Avenue East, Waterloo, Ontario, Canada"
                },
                new Event
                {
                    EventId = 2,
                    Title = "AI in Gaming Symposium",
                    Description = "An interactive symposium exploring AI trends in the gaming industry.",
                    StartDate = new DateTime(2024, 12, 5, 10, 0, 0),
                    EndDate = new DateTime(2024, 12, 5, 16, 0, 0),
                    Location = "Tech Hall, 25 King Street West, Toronto, Ontario, Canada"
                },
                new Event
                {
                    EventId = 3,
                    Title = "Virtual Reality Game Jam",
                    Description = "A 48-hour event to create immersive VR gaming experiences.",
                    StartDate = new DateTime(2024, 11, 18, 18, 0, 0),
                    EndDate = new DateTime(2024, 11, 20, 18, 0, 0),
                    Location = "Conestoga College, Doon Campus, Kitchener, Ontario, Canada"
                },

                new Event
                {
                    EventId = 4,
                    Title = "Esports Tournament 2024",
                    Description = "Competitive tournament for students to showcase their gaming skills.",
                    StartDate = new DateTime(2024, 11, 25, 12, 0, 0),
                    EndDate = new DateTime(2024, 11, 25, 20, 0, 0),
                    Location = "Recreation Center, 15 Elm Street, Waterloo, Ontario, Canada"
                },

                new Event
                {
                    EventId = 5,
                    Title = "Game Development Workshop",
                    Description = "Hands-on workshop covering game design, coding, and art.",
                    StartDate = new DateTime(2024, 12, 3, 9, 30, 0),
                    EndDate = new DateTime(2024, 12, 3, 15, 30, 0),
                    Location = "Innovation Hub, 99 Bloor Street, Toronto, Ontario, Canada"
                },

                new Event
                {
                    EventId = 6,
                    Title = "Indie Game Showcase",
                    Description = "An event for indie game developers to present their latest projects.",
                    StartDate = new DateTime(2024, 12, 10, 14, 0, 0),
                    EndDate = new DateTime(2024, 12, 10, 18, 0, 0),
                    Location = "The Game Lounge, 50 King Street North, Kitchener, Ontario, Canada"
                },

                new Event
                {
                    EventId = 7,
                    Title = "Gaming & Mental Health Seminar",
                    Description = "A seminar discussing the impact of gaming on mental health.",
                    StartDate = new DateTime(2024, 11, 15, 11, 0, 0),
                    EndDate = new DateTime(2024, 11, 15, 13, 0, 0),
                    Location = "Wellness Center, 20 Queen Street West, Toronto, Ontario, Canada"
                },

                new Event
                {
                    EventId = 8,
                    Title = "Women in Gaming Conference",
                    Description = "A conference celebrating and supporting women in the gaming industry.",
                    StartDate = new DateTime(2024, 11, 30, 9, 0, 0),
                    EndDate = new DateTime(2024, 11, 30, 17, 0, 0),
                    Location = "Unity Center, 60 Wellington Street, Waterloo, Ontario, Canada"
                },

                new Event
                {
                    EventId = 9,
                    Title = "Game Sound Design Workshop",
                    Description = "Learn about sound design and audio engineering for games.",
                    StartDate = new DateTime(2024, 12, 8, 10, 0, 0),
                    EndDate = new DateTime(2024, 12, 8, 16, 0, 0),
                    Location = "Arts & Media Building, 101 College Street, Toronto, Ontario, Canada"
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
            modelBuilder.Entity<Review>().HasData(
                // Reviews for Game 1
                new Review
                {
                    ReviewID = 1,
                    MemberId = 1,
                    GameId = 1,
                    ReviewText = "An incredible adventure that defines the genre.",
                    ReviewStatus = "Approved",
                    ReviewDate = new DateTime(2021, 10, 1)
                },
                new Review
                {
                    ReviewID = 2,
                    MemberId = 2,
                    GameId = 1,
                    ReviewText = "A bit outdated, but still a classic.",
                    ReviewStatus = "Approved",
                    ReviewDate = new DateTime(2022, 1, 15)
                },
                new Review
                {
                    ReviewID = 3,
                    MemberId = 3,
                    GameId = 1,
                    ReviewText = "Challenging gameplay but rewarding!",
                    ReviewStatus = "Pending",
                    ReviewDate = new DateTime(2023, 3, 10)
                },

                // Reviews for Game 2
                new Review
                {
                    ReviewID = 4,
                    MemberId = 1,
                    GameId = 2,
                    ReviewText = "Timeless fun! The levels are brilliantly designed.",
                    ReviewStatus = "Approved",
                    ReviewDate = new DateTime(2023, 5, 10)
                },
                new Review
                {
                    ReviewID = 5,
                    MemberId = 2,
                    GameId = 2,
                    ReviewText = "Could use better graphics, but the gameplay is top-notch.",
                    ReviewStatus = "Approved",
                    ReviewDate = new DateTime(2023, 6, 5)
                },
                new Review
                {
                    ReviewID = 6,
                    MemberId = 4,
                    GameId = 2,
                    ReviewText = "Enjoyable multiplayer mode, but the campaign is too short.",
                    ReviewStatus = "Pending",
                    ReviewDate = new DateTime(2023, 7, 15)
                },

                // Reviews for Game 3
                new Review
                {
                    ReviewID = 7,
                    MemberId = 2,
                    GameId = 3,
                    ReviewText = "Creative and endlessly entertaining. Highly recommended!",
                    ReviewStatus = "Approved",
                    ReviewDate = new DateTime(2023, 8, 25)
                },
                new Review
                {
                    ReviewID = 8,
                    MemberId = 3,
                    GameId = 3,
                    ReviewText = "I had high expectations, but the story was lackluster.",
                    ReviewStatus = "Rejected",
                    ReviewDate = new DateTime(2023, 9, 12)
                },
                new Review
                {
                    ReviewID = 9,
                    MemberId = 4,
                    GameId = 3,
                    ReviewText = "Visually stunning with a memorable soundtrack.",
                    ReviewStatus = "Approved",
                    ReviewDate = new DateTime(2023, 10, 20)
                },

                // Reviews for Game 4
                new Review
                {
                    ReviewID = 10,
                    MemberId = 1,
                    GameId = 4,
                    ReviewText = "A refreshing take on the genre with innovative mechanics.",
                    ReviewStatus = "Approved",
                    ReviewDate = new DateTime(2023, 11, 5)
                },
                new Review
                {
                    ReviewID = 11,
                    MemberId = 5,
                    GameId = 4,
                    ReviewText = "Repetitive gameplay but overall enjoyable.",
                    ReviewStatus = "Approved",
                    ReviewDate = new DateTime(2023, 11, 10)
                },
                new Review
                {
                    ReviewID = 12,
                    MemberId = 6,
                    GameId = 4,
                    ReviewText = "Takes too long to get interesting, but worth the patience.",
                    ReviewStatus = "Pending",
                    ReviewDate = new DateTime(2023, 11, 18)
                }
            );

            modelBuilder.Entity<WishList>().HasData(
                new WishList
                {
                    WishListId = 1,
                    MemberID = 1 // Foreign key linking to the seeded Member
                },
                new WishList
                {
                    WishListId = 2,
                    MemberID = 2 // Foreign key linking to the seeded Member
                },
                new WishList
                {
                    WishListId = 3,
                    MemberID = 3 // Foreign key linking to the seeded Member
                },
                new WishList
                {
                    WishListId = 4,
                    MemberID = 4 // Foreign key linking to the seeded Member
                },
                new WishList
                {
                    WishListId = 5,
                    MemberID = 5 // Foreign key linking to the seeded Member
                },
                new WishList
                {
                    WishListId = 6,
                    MemberID = 6 // Foreign key linking to the seeded Member
                },
                new WishList
                {
                    WishListId = 7,
                    MemberID = 7 // Foreign key linking to the seeded Member
                },
                new WishList
                {
                    WishListId = 8,
                    MemberID = 8 // Foreign key linking to the seeded Member
                },
                new WishList
                {
                    WishListId = 9,
                    MemberID = 9 // Foreign key linking to the seeded Member
                },
                new WishList
                {
                    WishListId = 10,
                    MemberID = 10 // Foreign key linking to the seeded Member
                }

            );

            // Define relationships between WishList and Member(Many to one)
            modelBuilder.Entity<WishList>()
                .HasOne(w => w.Member)
                .WithOne(m => m.WishList)
                .HasForeignKey<WishList>(w => w.MemberID);
            modelBuilder.Entity<Cart>()
                .HasOne(w => w.Member)
                .WithOne(m => m.Cart)
                .HasForeignKey<Cart>(w => w.MemberID);

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
           modelBuilder.Entity<Registration>()
            .HasKey(r => r.RegistrationId);
            modelBuilder.Entity<MemberEvent>()
            .HasKey(me => new { me.MemberId, me.EventId }); // Composite primary key

            modelBuilder.Entity<MemberEvent>()
                .HasOne(me => me.Member)
                .WithMany(m => m.MemberEvents)
                .HasForeignKey(me => me.MemberId);

            modelBuilder.Entity<MemberEvent>()
                .HasOne(me => me.Event)
                .WithMany(e => e.MemberEvents)
                .HasForeignKey(me => me.EventId);


            // Define relationships between Game and WishList (many to many)
            modelBuilder.Entity<WishList>()
                .HasMany(w => w.Games)
                .WithMany(g => g.WishLists);

            // Define relationships between Game and WishList (many to many)
            modelBuilder.Entity<Cart>()
                .HasMany(w => w.Games)
                .WithMany(g => g.Carts);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Games)
                .WithMany(g => g.Orders);

            modelBuilder.Entity<Review>()
            .HasKey(r => r.ReviewID);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Game)
                .WithMany(g => g.Reviews)
                .HasForeignKey(r => r.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Member)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
            .Property(r => r.ReviewStatus)
            .HasDefaultValue("Not Submitted");
        }
    }
}