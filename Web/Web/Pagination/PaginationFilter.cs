using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Slop.DataAbstractions.Pagination;

namespace Slop.Web.Pagination;

public sealed class PaginationFilter(IOptionsMonitor<PaginationOptions> options) : IEndpointFilter
{
    public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var query = context.GetArgument<PaginationQuery?>(0);
        if (query is null) return next(context);
        
        if(query.PageNumber < 1) query.PageNumber = 1;

        var curOptions = options.CurrentValue;
        var minSize = curOptions.MinPageSize;
        var maxSize = curOptions.MaxPageSize;
        
        query.PageSize = Math.Clamp(query.PageSize, minSize, maxSize);
        
        return next(context);
    }
}
