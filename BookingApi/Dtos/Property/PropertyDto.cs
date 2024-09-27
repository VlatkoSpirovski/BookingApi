using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookingApi.Dtos.Address;
using BookingApi.Dtos.Photos;
using BookingApi.Dtos.PropertyAmenity;
using BookingApi.Dtos.RatingsAndReviews;
using BookingApi.Enums;
using BookingApi.Models;
using BookingApi.Dtos.Bookings;


namespace BookingApi.DTOs.Property
{
    public class PropertyDto
    {
        public int Id { get; set; }

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

        public bool IsAvailable { get; set; } = true;

        public decimal AverageRating { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        public List<RatingsAndReviewsDto> RatingsAndReviews { get; set; } = new List<RatingsAndReviewsDto>();
        public List<PropertyAmenityDto> Amenities { get; set; } = new List<PropertyAmenityDto>();
        public List<PhotoDto> Photos { get; set; } = new List<PhotoDto>(); // Include photos

        // Address
        public AddressDto Address { get; set; }

        // List of bookings
        public List<BookingDto> Bookings { get; set; } = new List<BookingDto>();

        // Method to check if a property is available for a given date range
        public bool IsAvailableForDates(DateTime startDate, DateTime endDate)
        {
            // Check if the booking dates overlap with any existing bookings
            foreach (var booking in Bookings)
            {
                if (booking.StartDate < endDate && booking.EndDate > startDate)
                {
                    return false; // Dates overlap, property is not available
                }
            }
            return true; // Property is available
        }

        // Method to add a booking
        public void AddBooking(BookingDto bookingDto)
        {
            if (IsAvailableForDates(bookingDto.StartDate, bookingDto.EndDate))
            {
                Bookings.Add(bookingDto);
                IsAvailable = false; // Set to false as it is now booked
            }
            else
            {
                throw new InvalidOperationException("The property is not available for the selected dates.");
            }
        }
    }
}
