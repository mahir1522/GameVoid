
using System.ComponentModel.DataAnnotations;

namespace PROG3050_Team_Project.Models
{
    class FutureDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue > DateTime.Now)
                {
                    return new ValidationResult(ErrorMessage ?? "Date cannot be in the future.");
                }
            }

            return ValidationResult.Success;
        }
    }
}