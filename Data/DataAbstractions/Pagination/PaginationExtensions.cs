namespace Slop.DataAbstractions.Pagination;

public static class PaginationExtensions
{
    extension<T>(IReadOnlyCollection<T> items)
    {
        public PagedList<T> ToPagedList(PaginationQuery query, int count)
        {
            return new()
            {
                Items = items,
                PageSize = query.PageSize,
                PageNumber = query.PageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)query.PageSize)
            };
        }
    }
}
