using BookingApi.Models;

namespace BookingApi.Interfaces;

public interface IPhotoRepository
{
    Task<Photo> AddPhotoAsync(Photo photo);
    Task<IEnumerable<Photo>> GetPhotosByPropertyIdAsync(int propertyId);
    Task<Photo?> GetPhotoByIdAsync(int id);
    Task DeletePhotoAsync(int id);

}