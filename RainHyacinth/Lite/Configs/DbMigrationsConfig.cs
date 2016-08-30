namespace RainHyacinth.Lite.Configs
{
    /// <summary>
    /// 自动迁移配置
    /// </summary>
    public class DbMigrationsConfig
    {
        /// <summary>
        /// 自动迁移
        /// </summary>
        public bool AutomaticMigrationsEnabled { get; set; }
        /// <summary>
        /// 自动迁移默认情况下不扔掉列在我们的数据库中的表。如果我们不希望这样的行为，我们可以告诉迁移明确允许数据丢失的配置类的.AutomaticMigrationDataLossAllowed属性设置为true。
        /// </summary>
        public bool AutomaticMigrationDataLossAllowed { get; set; }

        /// <summary>
        /// 当StartAutoMigrations为false时，自动迁移无效
        /// </summary>
        public bool StartAutoMigrations { get; set; }
    }
}
