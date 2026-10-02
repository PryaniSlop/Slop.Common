using Microsoft.Extensions.DependencyInjection;

namespace Slop.Web.Pagination;

public static class PaginationExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection ConfigurePagination()
        {
            services
                .AddOptions<PaginationOptions>()
                .BindConfiguration(PaginationOptions.Section)
                .ValidateOnStart();
            
            return services;
        }
    }
}
