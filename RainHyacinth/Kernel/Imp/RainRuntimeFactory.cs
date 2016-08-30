using System;

namespace RainHyacinth.Kernel.Imp
{
    /// <summary>
    /// 运行时创建工厂
    /// </summary>
    public sealed class RainRuntimeFactory : IRainRuntimeFactory
    {
        public IRainRuntime CreateRainRuntime(IRainWorkContext workContext)
        {
            return new RainRuntime(workContext);
        }
    }
}
