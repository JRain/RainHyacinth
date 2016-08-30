namespace RainHyacinth.Kernel
{
    /// <summary>
    /// 运行时创建工厂
    /// </summary>
    public interface IRainRuntimeFactory
    {
        /// <summary>
        /// 创建运行时实例
        /// </summary>
        /// <param name="workContext">工作上下文</param>
        /// <returns></returns>
        IRainRuntime CreateRainRuntime(IRainWorkContext workContext);
    }
}
