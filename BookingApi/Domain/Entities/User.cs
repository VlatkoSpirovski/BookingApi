using Microsoft.AspNetCore.Identity;

namespace BookingApi.Domain.Entities;

public class User : IdentityUser
{
    public string UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public DateOnly? Birthday { get; set; }
    public string? Profession { get; set; }
}