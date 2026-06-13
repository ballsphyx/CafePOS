namespace CafePOS_API.Models.DTOs.Response
{
    public record LoginResponse(string token, string email, string role);
}
