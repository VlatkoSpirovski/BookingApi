
namespace BookingApi.Domain.ResponseModels.RatingsAndReviews;

public class RatingsAndReviewsResponseModel
{
    public int Id { get; set; }
    public int Rating { get; set; }
    
    public string Review { get; set; } = string.Empty;
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}