using BookingApi.Domain.Enums;

namespace BookingApi.Domain.ResponseModels;

public class PropertyAmenityResponseModel
{
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public GeneralAmenityType[] GeneralAmenityTypes { get; set; }
    public OutdoorAmenityType[] OutdoorAmenityTypes { get; set; }
}