using CafePOS_API.Models.Enums;

namespace CafePOS_API.Models.DTOs.Response
{
    public class RoleResponse
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
    }
}
