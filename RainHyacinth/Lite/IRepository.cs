using System.Linq;
using RainHyacinth.Lite.Imp;

namespace RainHyacinth.Lite
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : RainLite
    {
        /// <summary>
        /// 仓储中心上下文
        /// </summary>
        IRainLiteContext Context { get; }
        /// <summary>
        /// 根据标识获取实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns>Entity</returns>
        T Get(object id);

        /// <summary>
        ///添加实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        void Add(T entity);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        void Change(T entity);

        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        void Remove(T entity);

        /// <summary>
        /// 获取数据表
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// 获取未删除数据
        /// </summary>
        IQueryable<T> TableNoDelete { get; }
        /// <summary>
        /// 获取已删除数据
        /// </summary>
        IQueryable<T> TableDelete { get; }

        /// <summary>
        /// 获取不缓存数据表
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        /// <summary>
        /// 获取未删除数据
        /// </summary>
        IQueryable<T> TableNoTrackingNoDelete { get; }
        /// <summary>
        /// 获取已删除数据
        /// </summary>
        IQueryable<T> TableNoTrackingDelete { get; }
    }
}
