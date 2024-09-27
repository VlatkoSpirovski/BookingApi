using System.ComponentModel.DataAnnotations;
using BookingApi.Dtos.Address;
using BookingApi.Dtos.Photos;
using BookingApi.Dtos.PropertyAmenity;
using BookingApi.Enums;
using BookingApi.Models;

namespace BookingApi.DTOs.Property;

public class CreatePropertyRequestDto
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MinLength(50, ErrorMessage = "Description must be at least 50 characters")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(1, 20, ErrorMessage = "Number of bathrooms must be greater than 1")]
    public int NumberOfBathrooms { get; set; }

    [Required]
    [Range(1, 50, ErrorMessage = "Number of rooms must be greater than 1")]
    public int NumberOfRooms { get; set; }

    [Required]
    [Range(5, 5000, ErrorMessage = "Price per night must be at least 5 euros.")]
    public decimal PricePerNight { get; set; }

    [Required]
    [Range(1, 50, ErrorMessage = "Max guests must be at least 1 Guest")]
    public int MaxGuests { get; set; }

    public decimal AverageRating { get; set; }
    public bool IsAvailable { get; set; } = true;
    
    [Required]
    public PropertyType Type { get; set; }
    
    //Address
    public CreateAddressDto Address { get; set; }
    public List<CreatePropertyAmenityDto> Amenities { get; set; } = new List<CreatePropertyAmenityDto>();
    public List<CreatePhotoViaPropertyDto> Photos { get; set; } = new List<CreatePhotoViaPropertyDto>();


 }