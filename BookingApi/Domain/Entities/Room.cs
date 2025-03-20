using BookingApi.Domain.Enums;

namespace BookingApi.Domain.Entities;

public class Room : IEntity
{
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public string RoomName { get; set; }
    public int Floor { get; set; }
    public int NumberOfBeds { get; set; }
    public int MaxOccupancy { get; set; }
    public decimal PricePerNight { get; set; }
    public RoomType RoomType { get; set; }
    public BedType BedType { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Property Property { get; set; }
    public ICollection<Booking> Bookings { get; set; }
}