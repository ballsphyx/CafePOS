using CafePOS_API.Models.DTOs.Requests;
using CafePOS_API.Models.DTOs.Response;
using CafePOS_API.Models.Entities;

namespace CafePOS_API.Repositories.Interfaces
{
    public interface IProductRepo
    {
        Task<Product> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task<bool> DeleteAsync(Product product);
        Task<Product> GetByNameAsync(string name);
        IQueryable<Product> GetQueryable();
    }
}
