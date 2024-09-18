using System.ComponentModel.DataAnnotations;
using BookingApi.Models;

namespace BookingApi.Dtos.RatingsAndReviews;

public class RatingsAndReviewsDto
{
    public int Id { get; set; }
    [Required]
    [Range(1,10)]
    public int Rating { get; set; }
    
    public string Review { get; set; } = string.Empty;
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}