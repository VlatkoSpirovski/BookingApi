namespace BookingApi.Domain.ResponseModels.Address;

public class AddressResponseModel
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int PostalCode { get; set;}
}