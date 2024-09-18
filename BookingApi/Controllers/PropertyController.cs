using BookingApi.DTOs.Property;
using BookingApi.Interfaces;
using BookingApi.Mappers;
using BookingApi.Models;
using BookingApi.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace BookingApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyRepository _propRepo;
    private readonly IRatingsAndReviewsRepository _ratingRepo;
    public PropertyController(IPropertyRepository propRepo ,IRatingsAndReviewsRepository ratingRepo)
    {
        _propRepo = propRepo;
        _ratingRepo = ratingRepo;
    }

    [HttpGet]
    public async Task<ActionResult<List<PropertyDto>>> GetProperties()
    {
        var properties = await _propRepo.GetAllAsync();

        var propertyDtos = new List<PropertyDto>();

        foreach (var property in properties)
        {
            var averageRating = await _propRepo.CalculateAverageRatingAsync(property.Id);
            var propertyDto = property.ToPropertyDto();
            propertyDto.AverageRating = averageRating;
            propertyDtos.Add(propertyDto);
        }
        return Ok(propertyDtos);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Property>> GetPropertyById(int id)
    {
        var property = await _propRepo.GetByIdAsync(id);
        if (property == null)
        {
            return NotFound();
        }

        var averageRating = await _propRepo.CalculateAverageRatingAsync(id);
        var propertyDto = property.ToPropertyDto();
        propertyDto.AverageRating = averageRating;
        return Ok(propertyDto);
    }
    
    [HttpPost]
    public async Task<ActionResult<Property>> CreateProperty([FromBody] CreatePropertyRequestDto property)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var propertyModel = property.CreatePropertyDto();
        await _propRepo.CreateAsync(propertyModel);
        return CreatedAtAction(nameof(GetPropertyById), new { id = propertyModel.Id }, propertyModel);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Property>> UpdateProperty([FromRoute] int id, [FromBody] UpdatePropertyRequestDto property)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var propertyModel = property.UpdatePropertyDto();
        var updatedProperty = await _propRepo.UpdateAsync(propertyModel, id);
        if (updatedProperty == null)
        {
            return NotFound();
        }
        var updatedPropertyModel = updatedProperty.ToPropertyDto();
        return Ok(updatedPropertyModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProperty(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var propModel = await _propRepo.DeleteAsync(id);
        if (propModel == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}