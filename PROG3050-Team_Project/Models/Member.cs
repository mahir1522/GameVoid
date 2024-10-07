using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG3050_Team_Project.Models
{
    public class Member
    {
        public int? MemberID { get; set; }  // Nullable int

        [Required(ErrorMessage = "Username is required.")]
        public string? UserName { get; set; }  // Nullable string 

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }  // Nullable string 

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }  // Nullable string 


        [NotMapped] // This will not be mapped to out database
        public string? ConfirmPassword { get; set; }

        public string? FullName { get; set; } = String.Empty;

        public string? Gender { get; set; } = String.Empty;

        public DateTime? BirthDate { get; set; } = DateTime.Now;

        public bool? WantsPromotions { get; set; } = false;

        public List<string>? FavoritePlatforms { get; set; } = new List<string>();

        public List<string>? FavoriteGameCategories { get; set; } = new List<string>();

        [NotMapped]
        public Address? Address { get; set; }  // Nullable Address

        public List<Member>? FriendsAndFamily { get; set; } = new List<Member>();  // Nullable list

        public Member()
        {
            FavoritePlatforms = new List<string>();
            FavoriteGameCategories = new List<string>();
            FriendsAndFamily = new List<Member>();
        }

        public ICollection<WishList>? WishLists { get; set; }  // Nullable collections
        public ICollection<Order>? Orders { get; set; }  // Nullable collections
        public ICollection<Event>? RegisteredEvents { get; set; }  // Nullable collections
        public bool IsEmailVerified { get; set; } = false;
    }
}
