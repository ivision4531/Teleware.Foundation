using System;
using System.Collections.Generic;
using System.Text;
using Teleware.Foundation.Hosting;
using Xunit;

namespace Teleware.Foundation.Core.Tests.Host
{
    public class EnvironmentExtensionsTest
    {
        [Fact]
        public void IsEnvironmentTest()
        {
            var envName = "UNIT_TEST";
            var env = new EnvironmentStub(envName);

            var isEnvResult = env.IsEnvironment(envName);

            Assert.True(isEnvResult);
        }
    }

    internal class EnvironmentStub : IEnvironment
    {
        public EnvironmentStub(string envName)
        {
            EnvironmentName = envName;
        }

        public string EnvironmentName { get; }

        public string ContentRootPath => throw new NotImplementedException();
    }
}