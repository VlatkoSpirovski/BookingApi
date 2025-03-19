namespace BookingApi.Domain.Exceptions;

public class NotFoundException : Exception
{
    public static readonly string ErrorCode = "404";
    public NotFoundException(string name) : base($"{name} not found")
    {
    }
}