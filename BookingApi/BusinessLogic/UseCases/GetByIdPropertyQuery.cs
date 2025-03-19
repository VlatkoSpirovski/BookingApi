using AutoMapper;
using BookingApi.BusinessLogic.Interfaces;
using BookingApi.Domain.ResponseModels;
using MediatR;

namespace BookingApi.BusinessLogic.UseCases;

public record GetByIdPropertyQuery(Guid Id) : IRequest<PropertyResponseModel>;

internal sealed class GetByIdPropertyQueryHandler : IRequestHandler<GetByIdPropertyQuery, PropertyResponseModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetByIdPropertyQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PropertyResponseModel> Handle(GetByIdPropertyQuery request, CancellationToken cancellationToken)
    {
        var property = await _unitOfWork.PropertyRepository.GetById(request.Id, cancellationToken) ?? throw new InvalidOperationException("Property not found");
        return _mapper.Map<PropertyResponseModel>(property);
    }
}