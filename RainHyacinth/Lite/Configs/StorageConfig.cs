using System.Collections.Generic;

namespace RainHyacinth.Lite.Configs
{
    /// <summary>
    /// 数据库存储上下文配置
    /// </summary>
    public class StorageConfig
    {
        /// <summary>
        /// 存储别名
        /// </summary>
        public string StorageName { get; set; }
        /// <summary>
        /// 数据库
        /// </summary>
        public string InitialCatalog { get; set; }

        /// <summary>
        /// 数据服务器
        /// </summary>
        public string DataSource { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 最小连接数
        /// </summary>
        public int MinimunConnections { get; set; }
        /// <summary>
        /// 最大连接数
        /// </summary>
        public int MaximumConnections { get; set; }
        /// <summary>
        /// 连接超时
        /// </summary>
        public int ConnectionTimeout { get; set; }
        /// <summary>
        /// 连接延迟
        /// </summary>
        public int ConnectionReaperDelay { get; set; }

        /// <summary>
        /// 数据库驱动
        /// </summary>
        public string DbDriver { get; set; }
        /// <summary>
        /// DbcontextOwnsConnection 是false,则释放上下文时将不会释放该连接
        /// </summary>
        public bool DbcontextOwnsConnection { get; set; }
    }

    public class StorageConfigs
    {
        public StorageConfigs()
        {
            StorageConfig = new List<StorageConfig>();
        }
        public List<StorageConfig> StorageConfig { get; set; }
    }
}
