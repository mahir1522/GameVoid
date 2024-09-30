    using System.ComponentModel.DataAnnotations.Schema;

namespace PROG3050_Team_Project.Models
{
    public class Member
    {
        public int MemberID { get; set; }

        public string UserName { get; set; }

        public string Email {  get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Gender {  get; set; }

        public DateTime BirthDate { get; set; }

        public bool WantsPromotions {  get; set; }

        public List<string> FavoritePlatforms { get; set; }
        public List<string> FavoriteGameCategories { get; set; }

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
