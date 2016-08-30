using RainHyacinth.Utils;

namespace RainHyacinth.Lite.Configs
{
    /// <summary>
    /// 框架配置服务
    /// </summary>
    public class LiteConfigService
    {
        private LiteConfigService()
        {
        }

        public static LiteConfigService Instance => new LiteConfigService();
        /// <summary>
        /// 数据迁移配置
        /// </summary>
        public DbMigrationsConfig DbMigrationsConfig => XmlUtils.XmlDeserialize<DbMigrationsConfig>(FileUtil.ReadFileText("/configs/dbMigrationsConfig.config"));
        /// <summary>
        /// 数据库连接配置
        /// </summary>
        public DbConfigs DbConfigs => new DbConfigs(FileUtil.ReadFileText("/configs/StorageConfigs.config"));
    }
}
