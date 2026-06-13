namespace CafePOS_API.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public double AmountTendered { get; set; }
        public double Total {  get; set; }
        public double Change => AmountTendered - Total;
        public virtual Employee Employee { get; set; } = null!;
        public virtual List<OrderItem> Items { get; set; } = null!;
    }
}
