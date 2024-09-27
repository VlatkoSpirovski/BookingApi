using BookingApi.Dtos.Bookings;

namespace BookingApi.Services;

public interface IBookingService
{
    Task<bool> CreateBookingAsync(BookingDto bookingDto,string userId);
    // You can add more methods for updating or retrieving bookings if needed
}