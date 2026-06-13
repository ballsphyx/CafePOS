using CafePOS_API.Models.Entities;

namespace CafePOS_API.Models.DTOs.Response
{
    public record EmployeeResponse(string id, string name, string email, IList<string> roles);
}
