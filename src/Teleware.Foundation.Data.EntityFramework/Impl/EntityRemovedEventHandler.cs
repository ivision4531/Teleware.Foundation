using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Foundation.Data;
using Teleware.Foundation.Domain.Event;
using Teleware.Foundation.Domain.Event.Events;

namespace Teleware.Data.Impl
{
    /// <summary>
    /// 实体删除事件处理器
    /// </summary>
    /// <remarks>
    /// 确保领域事件中认定被删除的实体将要从EF层面删除
    /// </remarks>
    public class EntityRemovedEventHandler : IDomainEventHandler
    {
        private static readonly Type[] _eventTypes = new[] { typeof(EntityRemovedEvent) };

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public EntityRemovedEventHandler(IUnitOfWork unitOfWork)
        {
            EFUnitOfWork = unitOfWork as EFUnitOfWork;
        }

        private EFUnitOfWork EFUnitOfWork { get; set; }

        /// <inheritdoc/>
        public Type[] EventTypes
        {
            get
            {
                return _eventTypes;
            }
        }

        /// <inheritdoc/>
        public Task HandleAsync(IDomainEvent @event)
        {
            var entityToRemove = ((EntityRemovedEvent)@event).Source;
            var entry = EFUnitOfWork.Context.Entry(entityToRemove);
            if (entry.State == EntityState.Modified)
            {
                entry.State = EntityState.Deleted;
            }
            return Task.FromResult(0);
        }
    }
}