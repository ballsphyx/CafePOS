using CafePOS_API.Models.Entities;

namespace CafePOS_API.Models.DTOs.Requests
{
    public class OrderRequest
    {
        public List<OrderItemRequest> Items { get; set; } = null!;
        public double AmountTendered { get; set; }
    }
}
