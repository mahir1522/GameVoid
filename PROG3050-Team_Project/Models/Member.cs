using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG3050_Team_Project.Models
{
    public class Member
    {
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email {  get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public string? FullName { get; set; } = String.Empty;

        public string? Gender {  get; set; } = String.Empty;

        public DateTime? BirthDate { get; set; } = DateTime.Now;

        public bool? WantsPromotions { get; set; } = false;

        public List<string>? FavoritePlatforms { get; set; } = new List<string>();
        public List<string>? FavoriteGameCategories { get; set; } = new List<string>();

        [NotMapped]
        public Address Address { get; set; }

        public List<Member> FriendsAndFamily { get; set; }

        public Member()
        {
            FavoritePlatforms = new List<string>();
            FavoriteGameCategories = new List<string>();
            FriendsAndFamily = new List<Member>();
        }
        public ICollection<WishList> WishLists { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Event> RegisteredEvents { get; set; }
    }
}
