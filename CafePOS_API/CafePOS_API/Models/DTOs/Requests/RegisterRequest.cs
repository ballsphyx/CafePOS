namespace CafePOS_API.Models.DTOs.Requests
{
    public record RegisterRequest(string fullName, string email, string password);
}
