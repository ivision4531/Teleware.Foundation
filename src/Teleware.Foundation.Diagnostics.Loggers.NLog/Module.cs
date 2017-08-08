using Autofac;
using Teleware.Foundation.Configuration;
using Teleware.Foundation.Diagnostics;
using Teleware.Foundation.Hosting;

namespace Teleware.Foundation.Diagnostics.Loggers.NLog
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(NLogLoggerImpl<>)).As(typeof(ILogger<>)).SingleInstance();
            builder.Register((ctx) => new NLogLoggerFactory(ctx.Resolve<NLogLoggerManager>())).AsSelf().SingleInstance();
            builder.Register((ctx) => new NLogLoggerManager(ctx.Resolve<IBootupConfigurationProvider>(), ctx.Resolve<IEnvironment>())).AsSelf().SingleInstance();
        }
    }
}