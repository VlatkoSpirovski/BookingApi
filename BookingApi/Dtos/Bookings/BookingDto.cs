namespace BookingApi.Dtos.Bookings;

public class BookingDto
{
    public int Id { get; set; }
        
    public int PropertyId { get; set; }
        
    public DateTime StartDate { get; set; }
        
    public DateTime EndDate { get; set; }
        
    public string UserId { get; set; } // Assuming you have user identification
        
    public bool IsConfirmed { get; set; } = false; // Indicate if the booking is confirmed
}