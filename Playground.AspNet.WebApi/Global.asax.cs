using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Teleware.Data;
using Teleware.Foundation.AspNet.WebApi.Filters;
using Teleware.Foundation.Configuration;
using Teleware.Foundation.Domain.Entity;
using Teleware.Foundation.Hosting;

namespace Playground.AspNet.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var env = new Teleware.Foundation.Hosting.Application.ApplicationEnvironment();
            var bootupConfigurationProvider = new BootupConfigurationProvider(env);
            var configModule = new Autofac.Configuration.ConfigurationModule(bootupConfigurationProvider.GetAutofacConfiguration());

            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();
            builder.RegisterInstance(env).As<IEnvironment>();
            builder.RegisterInstance(bootupConfigurationProvider).As<IBootupConfigurationProvider>();
            builder.RegisterModule(configModule);

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<ApiExceptionFilter>().AsWebApiExceptionFilterFor<ApiController>().InstancePerRequest();
            builder.RegisterType<UnitOfWorkCommitFilter>().AsWebApiActionFilterFor<ApiController>().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }

    public class TestEntity : AbstractRootEntity
    {
    }

    public class TestEntityMapping : EntityTypeConfiguration<TestEntity>, IDbObjConfiguration
    {
        public TestEntityMapping()
        {
            this.ToTable("TEST");
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasColumnName("ID");
        }
    }
}