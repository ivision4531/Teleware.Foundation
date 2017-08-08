using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Data.Impl;
using Teleware.Foundation.Data;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Foundation.Data.EntityFramework
{
    /// <summary>
    ///
    /// </summary>
    public class Module : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFUnitOfWork>()
                .As<IUnitOfWork>()
                .WithParameter("connectionName", "Default")
                .OnActivated((handler) =>
                {
                    var messenger = handler.Context.Resolve<DomainEventMessenger>();
                    handler.Instance.Messenger = messenger;
                })
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EFCRUDRepository<,>))
                .As(typeof(ICRUDRepository<,>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EFCRUDRepository<>))
                .As(typeof(ICRUDRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EFRepositoryQuery<>))
                .As(typeof(IRepositoryQuery<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<EntityRemovedEventHandler>()
                .As<IDomainEventHandler>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<MongoContextFactory>().AsSelf().SingleInstance();
            //builder.RegisterType<MongoUnitOfWork>().Named<IUnitOfWork>("MongoUnitOfWork").OnActivated((handler) =>
            //{
            //    var messenger = handler.Context.Resolve<DomainEventMessenger>();
            //    handler.Instance.Messenger = messenger;
            //}).InstancePerLifetimeScope();
            //builder.RegisterGeneric(typeof(MongoCRUDRepository<,>))
            //    .Named("MongoCRUDRepository", typeof(ICRUDRepository<,>))
            //    .WithParameter((p, ctx) => p.Name == "uow", (p, ctx) => ctx.ResolveNamed<IUnitOfWork>("MongoUnitOfWork"))
            //    .InstancePerLifetimeScope();
        }
    }
}