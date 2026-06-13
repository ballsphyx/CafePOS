using CafePOS_API.Models.DTOs.Requests;
using CafePOS_API.Models.DTOs.Response;
using CafePOS_API.Models.Entities;

namespace CafePOS_API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();
        Task<OrderResponse> GetOrderAsync(int id);
        Task<OrderResponse> CreateOrder(OrderRequest dto);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> UpdateOrderAsync(int id, OrderRequest dto);
    }
}
