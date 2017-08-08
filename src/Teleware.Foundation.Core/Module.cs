using Autofac;
using Teleware.Foundation.Util.ObjectConverters;
using Teleware.Foundation.Data;
using Teleware.Foundation.Data.Impl;
using Teleware.Foundation.Domain;
using Teleware.Foundation.Domain.Event;
using Teleware.Foundation.Domain.Impl;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Teleware.Foundation.Core.Tests")]

namespace Teleware.Foundation.Core
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventMessenger>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UnitOFWorkCoordinator>().As<IUnitOfWorkCoordinator>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GuidIdGenerator<>)).As(typeof(IIdGenerator<>)).SingleInstance();
            builder.RegisterType<ObjectConverter>().AsSelf().InstancePerLifetimeScope();
        }
    }
}