using CafePOS_API.Data;
using CafePOS_API.Models.Entities;
using CafePOS_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CafePOS_API.Repositories.Implementations
{
    public class OrderRepo(CafeDbContext _context) : IOrderRepo
    {
        public async Task<Order> AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(order.Id);
        }

        public Task<bool> DeleteAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.Items)
                .ToListAsync();

            return orders;
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);

            return order;
        }

        public Task<bool> UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
