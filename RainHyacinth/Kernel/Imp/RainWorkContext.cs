using System;
using System.Threading;

namespace RainHyacinth.Kernel.Imp
{
    /// <summary>
    /// 工作上下文
    /// </summary>
    public sealed class RainWorkContext : IRainWorkContext
    {
        public RainWorkContext(object outsideContext)
        {
            Name = Guid.NewGuid().ToString();
            OutsideContext = outsideContext;
            ThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        public string Name { get; set; }
        public object OutsideContext { get; }

        public int ThreadId { get; }
        public bool IsCurrentWorkContext()
        {
            return ThreadId == Thread.CurrentThread.ManagedThreadId;
        }

        /// <summary>
        /// 默认上下文
        /// </summary>
        /// <returns></returns>
        public static RainWorkContext DefaultWorkContext(object outsideContext)
        {
            return new RainWorkContext(outsideContext)
            {
                Name = Guid.NewGuid().ToString()
            };
        }
    }
}
