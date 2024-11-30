namespace PROG3050_Team_Project.Models
{
    public class GameRatingViewModel
    {
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public Game game { get; set; }
        public int gameId { get; set; }
        public List<int> AllRatings { get; set; }
        public int AverageRatings { get; set; }
        public int UserRating { get; set; }
    }
}
