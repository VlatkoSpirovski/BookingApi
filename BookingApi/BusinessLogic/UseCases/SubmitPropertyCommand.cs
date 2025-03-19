using AutoMapper;
using BookingApi.BusinessLogic.Interfaces;
using BookingApi.Domain.Entities;
using BookingApi.Domain.Enums;
using BookingApi.Domain.ResponseModels;
using MediatR;

namespace BookingApi.BusinessLogic.UseCases;

public record SubmitPropertyCommand(
    Guid Id,
    string? Name,
    string? Description,
    string? Street,
    string? City,
    string? State,
    string? ZipCode,
    string? Country,
    int? NumberOfRooms,
    int? NumberOfBathrooms,
    int? NumberOfBedrooms,
    int? NumberOfKitchens,
    int? NumberOfLivingRooms,
    int? NumberOfBalconies,
    int? MaxGuests,
    int? MinBookingLeadTimeDays,
    decimal? PricePerNight,
    decimal? DiscountPercentage,
    DateTime? AvailableFrom,
    DateTime? AvailableTo,
    DateTime? LastBookedAt,
    PropertyType? PropertyType,
    PropertyStatus? PropertyStatus,
    bool? IsAvailable
) : IRequest<PropertyResponseModel>;

internal sealed class SubmitPropertyCommandHandler : IRequestHandler<SubmitPropertyCommand, PropertyResponseModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public SubmitPropertyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PropertyResponseModel> Handle(SubmitPropertyCommand request, CancellationToken cancellationToken)
    {
        var property = await _unitOfWork.PropertyRepository.GetById(request.Id, cancellationToken) 
                        ?? throw new InvalidOperationException("Property not found.");

        foreach (var propertyInfo in typeof(SubmitPropertyCommand).GetProperties())
        {
            var newValue = propertyInfo.GetValue(request);
            if (newValue is not null)
            {
                var propertyToUpdate = typeof(Property).GetProperty(propertyInfo.Name);
                propertyToUpdate?.SetValue(property, newValue);
            }
        }
        await _unitOfWork.PropertyRepository.Update(property, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return _mapper.Map<PropertyResponseModel>(property);
    }
}
