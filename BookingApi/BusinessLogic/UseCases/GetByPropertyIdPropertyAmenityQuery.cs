using AutoMapper;
using BookingApi.BusinessLogic.Interfaces;
using BookingApi.Domain.Exceptions;
using BookingApi.Domain.ResponseModels;
using MediatR;

namespace BookingApi.BusinessLogic.UseCases;

public record GetByPropertyIdPropertyAmenityQuery(Guid Id) : IRequest<PropertyAmenityResponseModel>;
internal sealed class GetByPropertyIdPropertyAmenityQueryHandler : IRequestHandler<GetByPropertyIdPropertyAmenityQuery, PropertyAmenityResponseModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetByPropertyIdPropertyAmenityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<PropertyAmenityResponseModel> Handle(GetByPropertyIdPropertyAmenityQuery request, CancellationToken cancellationToken)
    {
        var amenity = await _unitOfWork.PropertyAmenityRepository.GetByPropertyId(request.Id, cancellationToken)
                      ?? throw new NotFoundException($"Property not found {request.Id}");;
        var response = _mapper.Map<PropertyAmenityResponseModel>(amenity);

        return response;    }
}