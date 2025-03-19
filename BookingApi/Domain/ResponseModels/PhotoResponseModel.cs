namespace BookingApi.Domain.ResponseModels.Photos;

public class PhotoResponseModel
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;

}