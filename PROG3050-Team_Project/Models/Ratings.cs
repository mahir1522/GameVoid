using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace PROG3050_Team_Project.Models
{
    public class Ratings
    {
        [Key]
        public int RatingId { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars.")]
        public int Rating { get; set; }
        public int GameId { get; set; }
        public int MemberId { get; set; }
    }
}
