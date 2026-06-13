namespace CafePOS_API.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public virtual List<Product> Products { get; set; } = null!;
    }
}
