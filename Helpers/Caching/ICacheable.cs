namespace Slop.Caching;

public interface ICacheable<in TKeyArgs>
{
    static abstract string GetCacheKey(TKeyArgs args);
}

public interface ICacheable<in TKeyArgs, in TTagsArgs> : ICacheable<TKeyArgs>
{ 
    static abstract IEnumerable<string> GetTags(TTagsArgs args);
}
