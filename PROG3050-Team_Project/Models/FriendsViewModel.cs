namespace PROG3050_Team_Project.Models
{
    public class FriendsViewModel
    {
        public Member CurrentMember { get; set; }
        public Member Friend { get; set; }
        public List<Member> AllMembers { get; set; }
        public WishList WishList { get; set; }
    }

}