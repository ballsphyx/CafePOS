using CafePOS_API.Models.Entities;

namespace CafePOS_API.Models.DTOs.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public double AmountTendered { get; set; }
        public double Total { get; set; }
        public double Change { get; set; }
        public List<OrderItemResponse> Items { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int EmployeeId { get; set; }
    }
}
