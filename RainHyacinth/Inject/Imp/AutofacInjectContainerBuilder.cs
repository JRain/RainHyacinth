using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace RainHyacinth.Inject.Imp
{
    /// <summary>
    /// Autofac注入容器适配器
    /// </summary>
    public class AutofacInjectContainerBuilder : IInjectContainerBuilder
    {
        private readonly ContainerBuilder _builder;
        public AutofacInjectContainerBuilder(object autofacContainerBuilder)
        {
            _builder = (ContainerBuilder)autofacContainerBuilder;
        }

        public object Builder => _builder;

        public void RegisterGenericInstancePerLifetimeScope(Type typeGenericClass, Type typeGennericInterface)
        {
            _builder.RegisterGeneric(typeGenericClass).As(typeGennericInterface).InstancePerLifetimeScope();
        }

        public void RegisterPerLifetimeScope<TInterfaceType>(TInterfaceType instance)
        {
            _builder.Register<TInterfaceType>(c => instance).InstancePerLifetimeScope();
        }

        public void RegisterPerLifetimeScope<TInterfaceType>(Func<TInterfaceType> instance)
        {
            _builder.Register<TInterfaceType>(c => instance()).InstancePerLifetimeScope();
        }

        public void RegisterInstanceSingle<T, TInterfaceType>(T instance) where T : class
        {
            _builder.RegisterInstance(instance).As<TInterfaceType>().SingleInstance();
        }

        public void RegisterInstanceTransient<T, TInterfaceType>(T instance) where T : class
        {
            _builder.RegisterInstance(instance).As<TInterfaceType>().InstancePerRequest();
        }

        public void RegisterSingle(params Type[] types)
        {
            _builder.RegisterTypes(types).AsImplementedInterfaces().SingleInstance();
        }
        public void RegisterSingle(IEnumerable<Type> types)
        {
            var enumerable = types as Type[] ?? types.ToArray();
            if (enumerable.Any())
            {
                RegisterSingle(enumerable);
            }
        }
        public void RegisterPerDependency(params Type[] types)
        {
            _builder.RegisterTypes(types).AsImplementedInterfaces().InstancePerDependency();
        }
        public void RegisterPerDependency(IEnumerable<Type> types)
        {
            var enumerable = types as Type[] ?? types.ToArray();
            if (enumerable.Any())
            {
                RegisterPerDependency(enumerable);
            }
        }
        public void RegisterPerLifetimeScope(params Type[] types)
        {
            _builder.RegisterTypes(types).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
        public void RegisterPerLifetimeScope(IEnumerable<Type> types)
        {
            var enumerable = types as Type[] ?? types.ToArray();
            if (enumerable.Any())
            {
                RegisterPerLifetimeScope(enumerable);
            }
        }
    }
}
