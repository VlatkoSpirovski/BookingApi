using BookingApi.Domain.Entities;

namespace BookingApi.BusinessLogic.Interfaces;

public interface IPropertyAmenityRepository
{ 
    Task<PropertyAmenity?> GetByPropertyId(Guid id, CancellationToken cancellationToken = default);
    Task Add(PropertyAmenity property, CancellationToken cancellationToken = default);
    Task Update(PropertyAmenity property, CancellationToken cancellationToken = default);
}