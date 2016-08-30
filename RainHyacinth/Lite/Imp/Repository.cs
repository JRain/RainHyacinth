using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using RainHyacinth.Kernel.Imp;

namespace RainHyacinth.Lite.Imp
{
    /// <summary>
    /// 仓储模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : RainLite
    {
        private readonly IRainLiteContextContainer _contextContainer = KernelManager.Instance.DependencyInjectHub.Resolve<IRainLiteContextContainer>();
        private readonly IRainLiteContext _context;
        private IDbSet<T> _entities;
        private readonly DbContext _efContext;
        /// <summary>
        /// 仓储中心上下文
        /// </summary>
        public IRainLiteContext Context => _context;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Repository()
        {
            _context = _contextContainer.GetRainLiteContext("Current");
            _efContext = (DbContext)_context;
        }
        /// <summary>
        /// 根据标识获取实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns>Entity</returns>
        public T Get(object id)
        {
            return this.Entities.Find(id);
        }

        ///  <summary>
        /// 添加实体
        ///  </summary>
        ///  <param name="entity">数据实体</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity), "add entity is null");
                this.Entities.Add(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) => validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) => $"{current},{Environment.NewLine}【Property: {validationError.PropertyName}, Error:{validationError.ErrorMessage}】"));
                throw new RainHyacinthException(LiteErrorCode.AddEntityError, msg, dbEx);
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        public void Change(T entity)
        {
            if (null == entity)
                return;
            try
            {
                var e = _efContext.ChangeTracker.Entries<T>().Where(p => p.Entity.Id == entity.Id).Select(p => p.Entity).FirstOrDefault();
                if (e == null)
                {
                    this.Entities.Attach(entity);
                    _efContext.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    _efContext.Entry(e).CurrentValues.SetValues(entity);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) => validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) => $"{current},{Environment.NewLine}【Property: {validationError.PropertyName}, Error:{validationError.ErrorMessage}】"));
                throw new RainHyacinthException(LiteErrorCode.ChangeEntityError, msg, dbEx);
            }
        }

        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        public void Remove(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "remove entity is null");
            try
            {
                this.Entities.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) => validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) => $"{current},{Environment.NewLine}【Property: {validationError.PropertyName}, Error:{validationError.ErrorMessage}】"));
                throw new RainHyacinthException(LiteErrorCode.RemoveEntityError, msg, dbEx);
            }
        }

        /// <summary>
        /// 获取数据表
        /// </summary>
        public virtual IQueryable<T> Table => this.Entities;
        /// <summary>
        /// 获取未删除数据
        /// </summary>
        public virtual IQueryable<T> TableNoDelete => Table.Where(p => !p.IsDelete);

        /// <summary>
        /// 获取已删除数据
        /// </summary>
        public virtual IQueryable<T> TableDelete => Table.Where(p => p.IsDelete);

        /// <summary>
        /// 不缓存数据表
        /// </summary>
        public virtual IQueryable<T> TableNoTracking => Table.AsNoTracking();
        /// <summary>
        /// 获取未删除数据
        /// </summary>
        public IQueryable<T> TableNoTrackingNoDelete => TableNoTracking.Where(p => !p.IsDelete);
        /// <summary>
        /// 获取已删除数据
        /// </summary>
        public IQueryable<T> TableNoTrackingDelete => TableNoTracking.Where(p => p.IsDelete);
        /// <summary>
        /// 实体集合
        /// </summary>
        protected virtual IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
