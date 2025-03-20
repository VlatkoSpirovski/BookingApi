using AutoMapper;
using BookingApi.BusinessLogic.Interfaces;
using BookingApi.Domain.Entities;
using BookingApi.Domain.Enums;
using BookingApi.Domain.Exceptions;
using BookingApi.Domain.ResponseModels;
using MediatR;

namespace BookingApi.BusinessLogic.UseCases;

    public record SubmitPropertyAmenitiesCommand(
        Guid PropertyId,
        GeneralAmenityType[]? GeneralAmenityTypes,
        OutdoorAmenityType[]? OutdoorAmenityTypes
    ) : IRequest<PropertyAmenityResponseModel>;


internal sealed class SubmitPropertyAmenitiesCommandHandler : IRequestHandler<SubmitPropertyAmenitiesCommand, PropertyAmenityResponseModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubmitPropertyAmenitiesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PropertyAmenityResponseModel> Handle(SubmitPropertyAmenitiesCommand request, CancellationToken cancellationToken)
    {
        var property = await _unitOfWork.PropertyRepository.GetById(request.PropertyId, cancellationToken) 
            ?? throw new NotFoundException("Property not found");

        var propertyAmenity = await _unitOfWork.PropertyAmenityRepository
            .GetByPropertyId(request.PropertyId, cancellationToken);
        
        if (propertyAmenity == null)
        {
            // If property amenity doesn't exist, create a new one
            propertyAmenity = new PropertyAmenity
            {
                Id = Guid.NewGuid(),
                PropertyId = property.Id,
                GeneralAmenityTypes = request.GeneralAmenityTypes ?? Array.Empty<GeneralAmenityType>(), // Default to empty array if null
                OutdoorAmenityTypes = request.OutdoorAmenityTypes ?? Array.Empty<OutdoorAmenityType>(), // Default to empty array if null
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Property = property
            };

            await _unitOfWork.PropertyAmenityRepository.Add(propertyAmenity, cancellationToken);
        }
        else
        {
            // Only update the fields that are not null
            if (request.GeneralAmenityTypes != null)
                propertyAmenity.GeneralAmenityTypes = request.GeneralAmenityTypes;

            if (request.OutdoorAmenityTypes != null)
                propertyAmenity.OutdoorAmenityTypes = request.OutdoorAmenityTypes;

            propertyAmenity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.PropertyAmenityRepository.Update(propertyAmenity, cancellationToken);
        }

        await _unitOfWork.SaveAsync(cancellationToken);
        return _mapper.Map<PropertyAmenity, PropertyAmenityResponseModel>(propertyAmenity);
    }
}