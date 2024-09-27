using BookingApi.Dtos.RatingsAndReviews;
using BookingApi.Enums;

namespace BookingApi.DTOs.Property;

public class PropertyFilterDto
{
    public string? Name { get; set; }
    public int? NumberOfRooms { get; set; }
    public decimal? MinPricePerNight { get; set; }
    public decimal? MaxPricePerNight { get; set; }
    public decimal? PricePerNight { get; set; }
    public int? MaxGuests { get; set; }
    public bool? IsAvailable { get; set; }
    public PropertyType? Type { get; set; }
    
    public int? MinRating { get; set; }
    public int? MinRatingCount { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public DateTime? StartDate { get; set;}
    public DateTime? EndDate { get; set; }
}