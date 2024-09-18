using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookingApi.Enums;

namespace BookingApi.Models;

[Table("Property")]
public class Property
{
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MinLength(50, ErrorMessage = "Description must be at least 50 characters")]
    public string Description { get; set; } = string.Empty;
    [Required]
    [Range(1,20, ErrorMessage = "Number of bathrooms must be greater than 1")]
    public int NumberOfBathrooms { get; set; }
    [Required]
    [Range(1, 50, ErrorMessage = "Number of rooms must be greater than 1")]
    public int NumberOfRooms { get; set; }
    [Required]
    [Range(5, 5000, ErrorMessage = "Price per night must be at least 5 euros.")]
    public decimal PricePerNight { get; set; }
    [Required]
    [Range(1, 50, ErrorMessage = "Max guest must be at least 1 Guest")]
    public int MaxGuests { get; set; }

    public decimal AverageRating { get; set; }
    public bool IsAvailable { get; set; } = true;
    public DateTime CreatedDate { get; set; }
    [Required]
    public PropertyType Type { get; set; }
    public Property()
    {
        CreatedDate = DateTime.UtcNow;
    }

    public List<RatingAndReview> RatingsAndReviews { get; set; } = new List<RatingAndReview>();
    public List<PropertyAmenity> Amenities { get; set; } = new List<PropertyAmenity>();
    public ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public int AddressId { get; set; }
    public Address Address { get; set; }
}