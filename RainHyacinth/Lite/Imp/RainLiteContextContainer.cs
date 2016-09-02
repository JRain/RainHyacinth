using System;
using System.Collections.Concurrent;
using RainHyacinth.Lite.Configs;

namespace RainHyacinth.Lite.Imp
{
    /// <summary>
    /// RainLiteContext容器
    /// </summary>
    public class RainLiteContextContainer : IRainLiteContextContainer
    {
        private readonly ConcurrentDictionary<string, IRainLiteContext> _containRainLiteContexts;
        private static DbConfigs DbConfigs => LiteConfigService.Instance.DbConfigs;
        public RainLiteContextContainer()
        {
            _containRainLiteContexts = new ConcurrentDictionary<string, IRainLiteContext>();
            if (null != DbConfigs)
            {
                foreach (var config in DbConfigs.Configs)
                {
                    _containRainLiteContexts.TryAdd(config.Key, new RainLiteContext(config.Value.DbConn));
                }
            }
        }
        public IRainLiteContext GetRainLiteContext(string name)
        {
            return _containRainLiteContexts[name];
        }

        public IRainLiteContext GetDefaultContext()
        {
            return GetRainLiteContext("Current");
        }
    }
}
