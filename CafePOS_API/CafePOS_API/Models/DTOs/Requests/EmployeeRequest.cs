namespace CafePOS_API.Models.DTOs.Requests
{
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
