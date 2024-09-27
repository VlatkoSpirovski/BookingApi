using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookingApi.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string UserId { get; set; }
        
        public IdentityUser User { get; set; }
        public bool ValidateDates(out string errorMessage)
        {
            if (StartDate < DateTime.UtcNow)
            {
                errorMessage = "Start date cannot be in the past.";
                return false;
            }

            if (EndDate <= StartDate)
            {
                errorMessage = "End date must be after the start date.";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}