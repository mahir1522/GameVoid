namespace PROG3050_Team_Project.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public string Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price {  get; set; }

        public string ImageUrl { get; set; } = "/img/default.jpg";    //default image

        public decimal Rating { get; set; }
        public bool IsDownloadable { get; set; }
        public ICollection<WishList>? WishLists { get; set; } = null;


    }
}
