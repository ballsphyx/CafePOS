using Microsoft.AspNetCore.Identity;

namespace CafePOS_API.Models.Entities
{
    public class Employee : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<IdentityUserRole<string>> Roles { get; set; } = [];
    }
}
