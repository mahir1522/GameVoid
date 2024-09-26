namespace PROG3050_Team_Project.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int MemberID { get; set; }
        public Member Member { get; set; }
        public ICollection<Game> Games { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        public Order()
        {
            Games = new List<Game>();
        }
        public void ProcessOrder()
        {
            OrderStatus = "Processed";
        }
        public void ShipOrder()
        {
            OrderStatus = "Shipped";
        }
    }
}
