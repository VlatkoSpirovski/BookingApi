using BookingApi.Domain.Enums;

namespace BookingApi.Domain.Entities;

public class Booking : IEntity
{
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public BookingStatus BookingStatus { get; set; }
    public User? Owner { get; set; }
    public Property? Property { get; set; }
    
}