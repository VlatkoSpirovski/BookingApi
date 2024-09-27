using BookingApi.DTOs.Property;
using BookingApi.Dtos.RatingsAndReviews;
using BookingApi.Interfaces;
using BookingApi.Mappers;
using BookingApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propRepo;
        private readonly IRatingsAndReviewsRepository _ratingRepo;

        public PropertyController(IPropertyRepository propRepo, IRatingsAndReviewsRepository ratingRepo)
        {
            _propRepo = propRepo;
            _ratingRepo = ratingRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PropertyDto>>> GetProperties([FromQuery] PropertyFilterDto filter)
        {
            var properties = await _propRepo.GetAllAsync();

            // Check if properties is null
            if (properties == null)
            {
                return NotFound();
            }

            var propertyDtos = new List<PropertyDto>();

            // Create DTOs and calculate average ratings
            foreach (var property in properties)
            {
                var averageRating = await _propRepo.CalculateAverageRatingAsync(property.Id);
                var propertyDto = property.ToPropertyDto();
                propertyDto.AverageRating = averageRating; // Set the calculated average rating
                propertyDtos.Add(propertyDto);
            }

            // Apply filters
            propertyDtos = ApplyFilters(propertyDtos, filter);

            return Ok(propertyDtos);
        }

        [HttpGet("available")]
        public async Task<ActionResult<List<PropertyDto>>> GetAvailableProperties([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var properties = await _propRepo.GetAvailableProperties(startDate, endDate);

            // Convert to DTOs
            var propertyDtos = properties.Select(p => p.ToPropertyDto()).ToList();
    
            // Return the list of available properties
            return Ok(propertyDtos);
        }


        [HttpGet("search")]
        public async Task<ActionResult<List<PropertyDto>>> SearchProperties(string query)
        {
            var properties = await _propRepo.GetAllAsync();

            // Check if properties is null
            if (properties == null)
            {
                return NotFound();
            }

            var searchedProperties = properties.Where(p =>
                    p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    (p.Address != null && p.Address.Country.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                    (p.Address != null && p.Address.City.Contains(query, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            return Ok(searchedProperties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDto>> GetPropertyById(int id)
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
        public async Task<ActionResult<PropertyDto>> CreateProperty([FromBody] CreatePropertyRequestDto property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertyModel = property.CreatePropertyDto();
            await _propRepo.CreateAsync(propertyModel);
            return CreatedAtAction(nameof(GetPropertyById), new { id = propertyModel.Id }, propertyModel.ToPropertyDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PropertyDto>> UpdateProperty([FromRoute] int id, [FromBody] UpdatePropertyRequestDto property)
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

            return Ok(updatedProperty.ToPropertyDto());
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

        // Apply filters to property DTOs
        private List<PropertyDto> ApplyFilters(List<PropertyDto> propertyDtos, PropertyFilterDto filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                propertyDtos = propertyDtos.Where(p => p.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (filter.NumberOfRooms.HasValue)
            {
                propertyDtos = propertyDtos.Where(p => p.NumberOfRooms >= filter.NumberOfRooms.Value).ToList();
            }

            if (filter.MinPricePerNight.HasValue || filter.MaxPricePerNight.HasValue)
            {
                propertyDtos = propertyDtos.Where(p =>
                    (!filter.MinPricePerNight.HasValue || p.PricePerNight >= filter.MinPricePerNight.Value) &&
                    (!filter.MaxPricePerNight.HasValue || p.PricePerNight <= filter.MaxPricePerNight.Value)
                ).ToList();
            }

            if (filter.PricePerNight.HasValue)
            {
                propertyDtos = propertyDtos.Where(p => p.PricePerNight >= filter.PricePerNight.Value).ToList();
            }

            if (filter.MaxGuests.HasValue)
            {
                propertyDtos = propertyDtos.Where(p => p.MaxGuests >= filter.MaxGuests.Value).ToList();
            }

            if (filter.IsAvailable.HasValue)
            {
                propertyDtos = propertyDtos.Where(p => p.IsAvailable == filter.IsAvailable.Value).ToList();
            }

            if (filter.Type.HasValue)
            {
                propertyDtos = propertyDtos.Where(p => p.Type == filter.Type.Value).ToList();
            }

            if (filter.MinRating.HasValue)
            {
                propertyDtos = propertyDtos
                    .Where(p => p.RatingsAndReviews != null && p.RatingsAndReviews.Any(r => r.Rating >= filter.MinRating.Value))
                    .ToList();
            }

            if (filter.MinRatingCount.HasValue)
            {
                propertyDtos = propertyDtos.Where(p => p.RatingsAndReviews.Count >= filter.MinRatingCount.Value).ToList();
            }

            if (!string.IsNullOrEmpty(filter.Country))
            {
                propertyDtos = propertyDtos.Where(p => p.Address != null && p.Address.Country == filter.Country).ToList();
            }

            if (!string.IsNullOrEmpty(filter.City))
            {
                propertyDtos = propertyDtos.Where(p => p.Address != null && p.Address.City == filter.City).ToList();
            }

            return propertyDtos;
        }
    }
}
