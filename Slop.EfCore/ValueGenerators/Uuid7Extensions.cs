using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Slop.EfCore.Abstractions;

namespace Slop.EfCore.ValueGenerators;

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
