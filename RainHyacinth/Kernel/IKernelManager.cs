using RainHyacinth.Core;
using RainHyacinth.Inject;

namespace RainHyacinth.Kernel
{
    /// <summary>
    /// 内核管理器接口
    /// </summary>
    public interface IKernelManager : IRainAopPipe
    {
        /// <summary>
        /// 当前运行时
        /// </summary>
        /// <returns></returns>
        IRainRuntime CurrentRuntime();

        /// <summary>
        /// 当前上下文
        /// </summary>
        /// <returns></returns>
        IRainWorkContext CurrentContext();
        /// <summary>
        /// 本机缓存
        /// </summary>
        ICacheService Cache { get; }
        /// <summary>
        /// 本机缓存依赖
        /// </summary>
        ICacheDependencyService CacheDependency { get; }

        /// <summary>
        /// 分布式缓存
        /// </summary>
        IDistributedCacheService DistributedCache { get; }
        /// <summary>
        /// 依赖注入器
        /// </summary>
        IDependencyInjectHub DependencyInjectHub { get; }
    }
}
