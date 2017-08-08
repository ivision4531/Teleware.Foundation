using Autofac;
using Microsoft.Extensions.Caching.Memory;

namespace Teleware.Foundation.Caching.CacheProviders.Memory
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MemoryCacheProvider>()
                .Named<ICacheProvider>(nameof(MemoryCacheProvider))
                .As<ICacheProvider>()
                .SingleInstance();
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();
        }
    }
}