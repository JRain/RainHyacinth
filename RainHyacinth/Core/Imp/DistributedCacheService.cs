using System;

namespace RainHyacinth.Core.Imp
{
    /// <summary>
    /// 分布式缓存
    /// </summary>
    public class DistributedCacheService : IDistributedCacheService
    {
        public void Add<T>(string key, T obj)
        {
            throw new NotImplementedException();
        }

        public void Add<T>(string key, T obj, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public T GetCacheOjbect<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveCache(params string[] key)
        {
            throw new NotImplementedException();
        }
    }
}
