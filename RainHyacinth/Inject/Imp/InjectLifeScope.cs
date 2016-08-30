using Autofac;

namespace RainHyacinth.Inject.Imp
{
    /// <summary>
    /// 依赖注入生命周期
    /// </summary>
    public class InjectLifeScope : IInjectLifeScope
    {
        public InjectLifeScope(object container)
        {
            var container1 = (IContainer)container;
            NonpartyLifeScope = container1.BeginLifetimeScope();
            ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        }

        public object NonpartyLifeScope { get; }
        public int ThreadId { get; }
        public T Resolve<T>()
        {
            return ((ILifetimeScope)NonpartyLifeScope).Resolve<T>();
        }
    }
}
