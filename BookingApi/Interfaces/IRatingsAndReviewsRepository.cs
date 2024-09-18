using BookingApi.Models;

namespace BookingApi.Interfaces;

public interface IRatingsAndReviewsRepository
{
    Task<List<RatingAndReview>> GetAllAsync();
    Task<RatingAndReview?> GetByIdAsync(int id);
    Task<List<RatingAndReview?>> GetRatingsByPropertyIdAsync(int propertyId);
    Task<RatingAndReview> CreateIdPropertyAsync(RatingAndReview rating);
}