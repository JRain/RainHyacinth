using System;

namespace RainHyacinth.Core
{
    /// <summary>
    /// 缓存依赖
    /// </summary>
    public interface ICacheDependencyService : ICacheService
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dependencyKey">依赖键</param>
        /// <param name="obj"></param>
        void Add<T>(string key, string dependencyKey, T obj);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dependencyKey">依赖键</param>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <param name="timeSpan"></param>
        void Add<T>(string key, string dependencyKey, T obj, TimeSpan timeSpan);
    }
}
