using Microsoft.Extensions.Caching.Hybrid;

namespace Slop.Caching;

public static class CachingExtensions
{
    extension(HybridCache cache)
    {
        public ValueTask<TValue> GetOrCreateAsync<TValue, TKeyArgs>(
            Func<CancellationToken, ValueTask<TValue>> factory,
            TKeyArgs keyArgs,
            HybridCacheEntryOptions? options,
            CancellationToken cancellationToken = default) where TValue : ICacheable<TKeyArgs>
        {
            var key = TValue.GetCacheKey(keyArgs);
            return cache.GetOrCreateAsync(
                key,
                factory,
                options: options,
                cancellationToken: cancellationToken);
        } 
        
        public ValueTask<TValue> GetOrCreateAsync<TValue, TKeyArgs, TTagsArgs>(
            Func<CancellationToken, ValueTask<TValue>> factory,
            TKeyArgs keyArgs,
            TTagsArgs? tagsArgs,
            HybridCacheEntryOptions? options,
            CancellationToken cancellationToken = default) where TValue : ICacheable<TKeyArgs, TTagsArgs>
        {
            var key = TValue.GetCacheKey(keyArgs);
            var tags = tagsArgs is null? [] : TValue.GetTags(tagsArgs);
            
            return cache.GetOrCreateAsync(
                key,
                factory,
                tags: tags,
                options: options,
                cancellationToken: cancellationToken);
        }

        public ValueTask SetAsync<TValue, TKeyArgs>(
            TKeyArgs keyArgs,
            TValue newValue,
            HybridCacheEntryOptions? options,
            CancellationToken cancellationToken = default) where TValue : ICacheable<TKeyArgs>
        {
            var key = TValue.GetCacheKey(keyArgs);
            return cache.SetAsync(
                key, 
                newValue, 
                options: options,
                cancellationToken: cancellationToken);
        }
        
        public ValueTask SetAsync<TValue, TKeyArgs, TTagsArgs>(
            TKeyArgs keyArgs,
            TValue newValue,
            TTagsArgs? tagsArgs,
            HybridCacheEntryOptions? options,
            CancellationToken cancellationToken = default) where TValue : ICacheable<TKeyArgs, TTagsArgs>
        {
            var key = TValue.GetCacheKey(keyArgs);
            var tags = tagsArgs is null? [] : TValue.GetTags(tagsArgs);
            
            return cache.SetAsync(
                key, 
                newValue, 
                tags: tags,
                options: options,
                cancellationToken: cancellationToken);
        }
        
        public ValueTask RemoveByKeyAsync<TValue, TKeyArgs>(TKeyArgs keyArgs, CancellationToken cancellationToken = default) where TValue : ICacheable<TKeyArgs>
        {
            var key = TValue.GetCacheKey(keyArgs);
            return cache.RemoveAsync(key, cancellationToken);
        }

        public ValueTask RemoveByKeysAsync<TValue, TKeyArgs>(IEnumerable<TKeyArgs> keyArgs, CancellationToken cancellationToken = default) where TValue : ICacheable<TKeyArgs>
        {
            var keys = keyArgs.Select(TValue.GetCacheKey);
            return cache.RemoveAsync(keys, cancellationToken);
        }
        
        public ValueTask RemoveByTagsAsync<TValue, TKeyArgs, TTagsArgs>(TTagsArgs tagsArgs, CancellationToken cancellationToken = default) 
            where TValue : ICacheable<TKeyArgs, TTagsArgs>
        {
            var tags = TValue.GetTags(tagsArgs);
            return cache.RemoveByTagAsync(tags, cancellationToken);
        }
    }
}
