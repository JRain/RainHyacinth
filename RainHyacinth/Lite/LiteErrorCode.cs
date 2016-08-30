namespace RainHyacinth.Lite
{
    /// <summary>
    /// Lite组件错误码  11xxxxxxxx
    /// </summary>
    public sealed class LiteErrorCode
    {
        /// <summary>
        /// 读取数据库配置文件错误
        /// </summary>
        public static string GetDbConfigError = "1100000001";
        /// <summary>
        /// 添加实体错误
        /// </summary>
        public static string AddEntityError = "1100000002";
        /// <summary>
        /// 改变实体错误
        /// </summary>
        public static string ChangeEntityError = "1100000003";
        /// <summary>
        /// 移除实体错误
        /// </summary>
        public static string RemoveEntityError = "1100000004";
        /// <summary>
        /// 设置ORM实体版本号错误
        /// </summary>
        public static string SetEntityVersionError = "1100000005";
    }
}
