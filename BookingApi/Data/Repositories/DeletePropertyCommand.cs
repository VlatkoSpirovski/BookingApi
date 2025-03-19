using BookingApi.BusinessLogic.Interfaces;
using BookingApi.Domain.Exceptions;
using MediatR;

namespace BookingApi.Data.Repositories;

public record DeletePropertyCommand(Guid Id) : IRequest<bool>;
internal sealed class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
    {
        var property = await _unitOfWork.PropertyRepository.GetById(request.Id, cancellationToken) ??
                       throw new NotFoundException($"Property {request.Id} not found");
        
        await _unitOfWork.PropertyRepository.Delete(property, cancellationToken);
        var result = await _unitOfWork.SaveAsync(cancellationToken);
        return result == 1;
    }
}