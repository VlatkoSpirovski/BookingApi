using BookingApi.Data;
using BookingApi.Interfaces;
using BookingApi.Mappers;
using BookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IRatingsAndReviewsRepository _ratingsRepo;
    public PropertyRepository(ApplicationDbContext context, IRatingsAndReviewsRepository ratingsRepo)
    {
        _ratingsRepo = ratingsRepo;
        _dbContext = context;
    }
    public async Task<List<Property>> GetAllAsync()
    {
        var props = await _dbContext.Properties.Include(r => r.RatingsAndReviews)
            .Include(r => r.Address)
            .Include(a => a.Amenities)
            .Include(p => p.Photos)
            .OrderByDescending(p => p.CreatedDate)
            .ToListAsync();
        return props;
    }

    public async Task<Property?> GetByIdAsync(int id)
    {
        var property = await _dbContext.Properties
            .Include(p => p.Address)
            .Include(p => p.RatingsAndReviews)
            .Include(a => a.Amenities)
            .Include(p => p.Photos)
            .OrderByDescending(p => p.CreatedDate)
            .FirstOrDefaultAsync(p => p.Id == id);
    
        return property;
    }
    public async Task<Property> CreateAsync(Property property)
    {
        await _dbContext.Properties.AddAsync(property);
        await _dbContext.SaveChangesAsync();
        return property;
    }

    public async Task<Property?> UpdateAsync(Property property, int id)
    {
        var existingProperty = await _dbContext.Properties.FindAsync(id);
        if (existingProperty == null)
        {
            return null;
        }
        existingProperty.Name = property.Name;
        existingProperty.Description = property.Description;
        existingProperty.NumberOfBathrooms = property.NumberOfBathrooms;
        existingProperty.NumberOfRooms = property.NumberOfRooms;
        existingProperty.PricePerNight = property.PricePerNight;
        existingProperty.MaxGuests = property.MaxGuests;
        existingProperty.Type = property.Type;
        existingProperty.IsAvailable = property.IsAvailable;
        existingProperty.Address = property.Address;
        
        await _dbContext.SaveChangesAsync();
        return existingProperty;
    }
    public async Task<Property?> DeleteAsync(int id)
    {
        var propModel = await _dbContext.Properties.FindAsync(id);
        if (propModel == null)
        {
            return null;
        }
        _dbContext.Properties.Remove(propModel);
        await _dbContext.SaveChangesAsync();
        return propModel;
    }

    public Task<bool> PropertyExist(int id)
    {
        return _dbContext.Properties.AnyAsync(s => s.Id == id);
    }

    public async Task<decimal> CalculateAverageRatingAsync(int propertyId)
    {
        var ratings = await _dbContext.Ratings
            .Where(r => r.PropertyId == propertyId)
            .ToListAsync();

        if (!ratings.Any())
        {
            return 0m;
        }

        var averageRating = ratings.Average(r => (decimal)r.Rating);
    
        var roundedAverageRating = Math.Round(averageRating, 1);

        return roundedAverageRating;
    }


    public Task UpdateAverageRatingAsync(int propertyId, decimal averageRating)
    {
        throw new NotImplementedException();
    }
}