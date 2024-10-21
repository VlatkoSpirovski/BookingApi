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

namespace BookingApi.Controllers;

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
    public async Task<ActionResult<Booking>> CreateBooking([FromBody] CreateBookingDto booking)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

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
        
        if (!property.IsAvailable)
        {
            return BadRequest("Property is not available for booking.");
        }

        var reservation = new Booking
        {
            PropertyId = booking.PropertyId,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            UserId = userId
        };

        property.Bookings.Add(reservation);
        await _propertyRepo.UpdateAsync(property, booking.PropertyId);

        return CreatedAtAction(nameof(GetBookingById), new { id = reservation.Id }, reservation);
    }
    
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