namespace PROG3050_Team_Project.Models
{
    public class GameReviewViewModel
    {
        public int MemberID { get; set; }
        public Game game { get; set; }
        public List<Review> reviews { get; set; }
        public Review UserReview { get; set; }  
        public Review NewReview { get; set; }  
        
    }
}
