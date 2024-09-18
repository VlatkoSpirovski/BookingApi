using BookingApi.Data;
using BookingApi.Interfaces;
using BookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PhotoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Photo> AddPhotoAsync(Photo photo)
    {
        _dbContext.Photos.Add(photo);
        await _dbContext.SaveChangesAsync();
        return photo;
    }

    public async Task<IEnumerable<Photo>> GetPhotosByPropertyIdAsync(int propertyId)
    {
        return await _dbContext.Photos
            .Where(p => p.PropertyId == propertyId)
            .ToListAsync();
    }

    public async Task<Photo?> GetPhotoByIdAsync(int id)
    {
        return await _dbContext.Photos.FindAsync(id);
    }

    public async Task DeletePhotoAsync(int id)
    {
        var photo = await _dbContext.Photos.FindAsync(id);
        if (photo != null)
        {
            _dbContext.Photos.Remove(photo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
