using RainHyacinth.Kernel;

namespace RainHyacinth.Inject
{
    /// <summary>
    /// 注入服务接口
    /// </summary>
    public interface IInjectService
    {
        /// <summary>
        /// 解析对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();
    }
    /// <summary>
    /// 注入端口
    /// </summary>
    public interface IDependencyInjectHub : IInjectService, IRainAopPipe
    {
      
    }
}
