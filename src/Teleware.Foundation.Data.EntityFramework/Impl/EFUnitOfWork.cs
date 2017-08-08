using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Teleware.Foundation.Data;
using Teleware.Foundation.Data.Exceptions;
using Teleware.Foundation.Domain.Entity;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Data.Impl
{
    /// <summary>
    /// 基于EF的工作单元
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly IEFContextFactory _factory;
        private readonly string _connectionName;

        /// <summary>
        /// 领域事件递送着
        /// </summary>
        public DomainEventMessenger Messenger { get; set; }

        /// <summary>
        /// EF上下文
        /// </summary>
        public DbContext Context
        {
            get;
            protected set;
        }

        /// <inheritdoc/>
        public int Priority
        {
            get { return 100; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="connectionName"></param>
        /// <param name="coordinator"></param>
        public EFUnitOfWork(IEFContextFactory factory, string connectionName, IUnitOfWorkCoordinator coordinator)
        {
            _factory = factory;
            _connectionName = connectionName;
            Context = factory.CreateContext(connectionName);
            coordinator.RegisterUnitOfWork(this);
            //Context.OnEntityValidated += DeliverEntityEvents;
        }

        private Task DeliverEntityEventsAsync(Foundation.Domain.Entity.IEntity entity)
        {
            var rootEntity = entity as IAggregateRoot;
            if (rootEntity != null)
            {
                return rootEntity.GetEventPostBox().DeliverAllAsync(Messenger);
            }
            else
            {
                return Task.FromResult(0);
            }
        }

        /// <inheritdoc/>
        public void Commit()
        {
            CommitAsync().Wait();
        }

        private void FireCommittedEvent()
        {
            if (OnCommittedOnce != null)
            {
                OnCommittedOnce(this, EventArgs.Empty);
                OnCommittedOnce = null;
            }
        }

        /// <inheritdoc/>
        public async Task CommitAsync()
        {
            try
            {
                // 在发送之前，执行所有实体中的领域事件
                var entries = (Context as IObjectContextAdapter).ObjectContext
                    .ObjectStateManager
                    .GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged);
                foreach (var entry in entries)
                {
                    await DeliverEntityEventsAsync(entry.Entity as IEntity);
                }
                await Context.SaveChangesAsync();
                FireCommittedEvent();
            }
            catch (DBConcurrencyException concurrencyException)
            {
                throw new OptimisticConcurrencyException(concurrencyException.Message, concurrencyException);
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public event UnitOfWorkCommittedDelegate OnCommittedOnce;
    }
}