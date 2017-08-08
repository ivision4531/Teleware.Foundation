using System;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Foundation.Domain.Entity
{
    /// <summary>
    /// 聚合根基类
    /// </summary>
    public abstract class AbstractRootEntity : IAggregateRoot<string>
    {
        private readonly DomainEventPostBox _eventPostBox;

        /// <summary>
        /// 构造函数
        /// </summary>
        protected AbstractRootEntity()
        {
            Id = Guid.NewGuid().ToString();
            _eventPostBox = new DomainEventPostBox();
        }

        /// <inheritdoc/>
        public string Id { get; set; }

        /// <inheritdoc/>
        public DomainEventPostBox GetEventPostBox()
        {
            return _eventPostBox;
        }

        /// <inheritdoc/>
        object IEntity.GetId()
        {
            return Id;
        }
    }
}