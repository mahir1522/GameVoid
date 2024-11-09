namespace PROG3050_Team_Project.Models
{
    public class CheckoutViewModel
    {
        public int MemberID { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string CVC { get; set; }
        public string BillingAddress { get; set; }
    }
}
