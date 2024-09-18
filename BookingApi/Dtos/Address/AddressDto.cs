using System.ComponentModel.DataAnnotations;
using BookingApi.Models;

namespace BookingApi.Dtos.Address;

public class AddressDto
{
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
    public int PostalCode { get; set;}
}