namespace CafePOS_API.Models.DTOs.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public CategoryResponse Category { get; set; } = null!;
        public int Stock { get; set; }
    }
}
