namespace PROG3050_Team_Project.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
