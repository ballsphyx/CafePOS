using CafePOS_API.Models.Entities;
using CafePOS_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CafePOS_API.Repositories.Implementations
{
    public class EmployeeRepo(UserManager<Employee> userManager) : IEmployeeRepo
    {
        public async Task<IdentityResult> DeleteAsync(Employee employee) => await userManager.DeleteAsync(employee);

        public IQueryable<Employee> GetQueryable() => userManager.Users.AsQueryable();

        public async Task<IList<string>> GetRolesAsync(Employee employee) => await userManager.GetRolesAsync(employee);

        public async Task<Employee?> GeyByIdAsync(string id) => await userManager.FindByIdAsync(id);

        public async Task<IdentityResult> UpdateAsync(Employee employee) => await userManager.UpdateAsync(employee);
    }
}
