using System.IO;
using Teleware.Foundation.Configuration;
using Teleware.Foundation.Hosting;
using NLogSelf = NLog;

namespace Teleware.Foundation.Diagnostics.Loggers.NLog
{
    internal class NLogLoggerManager
    {
        private static bool _initialized = false;

        public NLogLoggerManager(IBootupConfigurationProvider bootupConfigurationProvider, IEnvironment env)
        {
            if (_initialized == false)
            {
                lock (typeof(NLogLoggerManager))
                {
                    if (_initialized != false)
                    {
                        return;
                    }
                    var configurationFilePath = bootupConfigurationProvider.GetNLogConfigFilePath();
                    if (configurationFilePath != null)
                    {
                        configurationFilePath = Path.Combine(env.ContentRootPath, configurationFilePath);
                        if (System.IO.File.Exists(configurationFilePath))
                        {
                            var config = new NLogSelf.Config.XmlLoggingConfiguration(configurationFilePath, false);
                            NLogSelf.LogManager.Configuration = config;
                        }
                    }
                    _initialized = true;
                }
            }
        }

        public NLogSelf.ILogger GetLogger(string name)
        {
            return NLogSelf.LogManager.GetLogger(name);
        }
    }
}