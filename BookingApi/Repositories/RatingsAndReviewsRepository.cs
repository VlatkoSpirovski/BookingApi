using BookingApi.Data;
using BookingApi.Interfaces;
using BookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Repositories;

public class RatingsAndReviewsRepository : IRatingsAndReviewsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public RatingsAndReviewsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<RatingAndReview>> GetAllAsync()
    {
         return await _dbContext.Ratings.ToListAsync();
    }

    public async Task<RatingAndReview?> GetByIdAsync(int id)
    {
        return await _dbContext.Ratings.FindAsync(id);
    }

    public async Task<List<RatingAndReview?>> GetRatingsByPropertyIdAsync(int propertyId)
    {
        return await _dbContext.Ratings.Where(x => x.PropertyId == propertyId).ToListAsync();
    }

    public async Task<RatingAndReview> CreateIdPropertyAsync(RatingAndReview rating)
    {
        await _dbContext.Ratings.AddAsync(rating);
        await _dbContext.SaveChangesAsync();
        return rating;
    }
}