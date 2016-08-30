using System;
using System.Collections.Concurrent;
using System.Linq;
using RainHyacinth.Core;
using RainHyacinth.Core.Imp;
using RainHyacinth.Inject;
using RainHyacinth.Inject.Imp;

namespace RainHyacinth.Kernel.Imp
{
    /// <summary>
    /// 内核管理器
    /// </summary>
    public sealed class KernelManager : IKernelManager
    {
        static readonly Lazy<IKernelManager> Lazy = new Lazy<IKernelManager>(() => new KernelManager());
        public static IKernelManager Instance => Lazy.Value;
        /// <summary>
        /// 运行时集合
        /// </summary>
        readonly ConcurrentDictionary<int, IRainRuntime> _rainRuntimes;
        /// <summary>
        /// 运行时创建工厂
        /// </summary>
        readonly IRainRuntimeFactory _rainRuntimeFactory;

        private KernelManager()
        {
            _rainRuntimes = new ConcurrentDictionary<int, IRainRuntime>();
            _rainRuntimeFactory = new RainRuntimeFactory();
            Cache = new CacheService();
            CacheDependency = new CacheDependencyService();
            DistributedCache = new DistributedCacheService();
            DependencyInjectHub = new DependencyInjectHub();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void InitLoad()
        {
            DependencyInjectHub.InitLoad();
        }
        /// <summary>
        /// 请求开始
        /// </summary>
        /// <param name="workContext"></param>
        public void Begin_Request(IRainWorkContext workContext)
        {
            _rainRuntimes.TryAdd(workContext.GetHashCode(), _rainRuntimeFactory.CreateRainRuntime(workContext));
            DependencyInjectHub.Begin_Request(workContext);
        }
        /// <summary>
        /// 请求结束
        /// </summary>
        /// <param name="workContext"></param>
        public void End_Request(IRainWorkContext workContext)
        {
            DependencyInjectHub.End_Request(workContext);
            IRainRuntime runtime = null;
            _rainRuntimes.TryRemove(workContext.GetHashCode(), out runtime);

        }
        /// <summary>
        /// 获取当前运行时
        /// </summary>
        /// <returns></returns>
        public IRainRuntime CurrentRuntime()
        {
            return _rainRuntimes.Values.FirstOrDefault(p => p.WorkContext.IsCurrentWorkContext());
        }
        /// <summary>
        /// 获取当前上下文
        /// </summary>
        /// <returns></returns>
        public IRainWorkContext CurrentContext()
        {
            return CurrentRuntime()?.WorkContext;
        }
        /// <summary>
        /// 本机缓存
        /// </summary>
        public ICacheService Cache { get; }
        /// <summary>
        /// 分布式缓存
        /// </summary>
        public IDistributedCacheService DistributedCache { get; }
        /// <summary>
        /// 缓存依赖
        /// </summary>
        public ICacheDependencyService CacheDependency { get; }

        /// <summary>
        /// IOC依赖注入端口
        /// </summary>
        public IDependencyInjectHub DependencyInjectHub { get; }
    }
}
