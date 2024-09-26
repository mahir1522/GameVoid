namespace PROG3050_Team_Project.Models
{
    public class GameReview
    {

        public int ReviewID { get; set; }
        public Game Game { get; set; }
        public Member Member { get; set; }
        public int Rating { get; set; }  
        public string ReviewText { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
