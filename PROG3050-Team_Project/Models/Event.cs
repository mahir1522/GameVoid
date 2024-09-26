﻿namespace PROG3050_Team_Project.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public ICollection<Member> RegiteredMembers { get; set; }

        public Event()
        {
            RegiteredMembers = new List<Member>();
        }
        public void RegisterForEvent(Member member)
        {
            RegiteredMembers.Add(member);
        }
    }
}