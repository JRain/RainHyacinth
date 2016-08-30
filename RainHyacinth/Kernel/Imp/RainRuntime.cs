using System;
using RainHyacinth.Core;
using RainHyacinth.Core.Imp;

namespace RainHyacinth.Kernel.Imp
{
    /// <summary>
    /// 运行时抽象类
    /// </summary>
    public abstract class AbsRainRuntime : IRainRuntime
    {
        protected AbsRainRuntime(IRainWorkContext workContext)
        {
            WorkContext = workContext;
            CreateTime = DateTime.Now;//只读，在构造函数初始化的时候才赋值
            ExpireSpan = TimeSpan.FromSeconds(KernelConfig.Config.RainRuntimeCacheTime);
            Cache = new CacheService();
        }

        public DateTime CreateTime { get; }

        public TimeSpan ExpireSpan { get; }

        public DateTime ExpireTime => CreateTime + ExpireSpan;
        public ICacheService Cache { get; }

        public IRainWorkContext WorkContext { get; }
    }

    public class RainRuntime : AbsRainRuntime
    {
        public RainRuntime(IRainWorkContext workContext) : base(workContext)
        {
        }
    }
}
