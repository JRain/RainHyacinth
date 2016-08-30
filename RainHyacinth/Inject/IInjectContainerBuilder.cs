using System;
using System.Collections.Generic;

namespace RainHyacinth.Inject
{
    /// <summary>
    /// 注入容器约定
    /// </summary>
    public interface IInjectContainerBuilder
    {
        /// <summary>
        /// 构造器
        /// </summary>
        object Builder { get; }
        /// <summary>
        /// 注册单例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TInterfaceType"></typeparam>
        /// <param name="instance"></param>
        void RegisterInstanceSingle<T, TInterfaceType>(T instance) where T : class;

        /// <summary>
        /// 注册生命周期
        /// </summary>
        /// <typeparam name="TInterfaceType"></typeparam>
        /// <param name="instance"></param>
        void RegisterPerLifetimeScope<TInterfaceType>(TInterfaceType instance);
        /// <summary>
        /// 注册生命周期
        /// </summary>
        /// <typeparam name="TInterfaceType"></typeparam>
        /// <param name="instance"></param>
        void RegisterPerLifetimeScope<TInterfaceType>(Func<TInterfaceType> instance);

        /// <summary>
        /// 注册泛型
        /// </summary>
        /// <param name="typeGenericClass"></param>
        /// <param name="typeGennericInterface"></param>
        void RegisterGenericInstancePerLifetimeScope(Type typeGenericClass, Type typeGennericInterface);
        /// <summary>
        /// 注册瞬态实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TInterfaceType"></typeparam>
        /// <param name="instance"></param>
        void RegisterInstanceTransient<T, TInterfaceType>(T instance) where T : class;
        /// <summary>
        /// 注册单例
        /// </summary>
        /// <param name="types"></param>
        void RegisterSingle(params Type[] types);
        /// <summary>
        /// 注册单例
        /// </summary>
        /// <param name="types"></param>
        void RegisterSingle(IEnumerable<Type> types);
        /// <summary>
        /// 注册瞬态
        /// </summary>
        /// <param name="types"></param>
        void RegisterPerDependency(params Type[] types);
        /// <summary>
        /// 注册瞬态
        /// </summary>
        /// <param name="types"></param>
        void RegisterPerDependency(IEnumerable<Type> types);
        /// <summary>
        /// 注册每个请求生命周期
        /// </summary>
        /// <param name="types"></param>
        void RegisterPerLifetimeScope(params Type[] types);
        /// <summary>
        /// 注册每个请求生命周期
        /// </summary>
        /// <param name="types"></param>
        void RegisterPerLifetimeScope(IEnumerable<Type> types);
    }
}
