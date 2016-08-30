using System.Collections.Concurrent;

namespace RainHyacinth.Lite
{
    /// <summary>
    /// RainLiteContext容器
    /// </summary>
    public interface IRainLiteContextContainer
    {
        /// <summary>
        /// 获取IRainLiteContext上下文
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IRainLiteContext GetRainLiteContext(string name);
    }
}
