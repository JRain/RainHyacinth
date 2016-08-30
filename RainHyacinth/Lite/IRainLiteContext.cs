using System.Collections.Generic;
using System.Data.Entity;
using RainHyacinth.Lite.Imp;

namespace RainHyacinth.Lite
{
    public interface IRainLiteContext
    {
        /// <summary>
        /// 获取指定类型数据表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <returns>类型数据表</returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : CommonLite;

        /// <summary>
        /// 保存变更数据
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <typeparam name="TEntity">数据表映射类型</typeparam>
        /// <param name="commandText">存储过程</param>
        /// <param name="parameters">参数</param>
        /// <returns>实体集合</returns>
        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : RainLite;

        /// <summary>
        ///Sql查询返回指定类型集合
        /// </summary>
        /// <typeparam name="TElement">结果存储类型</typeparam>
        /// <param name="sql">查询SQL命令.</param>
        /// <param name="parameters">Sql参数</param>
        /// <returns>结果集</returns>
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="sql">sql命令</param>
        /// <param name="doNotEnsureTransaction">false - 不支持事务; true -支持事务.</param>
        /// <param name="timeout">超时时间 x/s</param>
        /// <param name="parameters">sql参数.</param>
        /// <returns>执行结果值.</returns>
        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);
    }
}
