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

    [HttpPut]
    public async Task<ActionResult<PropertyAmenityResponseModel>> SubmitPropertyAmenities(
        [FromRoute] Guid propertyId,
        [FromBody] SubmitPropertyAmenitiesCommand command)
    {
        return Ok(await _mediator.Send(command));
        
    }
}