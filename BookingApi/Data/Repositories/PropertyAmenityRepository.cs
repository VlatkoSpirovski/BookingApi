using BookingApi.BusinessLogic.Interfaces;
using BookingApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Data.Repositories;

public class PropertyAmenityRepository : IPropertyAmenityRepository
{
    private readonly ApplicationDbContext _dbContext;
    public PropertyAmenityRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<PropertyAmenity?> GetByPropertyId(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.PropertyAmenities.FirstOrDefaultAsync(i=>i.PropertyId == id, cancellationToken);
    }

    public async Task Add(PropertyAmenity property, CancellationToken cancellationToken = default)
    { 
        await _dbContext.PropertyAmenities.AddAsync(property, cancellationToken);
    }

    public Task Update(PropertyAmenity property, CancellationToken cancellationToken = default)
    {
        _dbContext.PropertyAmenities.Update(property);
        return Task.CompletedTask;
    }
    
}