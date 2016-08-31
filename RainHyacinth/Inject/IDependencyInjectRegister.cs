using System.Linq;
using System.Reflection;

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
    /// <summary>
    /// 外部依赖注入注册器工具类
    /// </summary>
    public class DependencyInjectRegisterUtil
    {
        /// <summary>
        /// 依赖注入注册
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="builder"></param>
        public static void RegisterIDependencyInject(Assembly assembly, IInjectContainerBuilder builder)
        {
            builder.RegisterSingle(assembly.GetTypes().Where(t => typeof(ISingleDependencyInject).IsAssignableFrom(t) && typeof(ISingleDependencyInject) != t));
            builder.RegisterPerDependency(assembly.GetTypes().Where(t => typeof(ITransientDependencyInject).IsAssignableFrom(t) && typeof(ITransientDependencyInject) != t));
            builder.RegisterPerLifetimeScope(assembly.GetTypes().Where(t => typeof(IUintOfWorkDependencyInject).IsAssignableFrom(t) && typeof(IUintOfWorkDependencyInject) != t));
        }
    }
}
