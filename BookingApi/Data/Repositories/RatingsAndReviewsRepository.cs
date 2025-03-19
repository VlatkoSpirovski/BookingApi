/*using BookingApi.BusinessLogic.Interfaces;
using BookingApi.Data;
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
    public async Task<List<RatingAndReview1>> GetAllAsync()
    {
         return await _dbContext.Ratings.ToListAsync();
    }

    public async Task<RatingAndReview1?> GetByIdAsync(int id)
    {
        return await _dbContext.Ratings.FindAsync(id);
    }

    public async Task<List<RatingAndReview1?>> GetRatingsByPropertyIdAsync(int propertyId)
    {
        return await _dbContext.Ratings.Where(x => x.PropertyId == propertyId).ToListAsync();
    }

    public async Task<RatingAndReview1> CreateIdPropertyAsync(RatingAndReview1 rating)
    {
        await _dbContext.Ratings.AddAsync(rating);
        await _dbContext.SaveChangesAsync();
        return rating;
    }
}*/