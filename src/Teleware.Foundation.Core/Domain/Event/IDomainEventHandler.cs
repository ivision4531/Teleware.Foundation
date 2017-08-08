using System;
using System.Threading.Tasks;

namespace Teleware.Foundation.Domain.Event
{
    /// <summary>
    /// 描述一个领域事件处理器
    /// </summary>
    public interface IDomainEventHandler
    {
        /// <summary>
        /// 支持处理的领域事件类型
        /// </summary>
        Type[] EventTypes { get; }

        /// <summary>
        /// 处理领域事件
        /// </summary>
        /// <param name="event">领域事件</param>
        Task HandleAsync(IDomainEvent @event);
    }
}