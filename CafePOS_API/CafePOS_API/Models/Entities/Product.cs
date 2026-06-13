using System.ComponentModel.DataAnnotations;

namespace CafePOS_API.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual List<Inventory> InventoryLog { get; set; }
    } 
}
