using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace Teleware.Foundation.Configuration.Extensions
{
    /// <summary>
    /// <see cref="Microsoft.Extensions.Options"/>的Autofac扩展
    /// </summary>
    public static class OptionsAutofacExtensions
    {
        /// <summary>
        /// 增加<see cref="Options"/>配置支持
        /// </summary>
        /// <param name="services"></param>
        /// <remarks>与 Microsoft.Extensions.Options/OptionsServiceCollectionExtensions.cs 同步</remarks>
        public static void AddOptions(this ContainerBuilder services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.RegisterGeneric(typeof(OptionsManager<>)).As(typeof(IOptions<>)).SingleInstance();
            services.RegisterGeneric(typeof(OptionsMonitor<>)).As(typeof(IOptionsMonitor<>)).SingleInstance();
            services.RegisterGeneric(typeof(OptionsSnapshot<>)).As(typeof(IOptionsSnapshot<>)).InstancePerLifetimeScope();
        }

        /// <summary>
        /// 注册配置
        /// </summary>
        /// <typeparam name="TOptions"></typeparam>
        /// <param name="services"></param>
        /// <remarks>
        /// 默认获取<typeparamref name="TOptions"/>类型名(省略Options结尾)配置节点
        /// 与 Microsoft.Extensions.Options.ConfigurationExtensions/OptionsConfigurationServiceCollectionExtensions.cs 同步
        /// </remarks>
        public static void ConfigureOptions<TOptions>(this ContainerBuilder services)
            where TOptions : class
        {
            ConfigureOptions<TOptions>(services, GetDefaultName<TOptions>());
        }

        /// <summary>
        /// 注册配置
        /// </summary>
        /// <typeparam name="TOptions"></typeparam>
        /// <param name="services"></param>
        /// <param name="configSection">配置节点名</param>
        /// <remarks>
        /// 与 Microsoft.Extensions.Options.ConfigurationExtensions/OptionsConfigurationServiceCollectionExtensions.cs 同步
        /// </remarks>
        public static void ConfigureOptions<TOptions>(this ContainerBuilder services, string configSection)
            where TOptions : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.Register((cfg) => new ConfigureFromConfigurationOptions<TOptions>(cfg.Resolve<IConfigurationFactory>().GetConfigurationRoot().GetSection(configSection)))
                .As<IConfigureOptions<TOptions>>().SingleInstance();
            services.Register((cfg) => new ConfigurationChangeTokenSource<TOptions>(cfg.Resolve<IConfigurationFactory>().GetConfigurationRoot().GetSection(configSection)))
                .As<IOptionsChangeTokenSource<TOptions>>().SingleInstance();
        }

        private static string GetDefaultName<TOptions>()
        {
            var typeName = typeof(TOptions).Name;
            if (typeName.EndsWith("Options"))
            {
                typeName = typeName.Substring(0, typeName.Length - "Options".Length);
            }
            return typeName;
        }
    }
}