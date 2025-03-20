using BookingApi.BusinessLogic.UseCases;
using BookingApi.Domain.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PropertyAmenityController : ControllerBase
{
    private readonly IMediator _mediator;
    public PropertyAmenityController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{propertyId:guid}")]
    public async Task<ActionResult<PropertyAmenityResponseModel>> GetPropertyAmenities(
        [FromRoute] Guid propertyId)
    {
        return Ok(await _mediator.Send(new GetByPropertyIdPropertyAmenityQuery(propertyId)));
    }
    
    [HttpPatch("{propertyId:guid}")]
    public async Task<ActionResult<PropertyAmenityResponseModel>> SubmitPropertyAmenities(
        [FromBody] SubmitPropertyAmenitiesCommand command)
    {
        return Ok(await _mediator.Send(command));
        
    }
}