namespace BookingApi.Domain.ResponseModels.Bookings;

public class BookingResponseModel
{
    public int Id { get; set; }
        
    public int PropertyId { get; set; }
        
    public DateTime StartDate { get; set; }
        
    public DateTime EndDate { get; set; }
        
    public string UserId { get; set; }
        
    public bool IsConfirmed { get; set; } = false;
}