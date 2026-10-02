namespace Slop.DataAbstractions.Pagination;

public sealed class PagedList<T>
{
    internal PagedList() { }
    
    public required IReadOnlyCollection<T> Items { get; init; }
    
    public int TotalPages { get; init; }
    
    public int PageNumber { get; init; }
    
    public int PageSize { get; init; }
}
