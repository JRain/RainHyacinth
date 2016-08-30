using System.Text;
using RainHyacinth.Utils;

namespace RainHyacinth.Inject.Configs
{
    /// <summary>
    /// 依赖注入配置管理器
    /// </summary>
    public class DependencyInjectRegisterConfigManager
    {
        public static DependencyInjectRegisterConfigContainer GetDependencyInjectRegisterConfigContainer()
        {
            if (!DirectoryUtil.IsExistPath("/configs"))
                return new DependencyInjectRegisterConfigContainer();
            var dependencyInjectContent = FileUtil.ReadFileText("/configs/DependencyInject.config", Encoding.UTF8);
            return XmlUtils.XmlDeserialize<DependencyInjectRegisterConfigContainer>(dependencyInjectContent);
        }
    }
}
