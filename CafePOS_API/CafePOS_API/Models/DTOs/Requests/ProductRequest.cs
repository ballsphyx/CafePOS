using CafePOS_API.Models.DTOs.Response;
using CafePOS_API.Models.Entities;

namespace CafePOS_API.Models.DTOs.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int CategoryId { get; set; } 
        public int InitialStock {  get; set; }
    }
}
