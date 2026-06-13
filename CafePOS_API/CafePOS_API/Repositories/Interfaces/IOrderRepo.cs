using CafePOS_API.Models.Entities;

namespace CafePOS_API.Repositories.Interfaces
{
    public interface IOrderRepo
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<Order> AddAsync(Order order);
        Task<bool> UpdateAsync(Order order);
        Task<bool> DeleteAsync(Order order);
    }
}
