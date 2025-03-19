using BookingApi.BusinessLogic.Interfaces;
using BookingApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Data.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly ApplicationDbContext _dbContext;
    public PropertyRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }
    public async Task<IList<Property>> GetAll(CancellationToken cancellationToken = default)
    {
        var properties = await _dbContext.Properties
            .Include(e => e.Owner)
            .Include(e => e.Bookings)
            .Include(e=>e.PropertyAmenities)
            .ToListAsync(cancellationToken);
        return properties;
    }

    public async Task<Property?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var properties = await _dbContext.Properties
            .Include(e => e.Owner)
            .Include(e=>e.PropertyAmenities)
            .FirstOrDefaultAsync(i => id == i.Id);
        return properties;
    }

    public async Task Add(Property property, CancellationToken cancellationToken = default)
    {
        await _dbContext.Properties.AddAsync(property, cancellationToken);
    }

    public Task Update(Property property, CancellationToken cancellationToken = default)
    { 
        _dbContext.Properties.Update(property);
        return Task.CompletedTask;
    }

    public Task Delete(Property property, CancellationToken cancellationToken = default)
    {
        _dbContext.Properties.Remove(property);
        return Task.CompletedTask;
    }

    public Task<IList<Property>> GetAvailableProperties(DateTime? startDate, DateTime? endDate)
    {
        throw new NotImplementedException();
    }
}