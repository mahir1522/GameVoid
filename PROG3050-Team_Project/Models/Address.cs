namespace PROG3050_Team_Project.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Country { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string AptSuite { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string DeliveryInstructions { get; set; }
        public bool IsShippingSameAsMailing { get; set; }
    }
}
