namespace CafePOS_API.Models.DTOs.QueryParams
{
    public class UserQueryParam
    {
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? SortBy { get; set; }
        public string SortOrder { get; set; } = "asc";
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
