using Microsoft.EntityFrameworkCore;
using Slop.DataAbstractions.Pagination;

namespace Slop.EfCore.Pagination;

public static class PaginationExtensions
{
    extension<T>(IQueryable<T> queryable)
    {
        public async Task<PagedList<T>> ToPagedListAsync(PaginationQuery query, CancellationToken cancellationToken = default)
        {
            var count = await queryable.CountAsync(cancellationToken: cancellationToken);
            
            var items = await queryable
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(cancellationToken);

            return items.ToPagedList(query, count);
        }
    }
}
