using System;
using System.Linq;
using System.Runtime.Caching;

namespace RainHyacinth.Core.Imp
{
    /// <summary>
    /// 本机缓存
    /// </summary>
    public class CacheService : ICacheService
    {
        protected ObjectCache LocalCache => MemoryCache.Default;
        public void Add<T>(string key, T obj)
        {
            if (obj == null)
                return;
            var policy = new CacheItemPolicy { Priority = CacheItemPriority.NotRemovable };
            //永久缓存
            LocalCache.Add(new CacheItem(key, obj), policy);
        }

        public void Add<T>(string key, T obj, TimeSpan timeSpan)
        {
            if (obj == null)
                return;
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + timeSpan };
            LocalCache.Add(new CacheItem(key, obj), policy);
        }

        public T GetCacheOjbect<T>(string key)
        {
            if (null == LocalCache[key]) return default(T);
            return (T)LocalCache[key];
        }

        public void RemoveCache(params string[] key)
        {
            if (!key.Any()) return;
            foreach (var k in key)
            {
                LocalCache.Remove(k);
            }
        }
    }
}
