namespace RainHyacinth.Inject
{
    /// <summary>
    /// 外部依赖注入注册器
    /// </summary>
    public interface IDependencyInjectRegister
    {
        /// <summary>
        /// 注册方法【建议改成不依赖Autofac,这样项目就不需要对Autofac强引用】
        /// </summary>
        /// <param name="builder"></param>
        void Register(IInjectContainerBuilder builder);
    }
}
