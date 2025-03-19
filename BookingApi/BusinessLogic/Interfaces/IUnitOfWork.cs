namespace BookingApi.BusinessLogic.Interfaces;

public interface IUnitOfWork
{
    public IPropertyRepository PropertyRepository { get; }
    public IPropertyAmenityRepository PropertyAmenityRepository { get; }
    Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}