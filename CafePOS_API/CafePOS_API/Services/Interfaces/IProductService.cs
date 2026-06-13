using CafePOS_API.Models.DTOs.QueryParams;
using CafePOS_API.Models.DTOs.Requests;
using CafePOS_API.Models.DTOs.Response;

namespace CafePOS_API.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponse> GetProductByIdAsync(int id);
        Task<ProductResponse> AddProductAsync(ProductRequest dto);
        Task<bool> UpdateProductAsync(int id, ProductRequest dto);
        Task<bool> DeleteProductAsync(int id);
        Task<List<ProductResponse>> GetAllAsync(ProductQueryParam query);
        Task<bool> AdjustProductInventory(int productId, int quantity);
    }
}
