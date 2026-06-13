namespace CafePOS_API.Models.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateCreated { get; set; }
        public int QuantityChanged { get; set; }

        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
