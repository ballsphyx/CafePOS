using CafePOS_API.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace CafePOS_API.Repositories.Interfaces
{
    public interface IEmployeeRepo
    {
        Task<Employee> GeyByIdAsync(string id);
        IQueryable<Employee> GetQueryable();
        Task<IdentityResult> UpdateAsync(Employee employee);
        Task<IdentityResult> DeleteAsync(Employee employee);
        Task<IList<string>> GetRolesAsync(Employee employee); 
    }
}
