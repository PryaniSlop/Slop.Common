namespace Slop.EfCore.TimeStamps;

public interface ICreatedAt
{
    public DateTimeOffset CreatedAt { get; }
}
