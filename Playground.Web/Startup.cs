using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Teleware.Foundation.Hosting;
using Teleware.Foundation.Hosting.AspNetCore;
using Teleware.Foundation.Configuration;
using Teleware.Foundation.AspNetCore.MVC.Filters;
using NLog.Web;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Playground.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            this.Env = new AspNetCoreEnvironment(env);
            this.BootupConfigurationProvider = new BootupConfigurationProvider(Env);
            var nlogConfigFilePath = this.BootupConfigurationProvider.GetNLogConfigFilePath();
            if (nlogConfigFilePath != null)
            {
                env.ConfigureNLog(nlogConfigFilePath);
            }
        }

        public IEnvironment Env { get; private set; }
        public IContainer ApplicationContainer { get; private set; }
        public IBootupConfigurationProvider BootupConfigurationProvider { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(UnitOfWorkCommitFilter));
                options.Filters.Add(typeof(ApiExceptionFilter));

                //options.OutputFormatters.RemoveType<TextOutputFormatter>();
                //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            });

            var autofacConfigs = new Autofac.Configuration.ConfigurationModule(BootupConfigurationProvider.GetAutofacConfiguration());
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(autofacConfigs);
            builder.RegisterInstance(BootupConfigurationProvider).As<IBootupConfigurationProvider>();
            builder.RegisterInstance(Env).As<IEnvironment>();

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            //loggerFactory.AddConsole();
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                loggerFactory.AddDebug();
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.AddNLogWeb();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
}