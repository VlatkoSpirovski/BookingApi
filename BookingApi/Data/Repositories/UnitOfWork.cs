using BookingApi.BusinessLogic.Interfaces;

namespace BookingApi.Data.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    public IPropertyRepository PropertyRepository { get; }
    public IPropertyAmenityRepository PropertyAmenityRepository { get; }
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context, IPropertyRepository propertyRep, IPropertyAmenityRepository propertyAmenityRep)
    {
        _context = context;
        PropertyRepository = propertyRep;
        PropertyAmenityRepository = propertyAmenityRep;
    }
    public async Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.CommitTransactionAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.RollbackTransactionAsync(cancellationToken);
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}