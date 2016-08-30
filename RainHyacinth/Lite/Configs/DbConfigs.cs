using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using RainHyacinth.Utils;

namespace RainHyacinth.Lite.Configs
{
    /// <summary>
    /// 数据库连接配置
    /// </summary>
    public class DbConfigs
    {
        public DbConfigs(string storageXmlConfigs)
        {
            var storageconfigs = XmlUtils.XmlDeserialize<StorageConfigs>(storageXmlConfigs);
            Configs = new ConcurrentDictionary<string, DbConfig>();
            if (storageconfigs.StorageConfig.Any())
                foreach (var config in storageconfigs.StorageConfig)
                    Configs.Add(config.StorageName, GetDbConfig(config));
        }

        public DbConfig GetDbConfig(StorageConfig config)
        {
            var driver = config.DbDriver.Split(',');
            var driverType = AssemblyUtil.CreateInstance<IDriver>(driver[0], driver[1]);
            return new DbConfig
            {
                DbConfigName = config.StorageName,
                DbConn = driverType.GetDbConnection(config),
                DbCompiledModel = null
            };
        }

        public IDictionary<string, DbConfig> Configs { get; }

        public DbConfig GetDbConfig(string dbConfigName)
        {
            if (!Configs.Any()) throw new RainHyacinthException(LiteErrorCode.GetDbConfigError, "未找到StorageConfigs配置信息");
            return Configs[string.IsNullOrWhiteSpace(dbConfigName) ? "Current" : dbConfigName];
        }
    }
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DbConfig
    {
        /// <summary>
        /// 连接配置名称【多数据库连接时有用】
        /// </summary>
        public string DbConfigName { get; set; }
        /// <summary>
        /// 数据库连接
        /// </summary>
        public DbConnection DbConn { get; set; }
        /// <summary>
        /// 数据库约定(多数据支持)
        /// </summary>
        public object DbCompiledModel { get; set; }
        /// <summary>
        /// DbcontextOwnsConnection 是false,则释放上下文时将不会释放该连接
        /// </summary>
        public bool DbcontextOwnsConnection { get; set; }
    }
}
