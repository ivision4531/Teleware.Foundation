using Teleware.Foundation.Domain.Entity;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Foundation.Domain.Event.Events
{
    /// <summary>
    /// 实体创建事件
    /// </summary>
    public class EntityCreatedEvent : AbstractDomainEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EntityCreatedEvent(IEntity source) : base(source)
        {
        }
    }
}