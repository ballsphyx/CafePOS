namespace CafePOS_API.Models.DTOs.QueryParams
{
    public class ProductQueryParam
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? SortBy { get; set; }
        public string SortOrder { get; set; } = "asc";
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
