using BookingApi.DTOs.Property;
using BookingApi.Models;

namespace BookingApi.Interfaces;

public interface IPropertyRepository
{
    Task<List<Property>> GetAllAsync();
    Task<Property>? GetByIdAsync(int id);
    Task<Property> CreateAsync(Property property);
    Task<Property?> UpdateAsync(Property property, int id);
    Task<Property?> DeleteAsync(int id);
    Task<bool> PropertyExist(int id);
    Task<decimal> CalculateAverageRatingAsync(int propertyId);
    Task UpdateAverageRatingAsync(int propertyId, decimal averageRating);
}