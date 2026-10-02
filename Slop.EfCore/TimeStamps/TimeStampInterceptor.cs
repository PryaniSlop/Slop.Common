using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Slop.EfCore.TimeStamps;

public sealed class TimeStampInterceptor(TimeProvider timeProvider) : ISaveChangesInterceptor
{
    public ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if(eventData.Context is null) return ValueTask.FromResult(result);

        var utcNow = timeProvider.GetUtcNow();
        
        var created = eventData.Context.ChangeTracker.Entries<ICreatedAt>().Where(e => e.State == EntityState.Added);
        foreach (var entry in created)
        {
            entry.Property(e => e.CreatedAt).CurrentValue = utcNow;
        }
        
        var updated = eventData.Context.ChangeTracker.Entries<IUpdatedAt>().Where(e => e.State == EntityState.Modified);
        foreach (var entry in updated)
        {
            entry.Property(e => e.UpdatedAt).CurrentValue = utcNow;
        }
        
        return ValueTask.FromResult(result);
    }
}
