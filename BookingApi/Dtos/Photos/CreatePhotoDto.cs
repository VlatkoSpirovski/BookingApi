namespace BookingApi.Dtos.Photos;

public class CreatePhotoDto
{
    public string Url { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PropertyId { get; set; }
}