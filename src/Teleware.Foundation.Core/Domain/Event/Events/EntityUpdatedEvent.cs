using Teleware.Foundation.Domain.Entity;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Foundation.Domain.Event.Events
{
    /// <summary>
    /// 实体更新事件
    /// </summary>
    public class EntityUpdatedEvent : AbstractDomainEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EntityUpdatedEvent(IEntity source) : base(source)
        {
        }
    }
}