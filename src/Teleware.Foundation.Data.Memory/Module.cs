using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Data.Impl;
using Teleware.Foundation.Data;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Foundation.Data.Memory
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MemoryUnitOfWork>()
                .As<IUnitOfWork>()
                .OnActivated((handler) =>
                {
                    var messenger = handler.Context.Resolve<DomainEventMessenger>();
                    handler.Instance.Messenger = messenger;
                })
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(MemoryCRUDRepository<,>))
                .As(typeof(ICRUDRepository<,>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(MemoryCRUDRepository<>))
                .As(typeof(ICRUDRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(MemoryRepositoryQuery<>))
                .As(typeof(IRepositoryQuery<>))
                .InstancePerLifetimeScope();
        }
    }
}