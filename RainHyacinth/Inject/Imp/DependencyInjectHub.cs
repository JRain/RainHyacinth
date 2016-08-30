using System;
using System.Collections.Concurrent;
using Autofac;
using RainHyacinth.Inject.Configs;
using RainHyacinth.Kernel;
using RainHyacinth.Kernel.Imp;
using RainHyacinth.Utils;

namespace RainHyacinth.Inject.Imp
{
    /// <summary>
    /// 端口
    /// </summary>
    public class DependencyInjectHub : IDependencyInjectHub
    {
        private readonly MiniLogger _logger = LoggerUtil.GetMiniLogger("boot");
        private IContainer _dependencyContainer;
        public DependencyInjectHub()
        {
            _injectLifeScope = new ConcurrentDictionary<int, IInjectLifeScope>();
        }
        /// <summary>
        /// 生命周期管理池
        /// </summary>
        readonly ConcurrentDictionary<int, IInjectLifeScope> _injectLifeScope;
        /// <summary>
        /// 初始化注入配置
        /// </summary>
        public void InitLoad()
        {
            try
            {
                var builder = new ContainerBuilder();
                var autofacInjectContainerBuilder = new AutofacInjectContainerBuilder(builder);
                _logger.Write($"【Application Booting】");
                //外部依赖注入注册[读取配置文件]
                foreach (var dependency in DependencyInjectRegisterConfigManager.GetDependencyInjectRegisterConfigContainer().DependencyInjectRegisterConfigs)
                {
                    bool isCreateInstanceSuccess = true;
                    IDependencyInjectRegister instance = null;
                    try
                    {
                        instance = AssemblyUtil.CreateInstance<IDependencyInjectRegister>(dependency.Assembly, dependency.Type);
                    }
                    catch (Exception ex)
                    {
                        isCreateInstanceSuccess = false;
                        _logger.Write($"Load assembly {dependency.Assembly} and create instance {dependency.Type} occur exception!");
                        _logger.Write(ex.ToString());
                    }
                    finally
                    {
                        if (isCreateInstanceSuccess)
                        {
                            _logger.Write($"Load assembly {dependency.Assembly} and create instance {dependency.Type} success!");
                        }
                    }
                    try
                    {
                        instance.Register(autofacInjectContainerBuilder);
                    }
                    catch (Exception ex)
                    {
                        _logger.Write($"Invoke {dependency.Assembly}→{dependency.Type} 's Method 【Register】 Error,{ex}");
                    }
                    //外部依赖注入有顺序要求，所以这边每注册一个就要更新一次
                    builder = (ContainerBuilder)autofacInjectContainerBuilder.Builder;
                }
                _dependencyContainer = builder.Build();              
                _logger.Write($"【Application Boot End】\r\n\r\n");
            }
            catch (Exception ex)
            {
                _logger.Write($"【Application Boot Exception】 {ex}\r\n\r\n");
            }
        }

        public T Resolve<T>()
        {
            return _injectLifeScope[KernelManager.Instance.CurrentContext().GetHashCode()].Resolve<T>();
        }

        public void Begin_Request(IRainWorkContext workContext)
        {
            _injectLifeScope.TryAdd(workContext.GetHashCode(), new InjectLifeScope(_dependencyContainer));
        }

        public void End_Request(IRainWorkContext workContext)
        {
            IInjectLifeScope lifeScope = null;
            _injectLifeScope.TryRemove(workContext.GetHashCode(), out lifeScope);
        }
    }
}
