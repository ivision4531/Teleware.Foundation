using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teleware.Foundation.Data;
using Teleware.Foundation.Data.Exceptions;
using Teleware.Foundation.Domain.Entity;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Data.Impl
{
    /// <summary>
    /// 基于内存的工作单元
    /// </summary>
    public class MemoryUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 实体记录
        /// </summary>
        public ICollection<IEntity> Items { get; } = new List<IEntity>();

        /// <summary>
        /// 删除的实体记录
        /// </summary>
        public ICollection<IEntity> RemovedItems { get; } = new List<IEntity>();

        /// <summary>
        /// 领域事件递送着
        /// </summary>
        public DomainEventMessenger Messenger { get; set; }

        /// <inheritdoc/>
        public int Priority
        {
            get { return 100; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="coordinator"></param>
        public MemoryUnitOfWork(IUnitOfWorkCoordinator coordinator)
        {
            coordinator.RegisterUnitOfWork(this);
        }

        private Task DeliverEntityEventsAsync(IEntity entity)
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
            foreach (var item in Items)
            {
                await DeliverEntityEventsAsync(item);
            }
            foreach (var item in RemovedItems)
            {
                await DeliverEntityEventsAsync(item);
            }
            FireCommittedEvent();
            RemovedItems.Clear();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
        }

        /// <inheritdoc/>
        public event UnitOfWorkCommittedDelegate OnCommittedOnce;
    }
}