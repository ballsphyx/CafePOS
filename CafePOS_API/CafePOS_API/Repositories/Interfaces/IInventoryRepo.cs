using CafePOS_API.Models.Entities;

namespace CafePOS_API.Repositories.Interfaces
{
    public interface IInventoryRepo
    {
        Task<bool> AddAsync(Inventory item);
        Task<int> GetStockByProductIdAsync(int id);
    }
}
