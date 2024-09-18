namespace BookingApi.Dtos.Photos;

public class PhotoDto
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;

}