using BookingApi.Dtos.Photos;
using BookingApi.Interfaces;
using BookingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhotoController : ControllerBase
{
    private readonly IPhotoRepository _photoRepo;
    private readonly IPropertyRepository _propertyRepo;

    public PhotoController(IPhotoRepository photoRepo, IPropertyRepository propertyRepo)
    {
        _propertyRepo = propertyRepo;
        _photoRepo = photoRepo;
    }

    [HttpPost("properties/photos")]
    public async Task<IActionResult> AddPhotoToProperty([FromBody] CreatePhotoDto photoDto)
    {
        var property = await _propertyRepo.GetByIdAsync(photoDto.PropertyId);
        if (property == null)
        {
            return NotFound($"Property with ID {photoDto.PropertyId} not found");
        }
        
        var photo = new Photo
        {
            Url = photoDto.Url,
            Description = photoDto.Description,
            PropertyId = photoDto.PropertyId
        };
         
        property.Photos.Add(photo);
        await _propertyRepo.UpdateAsync(property, photoDto.PropertyId);

        return Ok(photo);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<PhotoDto>> GetPhotoById(int id)
    {
        var photo = await _photoRepo.GetPhotoByIdAsync(id);
        if (photo == null)
        {
            return NotFound();
        }

        var photoDto = new PhotoDto
        {
            Id = photo.Id,
            Url = photo.Url,
            Description = photo.Description
        };

        return Ok(photoDto);
    }

    [HttpGet("property/{propertyId}")]
    public async Task<ActionResult<IEnumerable<PhotoDto>>> GetPhotosByPropertyId(int propertyId)
    {
        var photos = await _photoRepo.GetPhotosByPropertyIdAsync(propertyId);
        var photoDtos = photos.Select(p => new PhotoDto
        {
            Id = p.Id,
            Url = p.Url,
            Description = p.Description
        }).ToList();

        return Ok(photoDtos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhoto(int id)
    {
        await _photoRepo.DeletePhotoAsync(id);
        return NoContent();
    }
}
