using BookingApi.Domain.Entities;
using BookingApi.Domain.Enums;

namespace BookingApi.Domain.ResponseModels
{
    public class PropertyResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int? NumberOfRooms { get; set; }
        public int? NumberOfBathrooms { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public int? NumberOfKitchens { get; set; }
        public int? NumberOfLivingRooms { get; set; }
        public int? NumberOfBalconies { get; set; }
        public int? MaxGuests { get; set; }
        //public int NumberOfBookings { get; set; }
        public int? MinBookingLeadTimeDays { get; set; }
        public decimal? PricePerNight { get; set; }
        public decimal? AverageRating { get; set; }
        public decimal? DiscountPercentage { get; set; }
        //public bool IsAvailable { get; set; } = true;
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
        public DateTime? LastBookedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DiscountStartDate { get; set; }
        public DateTime? DiscountEndDate { get; set; }
        public PropertyType PropertyType { get; set; }
        public PropertyStatus? PropertyStatus { get; set; }
        public UserResponseModel Owner { get; set; }
        public List<PropertyAmenityResponseModel>? PropertyAmenities { get; set; }
        //public List<BookingResponseModel> Bookings { get; set; } = new List<BookingResponseModel>();
    }
}
