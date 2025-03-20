using Microsoft.AspNetCore.Mvc;
using BookingApi.BusinessLogic.UseCases;
using BookingApi.Data.Repositories;
using BookingApi.Domain.ResponseModels;
using MediatR;

namespace BookingApi.Controllers;
    [ApiController]
    [Route("/api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<PropertyResponseModel>>> GetAll()
        {
            var properties = await _mediator.Send(new GetAllPropertiesQuery());
            return Ok(properties);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PropertyResponseModel>> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetByIdPropertyQuery(id)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProperty([FromBody] CreatePropertyCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<PropertyResponseModel>> UpdateProperty([FromRoute]Guid id,
            [FromBody] SubmitPropertyCommand command)
        {
            var updatedCommand = command with { Id = id };
            return Ok(await _mediator.Send(updatedCommand));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteProperty([FromRoute]Guid id)
        {
            return Ok(await _mediator.Send(new DeletePropertyCommand(id)));
        }
        /*[HttpGet("available")]
        public async Task<ActionResult<List<PropertyResponseModel>>> GetAvailableProperties([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var properties = await _propRepo.GetAvailableProperties(startDate, endDate);

            // Convert to DTOs
            var propertyDtos = properties.Select(p => p.ToPropertyDto()).ToList();

            // Return the list of available properties
            return Ok(propertyDtos);
        }
        }*/
    }
