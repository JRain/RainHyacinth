using System.Collections.Generic;

namespace RainHyacinth.Inject.Configs
{
    /// <summary>
    /// 依赖注入配置文件
    /// </summary>
    public class DependencyInjectRegisterConfig
    {
        public string Assembly { get; set; }
        public string Type { get; set; }
    }
    

    /// <summary>
    /// 依赖注入配置文件容器
    /// </summary>
    public class DependencyInjectRegisterConfigContainer
    {
        public List<DependencyInjectRegisterConfig> DependencyInjectRegisterConfigs = new List<DependencyInjectRegisterConfig>();
    }
}
