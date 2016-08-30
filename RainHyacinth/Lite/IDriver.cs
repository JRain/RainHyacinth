using System.Data.Common;
using RainHyacinth.Lite.Configs;

namespace RainHyacinth.Lite
{
    /// <summary>
    /// 数据库驱动
    /// </summary>
    public interface IDriver
    {
        /// <summary>
        /// 获取连接数据库对象
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        DbConnection GetDbConnection(StorageConfig config);
    }
}
