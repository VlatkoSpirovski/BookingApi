using BookingApi.Data;
using BookingApi.Dtos.Bookings;
using BookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Services;

public class BookingService : IBookingService
{
    private readonly ApplicationDbContext _dbContext;

    public BookingService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateBookingAsync(BookingDto bookingDto, string userId)
    {
        var property = await _dbContext.Properties
            .Include(p => p.Bookings)
            .FirstOrDefaultAsync(p => p.Id == bookingDto.PropertyId);

        if (property == null || !property.IsAvailable)
            return false;

        var booking = new Booking
        {
            PropertyId = bookingDto.PropertyId,
            StartDate = bookingDto.StartDate,
            EndDate = bookingDto.EndDate,
            UserId = userId // Set the UserId from the logged-in user
        };

        property.Bookings.Add(booking); // Add the booking to the property
    
        await _dbContext.SaveChangesAsync();
        return true;
    }

}