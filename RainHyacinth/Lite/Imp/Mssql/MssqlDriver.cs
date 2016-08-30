using System.Data.Common;
using System.Data.SqlClient;
using RainHyacinth.Encrypt.Imp;
using RainHyacinth.Lite.Configs;

namespace RainHyacinth.Lite.Imp.Mssql
{
    /// <summary>
    /// 数据库驱动
    /// </summary>
    public class MssqlDriver : IDriver
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public DbConnection GetDbConnection(StorageConfig config)
        {
            return new SqlConnection
            {
                ConnectionString = $"Data Source={config.DataSource}; Initial Catalog={config.InitialCatalog}; User ID={config.UserId}; Password={DesEncryptService.Instance.Decrypt(config.Password, "0845d1a5")}; MultipleActiveResultSets=True"
            };
        }
    }
}
