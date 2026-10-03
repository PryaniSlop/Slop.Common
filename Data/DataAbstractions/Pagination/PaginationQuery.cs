namespace Slop.DataAbstractions.Pagination;

public sealed class PaginationQuery(int pageNumber, int pageSize)
{
    public int PageNumber { get; set; } = pageNumber;

    public int PageSize { get; set; } = pageSize;
}
