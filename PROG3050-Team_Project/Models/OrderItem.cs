namespace PROG3050_Team_Project.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

}
