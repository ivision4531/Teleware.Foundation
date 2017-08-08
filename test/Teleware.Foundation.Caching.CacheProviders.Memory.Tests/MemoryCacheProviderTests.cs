using Autofac;
using System;
using Teleware.Foundation.Configuration;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Teleware.Foundation.Caching.CacheProviders.Memory.Tests
{
    public class MemoryCacheProviderTests
    {
        [Fact]
        public void MemoryCacheProviderResolveTest()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ConfigurationFactoryStub>().As<IConfigurationFactory>();
            containerBuilder.RegisterModule<Teleware.Foundation.Configuration.Module>();
            containerBuilder.RegisterModule<Teleware.Foundation.Core.Module>();
            containerBuilder.RegisterModule<Teleware.Foundation.Caching.CacheProviders.Memory.Module>();

            var container = containerBuilder.Build();

            using (var lt = container.BeginLifetimeScope())
            {
                var memoryProvider = lt.Resolve<ICacheProvider>();
                var namedMemoryProvider = lt.ResolveNamed<ICacheProvider>(nameof(MemoryCacheProvider));

                Assert.NotNull(memoryProvider);
                Assert.Equal(memoryProvider, namedMemoryProvider);
            }
        }

        private class ConfigurationFactoryStub : IConfigurationFactory
        {
            private readonly IConfigurationRoot _configRoot;

            public ConfigurationFactoryStub(IEnumerable<KeyValuePair<string, string>> initialDatas = null)
            {
                var configBuilder = new ConfigurationBuilder();
                if (initialDatas != null)
                {
                    configBuilder.AddInMemoryCollection(initialDatas);
                }
                _configRoot = configBuilder.Build();
            }

            public IConfigurationRoot GetConfigurationRoot()
            {
                return _configRoot;
            }
        }
    }
}