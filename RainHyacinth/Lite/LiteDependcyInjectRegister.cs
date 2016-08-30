using RainHyacinth.Inject;
using RainHyacinth.Lite.Imp;

namespace RainHyacinth.Lite
{
    /// <summary>
    /// Lite依赖注入器
    /// </summary>
    public class LiteDependcyInjectRegister : IDependencyInjectRegister
    {
        /// <summary>
        /// 配置化处理
        /// </summary>
        public void Register(IInjectContainerBuilder builder)
        {
            builder.RegisterPerLifetimeScope<IRainLiteContextContainer>(() => new RainLiteContextContainer());
            builder.RegisterGenericInstancePerLifetimeScope(typeof(Repository<>), typeof(IRepository<>));
        }
    }
}
