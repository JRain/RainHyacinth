namespace RainHyacinth.Inject
{
    /// <summary>
    /// 依赖注入接口
    /// </summary>
    public interface IDependencyInject
    {
    }
    /// <summary>
    /// 单例依赖注入接口
    /// </summary>
    public interface ISingleDependencyInject : IDependencyInject
    {
    }
    /// <summary>
    /// 工作单元注入依赖（在一个生命周期内都是同一个资源）
    /// </summary>
    public interface IUintOfWorkDependencyInject : IDependencyInject
    {
    }
    /// <summary>
    /// 瞬态依赖【每次调用都new一个实例】
    /// </summary>
    public interface ITransientDependencyInject : IDependencyInject
    {
    }
}
