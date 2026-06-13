using CafePOS_API.Models.DTOs.QueryParams;
using CafePOS_API.Models.DTOs.Requests;
using CafePOS_API.Models.DTOs.Response;

namespace CafePOS_API.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponse>> GetAllAsync(UserQueryParam query);
        Task<EmployeeResponse> GetByIdAsync(string id);
        Task<bool> UpdateEmployeeAsync(string id, EmployeeRequest request);
        Task<bool> DeleteEmployeeAsync(string id);
    }
}
