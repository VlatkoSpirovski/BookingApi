using BookingApi.BusinessLogic.Interfaces;
using MediatR;
using BookingApi.Domain.Entities;

namespace BookingApi.BusinessLogic.UseCases;

public record CreatePropertyCommand(
    Guid OwnerId, 
    string Name, 
    string Description,
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode) : IRequest<Guid>;

internal sealed class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
    {
        var newProperty = new Property()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Street = request.Street,
            City = request.City,
            State = request.State,
            Country = request.Country,
            ZipCode = request.ZipCode,
            OwnerId = request.OwnerId.ToString(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _unitOfWork.PropertyRepository.Add(newProperty, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return newProperty.Id;
    }
}

