using BookingApi.Domain.Entities;

namespace BookingApi.BusinessLogic.Interfaces;

public interface IPropertyRepository
{
    Task<IList<Property>> GetAll(CancellationToken cancellationToken = default);
    Task<Property?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task Add(Property property, CancellationToken cancellationToken = default);
    Task Update(Property property, CancellationToken cancellationToken = default);
    Task Delete(Property property, CancellationToken cancellationToken = default);
    Task<IList<Property>> GetAvailableProperties(DateTime? startDate, DateTime? endDate);

}