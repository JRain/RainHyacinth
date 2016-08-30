using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using RainHyacinth.Utils;

namespace RainHyacinth.Lite.Imp
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class RainLiteContext : DbContext, IRainLiteContext
    {
        private static readonly MiniLogger Logger = LoggerUtil.GetMiniLogger("RainLiteContext");

        public RainLiteContext(DbConnection conn) : base(conn, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //重写映射关系
            var types = TypeUtil.GetCurrentDomaminClassTypesByInterface<IRainLiteMap>().ToArray();
            if (!types.Any())
            {
                Logger.Write("未找到接口IRainLiteMap的实现类");
                return;
            }
            foreach (var t in types)
            {
                try
                {
                    dynamic configurationInstance = Activator.CreateInstance(t);
                    modelBuilder.Configurations.Add(configurationInstance);
                }
                catch (Exception ex)
                {
                    Logger.Write(ex);
                }
            }
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// 添加实体到数据库上下文
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : RainLite
        {
            var alreadyAttached = base.Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
            if (alreadyAttached == null)
            {
                base.Set<TEntity>().Attach(entity);
                return entity;
            }
            else
            {
                return alreadyAttached;
            }
        }

        /// <summary>
        ///获取建库脚本
        /// </summary>
        /// <returns>生成的建库SQL</returns>
        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : CommonLite
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <typeparam name="TEntity">数据表映射类型</typeparam>
        /// <param name="commandText">存储过程</param>
        /// <param name="parameters">参数</param>
        /// <returns>实体集合</returns>
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : RainLite
        {
            //add parameters to command
            if (parameters != null && parameters.Length > 0)
            {
                for (var i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if (p == null)
                        throw new Exception("Not support parameter type");
                    commandText += i == 0 ? " " : ", ";
                    commandText += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        commandText += " output";
                    }
                }
            }
            var result = Database.SqlQuery<TEntity>(commandText, parameters).ToList();
            bool acd = Configuration.AutoDetectChangesEnabled;
            try
            {
                Configuration.AutoDetectChangesEnabled = false;
                for (int i = 0; i < result.Count; i++)
                    result[i] = AttachEntityToContext(result[i]);
            }
            finally
            {
                Configuration.AutoDetectChangesEnabled = acd;
            }
            return result;
        }
        /// <summary>
        ///Sql查询返回指定类型集合
        /// </summary>
        /// <typeparam name="TElement">结果存储类型</typeparam>
        /// <param name="sql">查询SQL命令.</param>
        /// <param name="parameters">Sql参数</param>
        /// <returns>结果集</returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return Database.SqlQuery<TElement>(sql, parameters);
        }

        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="sql">sql命令</param>
        /// <param name="doNotEnsureTransaction">false - 不支持事务; true -支持事务.</param>
        /// <param name="timeout">超时时间 x/s</param>
        /// <param name="parameters">sql参数.</param>
        /// <returns>执行结果值.</returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }

            var transactionalBehavior = doNotEnsureTransaction
                ? TransactionalBehavior.DoNotEnsureTransaction
                : TransactionalBehavior.EnsureTransaction;
            var result = this.Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);
            if (timeout.HasValue)
            {
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
            }
            return result;
        }
    }
}
