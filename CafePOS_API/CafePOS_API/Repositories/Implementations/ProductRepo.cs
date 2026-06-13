using CafePOS_API.Data;
using CafePOS_API.Models.DTOs.Requests;
using CafePOS_API.Models.DTOs.Response;
using CafePOS_API.Models.Entities;
using CafePOS_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace CafePOS_API.Repositories.Implementations
{
    public class ProductRepo(CafeDbContext _context) : IProductRepo
    {
        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(product.Id);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.InventoryLog)
                .FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.InventoryLog)
                .FirstOrDefaultAsync(p => p.Name == name);
        }
        public IQueryable<Product> GetQueryable()
        {
            return _context.Products.AsQueryable();
        }
    }
}
