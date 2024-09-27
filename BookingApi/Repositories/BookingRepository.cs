using System.Runtime.InteropServices.JavaScript;
using BookingApi.Data;
using BookingApi.Interfaces;
using BookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _context;
    public BookingRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Booking>> GetAllAsync()
    {
        return await _context.Bookings.Include(p => p.Property).ToListAsync();
    }

    public async Task<Booking?> GetByIdAsync(int id)
    {
        return await _context.Bookings.Include(p => p.Property).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task CreateAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    public async Task<Booking?> UpdateAsync(Booking booking, int id)
    {
        var findId = await _context.Bookings.FindAsync(id);
        if (findId != null)
        {
            return null;
        }
        findId.PropertyId = booking.PropertyId;
        findId.StartDate = booking.StartDate;
        findId.EndDate = booking.EndDate;
        findId.UserId = booking.UserId;
        await _context.SaveChangesAsync();
        return findId;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var findId = await _context.Bookings.FindAsync(id);
        if (findId != null)
        {
            return false;
        }
        _context.Bookings.Remove(findId);
        await _context.SaveChangesAsync();
        return true;
    }
}