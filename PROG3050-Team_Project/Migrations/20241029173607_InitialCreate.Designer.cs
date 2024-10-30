﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROG3050_Team_Project.Models;

#nullable disable

namespace PROG3050_Team_Project.Migrations
{
    [DbContext(typeof(GameVoidContext))]
    [Migration("20241029173607_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventMember", b =>
                {
                    b.Property<int>("RegisteredEventsEventId")
                        .HasColumnType("int");

                    b.Property<int>("RegiteredMembersMemberID")
                        .HasColumnType("int");

                    b.HasKey("RegisteredEventsEventId", "RegiteredMembersMemberID");

                    b.HasIndex("RegiteredMembersMemberID");

                    b.ToTable("EventMember");
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

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
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
                        });
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

            modelBuilder.Entity("PROG3050_Team_Project.Models.WishList", b =>
                {
                    b.Property<int>("WishListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WishListId"));

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.HasKey("WishListId");

                    b.HasIndex("MemberID");

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("EventMember", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("RegisteredEventsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROG3050_Team_Project.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("RegiteredMembersMemberID")
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

            modelBuilder.Entity("PROG3050_Team_Project.Models.Order", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Member", "Member")
                        .WithMany("Orders")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.WishList", b =>
                {
                    b.HasOne("PROG3050_Team_Project.Models.Member", "Member")
                        .WithMany("WishLists")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Member", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("FriendsAndFamily");

                    b.Navigation("Orders");

                    b.Navigation("WishLists");
                });

            modelBuilder.Entity("PROG3050_Team_Project.Models.Order", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}