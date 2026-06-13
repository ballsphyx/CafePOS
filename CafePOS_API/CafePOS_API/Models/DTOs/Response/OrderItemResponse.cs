namespace CafePOS_API.Models.DTOs.Response
{
    public class OrderItemResponse
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Subtotal { get; set; }
    }
}
