using System;
using System.Runtime.Caching;

namespace Iheik.Domain.Caching
{
    public class DefaultCacheProvider : ICacheProvider
    {
        // the cache object store
        private ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        /// <summary>
        /// Gets the Cache item for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public object Get(CacheKey key)
        {
            return Cache[key.ToString()];
        }

        public object Get(string key)
        {
            return Cache[key];
        }

        /// <summary>
        /// Sets the Cache item for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="cacheTime">The cache time - sliding scale in minutes.</param>
        public void Set(CacheKey key, object data, int cacheTime)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
            };

            Cache.Add(new CacheItem(key.ToString(), data), policy);
        }

        public void Set(string key, object data, int cacheTime)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
            };

            Cache.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// Determines whether the specified key is set.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Boolean - True for the specified key being set.</returns>
        public bool IsSet(CacheKey key)
        {
            return (Cache[key.ToString()] != null);
        }

        public bool IsSet(string key)
        {
            return (Cache[key] != null);
        }

        /// <summary>
        /// Invalidates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Invalidate(CacheKey key)
        {
            Cache.Remove(key.ToString());
        }

        public void Invalidate(string key)
        {
            Cache.Remove(key);
        }

    }
}
