using CafePOS_API.Models.DTOs.QueryParams;
using CafePOS_API.Models.DTOs.Requests;
using CafePOS_API.Models.DTOs.Response;
using CafePOS_API.Models.Entities;
using CafePOS_API.Repositories.Interfaces;
using CafePOS_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CafePOS_API.Services.Implementations
{
    public class ProductService(IProductRepo _repo, IInventoryRepo _inventoryRepo) : IProductService
    {
        public async Task<ProductResponse> AddProductAsync(ProductRequest dto)
        {
            var product = MapToProduct(dto);
            var p = await _repo.AddAsync(product);

            var inventory = new Inventory
            {
                ProductId = product.Id,
                EmployeeId = 1,
                DateCreated = DateTime.UtcNow,
                QuantityChanged = dto.InitialStock
            };
            await _inventoryRepo.AddAsync(inventory);
            return MapToResponse(p);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return false;
            return await _repo.DeleteAsync(p);
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return null;
            return MapToResponse(product);
        }

        public async Task<bool> UpdateProductAsync(int id, ProductRequest dto)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return false;
            p.Name = dto.Name;
            p.Price = dto.Price;
            p.CategoryId = dto.CategoryId; //add stocks
            return await _repo.UpdateAsync(p);
        }
        public async Task<bool> AdjustProductInventory(int productId, int quantity)
        {
            var p = await _repo.GetByIdAsync(productId);
            if (p == null) return false;
            int currentStock = await _inventoryRepo.GetStockByProductIdAsync(p.Id);
            int difference = quantity - currentStock;
            var log = new Inventory
            {
                ProductId = p.Id,
                EmployeeId = 1,
                DateCreated = DateTime.UtcNow,
                QuantityChanged = difference
            };
            return await _inventoryRepo.AddAsync(log);
        }

        private ProductResponse MapToResponse(Product product)
        {
            var response = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = new CategoryResponse
                {
                    Id = product.Category.Id,
                    Name = product.Category.CategoryName
                },
                Stock = product.InventoryLog.Sum(i => i.QuantityChanged)
            };
            return response;
        }
        private Product MapToProduct(ProductRequest productRequest)
        {
            var p = new Product
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
                CategoryId = productRequest.CategoryId,
            };
            return p;
        }

        public async Task<List<ProductResponse>> GetAllAsync(ProductQueryParam query)
        {
            var products = _repo.GetQueryable();

            if (!string.IsNullOrEmpty(query.Name))
                products = products.Where(p => EF.Functions.Like(p.Name, $"%{query.Name}%"));
            if (!string.IsNullOrEmpty(query.Category))
                products = products.Where(p => p.Category.CategoryName == query.Category);

            products = query.SortBy switch
            {
                "Name" => query.SortOrder == "desc" ? products.OrderByDescending(p => p.Name) : products.OrderBy(p => p.Name),
                "Category" => query.SortOrder == "desc" ? products.OrderByDescending(p => p.Category.CategoryName) : products.OrderBy(p => p.Category.CategoryName),
                "Price" => query.SortOrder == "desc" ? products.OrderByDescending(p => p.Price) : products.OrderBy(p => p.Price),
                _ => products.OrderBy(p => p.Id)
            };

            products = products.Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize);

            var result = await products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = new CategoryResponse
                {
                    Id = p.Category.Id,
                    Name = p.Category.CategoryName
                },
                Stock = p.InventoryLog.Sum(p => p.QuantityChanged)
            }).ToListAsync();
            return result;
        }
    }
}
