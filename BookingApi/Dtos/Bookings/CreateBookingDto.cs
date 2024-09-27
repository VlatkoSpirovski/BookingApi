namespace BookingApi.Dtos.Bookings;

public class CreateBookingDto
{
    public int PropertyId { get; set; }
        
    public DateTime StartDate { get; set; }
        
    public DateTime EndDate { get; set; }
        
    public string UserId { get; set; } // Assuming you have user identification
}