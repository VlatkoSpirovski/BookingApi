/*using BookingApi.Domain.ResponseModels.Bookings;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Data.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _context;
    public BookingRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<BookingResponseModel>> GetAllAsync()
    {
        

    }

    public async Task<Booking?> GetByIdAsync(int id)
    {
        return await _context.Bookings.Include(p => p.Property1).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task CreateAsync(Booking booking1)
    {
        await _context.Bookings.AddAsync(booking1);
        await _context.SaveChangesAsync();
    }

    public async Task<Booking?> UpdateAsync(Booking booking1, int id)
    {
        var findId = await _context.Bookings.FindAsync(id);
        if (findId != null)
        {
            return null;
        }
        findId.PropertyId = booking1.PropertyId;
        findId.StartDate = booking1.StartDate;
        findId.EndDate = booking1.EndDate;
        findId.UserId = booking1.UserId;
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
}*/