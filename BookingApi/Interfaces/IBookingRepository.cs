using BookingApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingApi.Dtos.Bookings;

namespace BookingApi.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<BookingDto>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task CreateAsync(Booking booking);
        Task<Booking?> UpdateAsync(Booking booking, int id);
        Task<bool> DeleteAsync(int id);
    }
}