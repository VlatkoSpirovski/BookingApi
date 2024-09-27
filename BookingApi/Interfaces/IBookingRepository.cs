using BookingApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApi.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task CreateAsync(Booking booking);
        Task<Booking?> UpdateAsync(Booking booking, int id);
        Task<bool> DeleteAsync(int id);
    }
}