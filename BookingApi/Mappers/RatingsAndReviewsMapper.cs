using BookingApi.Dtos.RatingsAndReviews;
using BookingApi.Models;

namespace BookingApi.Mappers;

public static class RatingsAndReviewsMapper
{

    public static RatingsAndReviewsDto MapToDto(this RatingAndReview ratingsAndReviews)
    {
        return new RatingsAndReviewsDto
        {
            Rating = ratingsAndReviews.Rating,
            Review = ratingsAndReviews.Review,
            CreatedDate = ratingsAndReviews.CreatedDate
        };
    }

    public static RatingAndReview MapToEntity(this CreateRatingsDtos ratingsAndReviewsDto, int propertyId)
    {
        return new RatingAndReview
        {
            PropertyId = propertyId,
            Rating = ratingsAndReviewsDto.Rating,
            Review = ratingsAndReviewsDto.Review,
        };
    }
}