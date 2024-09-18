using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models;

[Table("Address")]
public class Address
{
    public int Id { get; set; }
    [Required]
    [MinLength(4, ErrorMessage = "Country must be at least with 4 characters")]
    public string Country { get; set; } = string.Empty;
    [Required]
    [MinLength(4, ErrorMessage = "City must be at least with 4 characters")]
    public string City { get; set; } = string.Empty;
    [Required]
    [MinLength(4, ErrorMessage = "Street must be at least with 4 characters")]
    public string Street { get; set; } = string.Empty;
    [Required]
    [Range(3,10, ErrorMessage = "Postal code must be at least with 3 characters")]
    public int PostalCode { get; set;}
    public Property Property { get; set; }
}