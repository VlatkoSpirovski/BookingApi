using BookingApi.Dtos.RatingsAndReviews;
using BookingApi.Interfaces;
using BookingApi.Mappers;
using BookingApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RatingsAndReviewsController : ControllerBase
{
    private readonly IRatingsAndReviewsRepository _ratingsRepository;
    private readonly IPropertyRepository _propertyRepository;

    public RatingsAndReviewsController(IRatingsAndReviewsRepository ratingsRep, IPropertyRepository propertyRep)
    {
        _ratingsRepository = ratingsRep;
        _propertyRepository = propertyRep;
    }

    [HttpGet]
    public async Task<IActionResult> GetRatingsAndReviews()
    {
        var ratings = await _ratingsRepository.GetAllAsync();
        return Ok(ratings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRatingById(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var rating = await _ratingsRepository.GetByIdAsync(id);
        if (rating == null)
        {
            return NotFound($"Rating with id {id} not found.");
        }
        return Ok(rating.MapToDto());
    }

    [HttpGet("{propertyId}/ratings")]
    public async Task<IActionResult> GetRatingByPropertyId([FromRoute] int propertyId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _propertyRepository.PropertyExist(propertyId))
        {
            return BadRequest("Property not found.");
        }

        var ratings = await _ratingsRepository.GetRatingsByPropertyIdAsync(propertyId);
        if (ratings == null || !ratings.Any())
        {
            return NotFound($"Rating not found for property with id {propertyId}.");
        }
        return Ok(ratings);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddRatingAndReview([FromBody] CreateRatingsDtos ratingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _propertyRepository.PropertyExist(ratingDto.PropertyId))
        {
            return NotFound($"Property with id {ratingDto.PropertyId} already existsnot found.");
        }
        var ratingModel = ratingDto.MapToEntity(ratingDto.PropertyId);
        await _ratingsRepository.CreateIdPropertyAsync(ratingModel);
        return CreatedAtAction(nameof(GetRatingById), new { id = ratingModel.Id }, ratingModel);
    }
}