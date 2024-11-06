namespace PROG3050_Team_Project.Models
{
    public class MemberGamesViewModel
    {
        public Member member { get; set; }
        public List<Game> games { get; set; }
        public List<Event> events { get; set; }
        public Event Event { get; set; }
        public bool IsRegistered { get; set; }
    }
}
