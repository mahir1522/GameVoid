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

            modelBuilder.Entity<WishList>().HasData(
                new WishList
                {
                    WishListId = 1,
                    MemberID = 1,
                },
                new WishList
                {
                    WishListId = 2,
                    MemberID = 2,
                }
            );

            modelBuilder.Entity<Cart>().HasData(
                new Cart { CartId = 1, MemberID = 1 },
                new Cart { CartId = 2, MemberID = 2 }
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
        }
    }
}
