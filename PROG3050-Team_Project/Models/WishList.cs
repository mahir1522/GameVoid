namespace PROG3050_Team_Project.Models
{
    public class WishList
    {

        public int WishListId { get; set; }
        public int MemberID { get; set; }

        public Member Member { get; set; }

        public ICollection<Game> Games { get; set; }

        public WishList() 
        {
            Games = new List<Game>();
        }
        public void AddToWishList(Game game)
        {
            Games.Add(game);
        }
        public void RemoveFromWishList(Game game)
        {
            Games.Remove(game);
        }
    }
}
