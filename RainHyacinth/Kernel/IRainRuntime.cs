using System;
using RainHyacinth.Core;

namespace RainHyacinth.Kernel
{
    /// <summary>
    /// RainHyacinth框架运行时
    /// </summary>
    public interface IRainRuntime
    {
        /// <summary>
        /// 工作上下文
        /// </summary>
        IRainWorkContext WorkContext { get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateTime { get; }
        /// <summary>
        /// 有效期
        /// </summary>
        TimeSpan ExpireSpan { get; }
        /// <summary>
        /// 过期时间
        /// </summary>
        DateTime ExpireTime { get; }
        /// <summary>
        /// 运行时缓存
        /// </summary>
        ICacheService Cache { get; }
    }
}
