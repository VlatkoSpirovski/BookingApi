using System.ComponentModel.DataAnnotations;

namespace BookingApi.Dtos.RatingsAndReviews;

public class CreateRatingsDtos
{
    [Required]
    [Range(1,10)]
    public int Rating { get; set; }
    
    public string Review { get; set; } = string.Empty;
    
    [Required]
    public int PropertyId { get; set; }
    
}