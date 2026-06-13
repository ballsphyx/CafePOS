namespace CafePOS_API.Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Subtotal => UnitPrice * Quantity;
        public virtual Product Product { get; set; } = null!;
    }
}
