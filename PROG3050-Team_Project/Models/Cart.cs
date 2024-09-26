namespace PROG3050_Team_Project.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public Member Member { get; set; }

        public List<Game> Games { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return Games.Sum(g => g.Price);
            }
        }

        public Cart()
        {
            Games = new List<Game>();
        }
        public void AddToCart(Game game)
        {
            Games.Add(game);
        }
        public void RemoveFromCart(Game game)
        {
            Games.Remove(game);
        }
    }
}