using CafePOS_API.Models.Enums;

namespace CafePOS_API.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public RoleEnum RoleName { get; set; }
        public virtual List<Employee>? Employees { get; set; }
    }
}
