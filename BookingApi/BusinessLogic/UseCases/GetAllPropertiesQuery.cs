using AutoMapper;
using BookingApi.BusinessLogic.Interfaces;
using BookingApi.Domain.ResponseModels;
using MediatR;

namespace BookingApi.BusinessLogic.UseCases;

public record GetAllPropertiesQuery() : IRequest<IList<PropertyResponseModel>>;

internal sealed class GetAllPropertiesHandler : IRequestHandler<GetAllPropertiesQuery, IList<PropertyResponseModel>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public GetAllPropertiesHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<IList<PropertyResponseModel>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
    {
        var properties = await _unitOfWork.PropertyRepository.GetAll();
        return _mapper.Map<List<PropertyResponseModel>>(properties);
    }
}