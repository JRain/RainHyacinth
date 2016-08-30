using RainHyacinth.Utils;

namespace RainHyacinth.Kernel
{
    /// <summary>
    /// 内核配置文件
    /// </summary>
    public class KernelConfig
    {
        /// <summary>
        /// 运行时缓存时间（单位：秒）
        /// </summary>
        public int RainRuntimeCacheTime { get; set; }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        public static KernelConfig Config => XmlUtils.XmlDeserialize<KernelConfig>(FileUtil.ReadFileText(@"\configs\Kernel.Config"));
    }
}
