using Teleware.Foundation.Domain.Entity;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Foundation.Domain.Event.Events
{
    /// <summary>
    /// 实体移除事件
    /// </summary>
    public class EntityRemovedEvent : AbstractDomainEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EntityRemovedEvent(IEntity source) : base(source)
        {
        }
    }
}