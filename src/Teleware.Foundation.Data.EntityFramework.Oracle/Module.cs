using Autofac;
using Teleware.Data.Impl;
using Teleware.Data;

namespace Teleware.Foundation.Data.EntityFramework.Oracle
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OracleEFContextFactory>().As<IEFContextFactory>().SingleInstance();
        }
    }
}