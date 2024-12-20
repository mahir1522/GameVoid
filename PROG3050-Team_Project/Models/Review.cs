﻿using System.ComponentModel.DataAnnotations;

namespace PROG3050_Team_Project.Models
{
    public class Review
    {
        [Key]
        public int? ReviewID { get; set; }
        public Game Game { get; set; }
        public Member Member { get; set; }
        public int GameId { get; set; }
        public int MemberId { get; set; }
        public int Rating { get; set; }  
        public string ReviewText { get; set; }
        public string ReviewStatus { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [FutureDateValidation(ErrorMessage = "Review date cannot be in the future.")]
        public DateTime ReviewDate { get; set; }
    }
}
