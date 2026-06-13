using CafePOS_API.Models.DTOs.Requests;
using CafePOS_API.Models.DTOs.Response;
using CafePOS_API.Models.Entities;
using CafePOS_API.Repositories.Implementations;
using CafePOS_API.Repositories.Interfaces;
using CafePOS_API.Services.Interfaces;

namespace CafePOS_API.Services.Implementations
{
    public class OrderService(IOrderRepo _repo, IProductRepo _productRepo, IInventoryRepo _inventoryRepo) : IOrderService
    {
        public async Task<OrderResponse> CreateOrder(OrderRequest dto)
        {
            var order = new Order
            {
                EmployeeId = 1,
                AmountTendered = dto.AmountTendered,
                CreatedAt = DateTime.UtcNow,
                Items = new List<OrderItem>()
            };

            foreach (var item in dto.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };
                order.Items.Add(orderItem);
            }

            order.Total = order.Items.Sum(i => i.Subtotal);

            await _repo.AddAsync(order);
            foreach (var item in dto.Items)
            {
                var log = new Inventory
                {
                    ProductId = item.ProductId,
                    EmployeeId = 1,
                    DateCreated = DateTime.UtcNow,
                    QuantityChanged = -item.Quantity
                };
                await _inventoryRepo.AddAsync(log);
            }
            return MapToResponse(order);
        }

        public Task<bool> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            var orders = await _repo.GetAllAsync();
            return orders.Select(o => MapToResponse(o));
        }

        public async Task<OrderResponse> GetOrderAsync(int id)
        {
            var order = await _repo.GetByIdAsync(id);
            return MapToResponse(order);
        }

        public Task<bool> UpdateOrderAsync(int id, OrderRequest dto)
        {
            throw new NotImplementedException();
        }
        private OrderResponse MapToResponse(Order order)
        {
            var response = new OrderResponse
            {
                Id = order.Id,
                AmountTendered = order.AmountTendered,
                Total = order.Total,
                Change = order.Change,
                Items = order.Items.Select(i => new OrderItemResponse
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Subtotal = i.Subtotal
                }).ToList(),
                CreatedAt = order.CreatedAt,
                EmployeeId = order.EmployeeId
            };
            return response;
        }
        private Order MapToOrder(OrderRequest dto)
        {
            var order = new Order
            {
                AmountTendered = dto.AmountTendered,
                Items = dto.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList(),
                EmployeeId = 1
            };
            return order;
        }
    }
}
