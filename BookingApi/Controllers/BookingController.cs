using BookingApi.Models;
using BookingApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BookingApi.Data;
using BookingApi.Dtos.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingRepository _bookingRepo;
    private readonly IPropertyRepository _propertyRepo;
    private readonly ApplicationDbContext _dbContext;
    public BookingController(IBookingRepository bookingRepo, IPropertyRepository propertyRep, ApplicationDbContext dbContext)
    {
        _propertyRepo = propertyRep;
        _bookingRepo = bookingRepo;
        _dbContext = dbContext;
    }
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<Booking>>> GetBookings()
    {
        var bookings = await _bookingRepo.GetAllAsync();
        return Ok(bookings);
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBookingById(int id)
    {
        var booking = await _bookingRepo.GetByIdAsync(id);
        if (booking == null)
        {
            return NotFound();
        }
        return Ok(booking);
    }
    

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Booking>> CreateBooking([FromBody] CreateBookingDto booking)
    {
        // Get the User ID from the claims
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        // Check if the user exists in the database
        var userExists = await _dbContext.Users.AnyAsync(u => u.Id == userId);
        if (!userExists)
        {
            return NotFound($"User with ID {userId} does not exist.");
        }

        var property = await _propertyRepo.GetByIdAsync(booking.PropertyId);
        if (property == null)
        {
            return NotFound($"Property with ID {booking.PropertyId} not found");
        }

        // Ensure that the property is available for booking
        if (!property.IsAvailable)
        {
            return BadRequest("Property is not available for booking.");
        }

        var reservation = new Booking
        {
            PropertyId = booking.PropertyId,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            UserId = userId // Use the logged-in user's ID
        };

        property.Bookings.Add(reservation); // Add booking to the property
        await _propertyRepo.UpdateAsync(property, booking.PropertyId); // Update property in the database

        return CreatedAtAction(nameof(GetBookingById), new { id = reservation.Id }, reservation); // Return created booking
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBooking(int id)
    {
        var result = await _bookingRepo.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}