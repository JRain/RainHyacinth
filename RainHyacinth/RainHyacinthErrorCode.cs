namespace RainHyacinth
{
    /// <summary>
    /// 框架错误码  1xxxxxxxxx
    /// </summary>
    public sealed class RainHyacinthErrorCode
    {
        /// <summary>
        /// XML反序列化异常
        /// </summary>
        public static string XmlDeserializeError = "1000000001";
        /// <summary>
        /// XML序列化异常
        /// </summary>
        public static string XmlSerrializeError = "1000000001";
        /// <summary>
        /// 读取文件异常
        /// </summary>
        public static string ReadFileTextError = "1000000002";
    }

    /// <summary>
    /// 业务性错误码 
    /// </summary>
    public sealed class RainHyacinthBusinessErrorCode
    {
        /// <summary>
        /// 未登录
        /// </summary>
        public static string NotLogin = "400000";
    }
}
