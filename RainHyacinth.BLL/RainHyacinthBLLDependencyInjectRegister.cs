using System;
using System.Reflection;
using RainHyacinth.Inject;
namespace RainHyacinth.BLL
{
    /// <summary>
    /// 业务组件依赖注入器
    /// </summary>
    public class RainHyacinthBllDependencyInjectRegister : IDependencyInjectRegister
    {
        public void Register(IInjectContainerBuilder builder)
        {
            DependencyInjectRegisterUtil.RegisterIDependencyInject(Assembly.Load("RainHyacinth.BLL"), builder);
        }
    }
}
