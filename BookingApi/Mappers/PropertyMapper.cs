using BookingApi.Dtos.Address;
using BookingApi.Dtos.Photos;
using BookingApi.DTOs.Property;
using BookingApi.Dtos.PropertyAmenity;
using BookingApi.Dtos.RatingsAndReviews;
using BookingApi.Models;

namespace BookingApi.Mappers
{
    public static class PropertyMapper
    {
        public static PropertyDto ToPropertyDto(this Property propertyModel)
        {
            return new PropertyDto
            {
                Id = propertyModel.Id,
                Name = propertyModel.Name,
                Description = propertyModel.Description,
                NumberOfBathrooms = propertyModel.NumberOfBathrooms,
                NumberOfRooms = propertyModel.NumberOfRooms,
                PricePerNight = propertyModel.PricePerNight,
                MaxGuests = propertyModel.MaxGuests,
                IsAvailable = propertyModel.IsAvailable,
                Type = propertyModel.Type,
                AverageRating = propertyModel.AverageRating,
                CreatedDate = propertyModel.CreatedDate,
                RatingsAndReviews = propertyModel.RatingsAndReviews.Select(r => new RatingsAndReviewsDto
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Review = r.Review,
                    CreatedDate = r.CreatedDate,
                }).ToList(),
                Address = new AddressDto
                {
                    Street = propertyModel.Address.Street,
                    City = propertyModel.Address.City,
                    Country = propertyModel.Address.Country,
                    PostalCode= propertyModel.Address.PostalCode
                },
                Amenities = propertyModel.Amenities.Select(a => new PropertyAmenityDto
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList(),
                Photos = propertyModel.Photos.Select(p => new PhotoDto
                {
                    Id = p.Id,
                    Url = p.Url,
                    Description = p.Description
                }).ToList(),
            };
        }


        public static Property CreatePropertyDto(this CreatePropertyRequestDto createPropertyRequest)
        {
            return new Property
            {
                Name = createPropertyRequest.Name,
                Description = createPropertyRequest.Description,
                NumberOfBathrooms = createPropertyRequest.NumberOfBathrooms,
                NumberOfRooms = createPropertyRequest.NumberOfRooms,
                PricePerNight = createPropertyRequest.PricePerNight,
                MaxGuests = createPropertyRequest.MaxGuests,
                IsAvailable = createPropertyRequest.IsAvailable,
                AverageRating = createPropertyRequest.AverageRating,
                Type = createPropertyRequest.Type,
                CreatedDate = DateTime.UtcNow,
                Address = new Address
                {
                    Street = createPropertyRequest.Address.Street,
                    City = createPropertyRequest.Address.City,
                    Country = createPropertyRequest.Address.Country,
                    PostalCode = createPropertyRequest.Address.PostalCode
                },
                Amenities = createPropertyRequest.Amenities.Select(a => new PropertyAmenity
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList()
            };
        }

        public static Property UpdatePropertyDto(this UpdatePropertyRequestDto updatePropertyRequest)
        {
            return new Property
            {
                Name = updatePropertyRequest.Name,
                Description = updatePropertyRequest.Description,
                NumberOfBathrooms = updatePropertyRequest.NumberOfBathrooms,
                NumberOfRooms = updatePropertyRequest.NumberOfRooms,
                PricePerNight = updatePropertyRequest.PricePerNight,
                MaxGuests = updatePropertyRequest.MaxGuests,
                IsAvailable = updatePropertyRequest.IsAvailable,
                AverageRating = updatePropertyRequest.AverageRating,
                Type = updatePropertyRequest.Type,
                CreatedDate = DateTime.UtcNow,
                Address = new Address
                {
                    Street = updatePropertyRequest.Address.Street,
                    City = updatePropertyRequest.Address.City,
                    Country = updatePropertyRequest.Address.Country,
                    PostalCode = updatePropertyRequest.Address.PostalCode
                },
                Amenities = updatePropertyRequest.Amenities.Select(a => new PropertyAmenity
                {
                    Name = a.Name
                }).ToList()
            };
        }
    }
}
