using System;
using System.Collections.Generic;
using System.Linq;

namespace RainHyacinth.Utils
{
    /// <summary>
    /// 类型工具类
    /// </summary>
    public static class TypeUtil
    {
        /// <summary>
        /// 获取当前程序域所有类型
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> GetCurrentDomaminTypes()
        {
            return AssemblyUtil.GetCurrentDomainAssembly().SelectMany(ass => ass.GetTypes());
        }
        /// <summary>
        /// 获取当前应用程序域所有类【不包括接口】
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> GetCurrentDomaminClassTypes()
        {
            return AssemblyUtil.GetCurrentDomainAssembly().SelectMany(ass => ass.GetTypes().Where(p => p.IsClass));
        }
        /// <summary>
        /// 获取指定接口类型的类【不包括接口】
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> GetCurrentDomaminClassTypesByInterface<T>()
        {
            return AssemblyUtil.GetCurrentDomainAssembly().SelectMany(ass => ass.GetTypes().Where(t => t.IsClass && t.GetInterface(typeof(T).FullName) != null));
        }
        public static IEnumerable<Type> GetCurrentDomaminClassTypesByInterface<T>(IEnumerable<Type> types)
        {
            return types.Where(t => t.IsClass && t.GetInterface(typeof(T).FullName) != null);
        }
        /// <summary>
        /// 获取当前应用程序域所有接口类型
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> GetCurrentDomaminInterfaceypes()
        {
            return AssemblyUtil.GetCurrentDomainAssembly().SelectMany(ass => ass.GetTypes().Where(p => p.IsInterface));
        }

        /// <summary>
        /// 获取指定接口类型的接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> GetCurrentDomaminInterfaceTypesByInterface<T>()
        {
            return AssemblyUtil.GetCurrentDomainAssembly().SelectMany(ass => ass.GetTypes().Where(t => t.IsInterface && t.GetInterface(typeof(T).FullName) != null));
        }
    }
}
