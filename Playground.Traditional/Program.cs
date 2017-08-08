using Autofac;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Teleware.Foundation.Configuration;
using Teleware.Foundation.Hosting;
using Teleware.Foundation.Hosting.Application;
using Teleware.Foundation.Options;

namespace Playground.Traditional
{
    class Program
    {
        static void Main(string[] args)
        {
            var env = new ApplicationEnvironment();
            var bootupConfigurationProvider = new BootupConfigurationProvider(env);

            Autofac.ContainerBuilder cb = new Autofac.ContainerBuilder();
            cb.RegisterInstance<IEnvironment>(env);
            cb.RegisterInstance(bootupConfigurationProvider).As<IBootupConfigurationProvider>();

            cb.RegisterModule<Teleware.Foundation.Core.Module>();
            cb.RegisterModule<Teleware.Foundation.Configuration.Module>();
            cb.RegisterModule<Teleware.Foundation.Diagnostics.Loggers.NLog.Module>();
            cb.RegisterModule<Teleware.Foundation.Data.Memory.Module>();
            //cb.RegisterModule<Teleware.Foundation.Data.EntityFramework.Module>();
            //cb.RegisterModule<Teleware.Foundation.Data.EntityFramework.Oracle.Module>();

            var container = cb.Build();
            using (var lt = container.BeginLifetimeScope())
            {
                while (true)
                {
                    var db = lt.Resolve<IOptions<DatabaseOptions>>();

                    Console.WriteLine(db.Value.ConnectionStrings.First().ToString());
                    Thread.Sleep(1000);
                }
            }

        }
    }
}
