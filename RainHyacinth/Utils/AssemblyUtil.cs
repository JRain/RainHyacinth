using System;
using System.Linq;
using System.Reflection;

namespace RainHyacinth.Utils
{
    /// <summary>
    /// 反射工具类
    /// </summary>
    public static class AssemblyUtil
    {
        /// <summary>
        /// 获取当前程序域引用程序集
        /// </summary>
        /// <returns></returns>
        public static Assembly[] GetCurrentDomainAssembly()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        public static Assembly GetAssembly(string assebbly)
        {
            return Assembly.Load(assebbly);
        }

        /// <summary>
        /// 创建无参实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(string assembly, string typeName)
        {
            var type = Assembly.Load(assembly).GetTypes().FirstOrDefault(p => p.FullName == typeName);
            if (type != null)
            {
                var instance = (T)Activator.CreateInstance(type);
                return instance;
            }
            return default(T);
        }
        /// <summary>
        /// 创建有参实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly"></param>
        /// <param name="typeName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(string assembly, string typeName, params object[] args)
        {
            var type = Assembly.Load(assembly).GetTypes().FirstOrDefault(p => p.FullName == typeName);
            if (type != null)
            {
                var instance = (T)Activator.CreateInstance(type, args);
                return instance;
            }
            return default(T);
        }
    }
}
