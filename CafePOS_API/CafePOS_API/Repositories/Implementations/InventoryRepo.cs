using CafePOS_API.Data;
using CafePOS_API.Models.Entities;
using CafePOS_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CafePOS_API.Repositories.Implementations
{
    public class InventoryRepo(CafeDbContext _context) : IInventoryRepo
    {
        public async Task<bool> AddAsync(Inventory item)
        {
            _context.Inventory.Add(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> GetStockByProductIdAsync(int id)
        {
            return await _context.Inventory
                .Where(i => i.ProductId == id)
                .SumAsync(i => i.QuantityChanged);
        }
    }
}
