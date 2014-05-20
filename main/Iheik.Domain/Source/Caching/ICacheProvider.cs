using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iheik.Domain.Caching
{
    public interface ICacheProvider
    {
        object Get(CacheKey key);
        void Set(CacheKey key, object data, int cacheTime);
        bool IsSet(CacheKey key);
        void Invalidate(CacheKey key);

        // for user custom keys
        object Get(string key);
        void Set(string key, object data, int cacheTime);
        bool IsSet(string key);
        void Invalidate(string key);
    }
}
