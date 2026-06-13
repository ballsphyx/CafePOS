namespace CafePOS_API.Models.DTOs.Response
{
    public record AuthResponse(string token, string email, string fullname, IList<string> roles);
}
