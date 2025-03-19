using BookingApi.Domain.Enums;

namespace BookingApi.Domain.Entities;

public class PropertyAmenity : IEntity
{
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public GeneralAmenityType[] GeneralAmenityTypes { get; set; }
    public OutdoorAmenityType[] OutdoorAmenityTypes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Property Property { get; set; }
}