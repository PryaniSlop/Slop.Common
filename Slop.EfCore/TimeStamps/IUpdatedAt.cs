namespace Slop.EfCore.TimeStamps;

public interface IUpdatedAt
{
    public DateTimeOffset UpdatedAt { get; }
}
