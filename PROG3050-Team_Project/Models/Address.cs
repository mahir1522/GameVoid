using System.ComponentModel.DataAnnotations;

namespace PROG3050_Team_Project.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public int MemberID { get; set; }
        public virtual Member? Member { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Street Address is required")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "AptSuite is required")]
        public string AptSuite { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Province is required")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Delivery Instructions is required")]
        public string DeliveryInstructions { get; set; }

        public bool IsShippingSameAsMailing { get; set; }
    }

}
