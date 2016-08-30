using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace RainHyacinth.Core.Imp
{
    /// <summary>
    /// 缓存依赖
    /// </summary>
    public class CacheDependencyService : CacheService, ICacheDependencyService
    {
        public void Add<T>(string key, string dependencyKey, T obj)
        {
            if (obj == null)
                return;
            var policy = new CacheItemPolicy { Priority = CacheItemPriority.NotRemovable };
            LocalCache.Add(new CacheItem(key, obj), policy);
            HostFileChangeMonitor monitor = new HostFileChangeMonitor(new List<string>() { dependencyKey });
            monitor.NotifyOnChanged(new OnChangedCallback((o) =>
            {
                LocalCache.Remove(key);
            }));
            policy.ChangeMonitors.Add(monitor);
        }

        public void Add<T>(string key, string dependencyKey, T obj, TimeSpan timeSpan)
        {
            if (obj == null)
                return;
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + timeSpan };
            LocalCache.Add(new CacheItem(key, obj), policy);
            HostFileChangeMonitor monitor = new HostFileChangeMonitor(new List<string>() { dependencyKey });
            monitor.NotifyOnChanged(new OnChangedCallback((o) =>
            {
                LocalCache.Remove(key);
            }));
            policy.ChangeMonitors.Add(monitor);
        }
    }
}
