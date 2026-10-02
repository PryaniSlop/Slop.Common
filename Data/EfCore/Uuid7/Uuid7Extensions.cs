using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Slop.DataAbstractions.Uuid7;

namespace Slop.EfCore.Uuid7;

public static class Uuid7Extensions
{
    extension<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : class, IId
    {
        public EntityTypeBuilder<TEntity> ConfigureUuid7()
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id).HasValueGenerator<Uuid7Generator>();
            
            return builder;
        }
    }
}
