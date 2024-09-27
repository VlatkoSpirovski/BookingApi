using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookingApi.Dtos.Bookings;
using BookingApi.Dtos.PropertyAmenity;
using BookingApi.Enums;

namespace BookingApi.Models
{
    [Table("Property")]
    public class Property
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

        public decimal AverageRating { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedDate { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        public Property()
        {
            CreatedDate = DateTime.UtcNow;
        }

        // Navigation properties
        public List<RatingAndReview> RatingsAndReviews { get; set; } = new List<RatingAndReview>();
        public List<PropertyAmenity> Amenities { get; set; } = new List<PropertyAmenity>();
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        
        public int AddressId { get; set; }
        public Address Address { get; set; }

        // Method to add a booking
        public void AddBooking(BookingDto bookingDto)
        {
            // Check if the property is available for the requested dates
            var isAvailable = !Bookings.Any(b =>
                (bookingDto.StartDate < b.EndDate && bookingDto.EndDate > b.StartDate));

            if (!isAvailable)
            {
                throw new InvalidOperationException("Property is not available for the selected dates.");
            }

            // Create a new booking from the bookingDto
            var booking = new Booking
            {
                PropertyId = bookingDto.PropertyId,
                StartDate = bookingDto.StartDate,
                EndDate = bookingDto.EndDate,
                UserId = bookingDto.UserId
                // Initialize other booking properties as needed
            };

            // Add the booking to the property
            Bookings.Add(booking);
        }
    }
}
