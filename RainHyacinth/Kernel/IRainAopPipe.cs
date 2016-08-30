namespace RainHyacinth.Kernel
{
    /// <summary>
    /// AOP管道
    /// </summary>
    public interface IRainAopPipe
    {
        /// <summary>
        /// 初始化装载
        /// </summary>
        void InitLoad();
        /// <summary>
        /// 开始请求
        /// </summary>
        /// <param name="workContext"></param>
        void Begin_Request(IRainWorkContext workContext);
        /// <summary>
        /// 结束请求
        /// </summary>
        /// <param name="workContext"></param>
        void End_Request(IRainWorkContext workContext);
    }
}
