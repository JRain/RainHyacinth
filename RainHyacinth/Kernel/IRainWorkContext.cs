namespace RainHyacinth.Kernel
{
    /// <summary>
    /// RainHyacinth框架上下文
    /// </summary>
    public interface IRainWorkContext
    {
        /// <summary>
        /// 名称-上下文唯一标识
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 外部上下文
        /// </summary>
        object OutsideContext { get; }
        /// <summary>
        /// 线程Id
        /// </summary>
        int ThreadId { get; }

        /// <summary>
        /// 是否是当前上下文对象
        /// </summary>
        bool IsCurrentWorkContext();
    }
}
