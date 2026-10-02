namespace Slop.Web.Pagination;

public sealed class PaginationOptions
{
    public const string Section = "Pagination";

    public int MaxPageSize { get; set; } = 100;
    
    public int MinPageSize { get; set; } = 5;
}
