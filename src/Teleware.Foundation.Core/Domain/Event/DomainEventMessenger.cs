using System;
using System.Linq;
using System.Threading.Tasks;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Foundation.Domain.Event
{
    /// <summary>
    /// 领域事件递送者
    /// </summary>
    public class DomainEventMessenger
    {
        private readonly ILookup<Type, IDomainEventHandler> _handlers;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="handlers"></param>
        public DomainEventMessenger(IDomainEventHandler[] handlers)
        {
            _handlers = handlers
                .SelectMany(h => h.EventTypes.Select(e => Tuple.Create(e, h)))
                .ToLookup(t => t.Item1, t => t.Item2);
        }

        /// <summary>
        /// 递送领域事件到处理程序
        /// </summary>
        /// <param name="event">领域事件</param>
        public async Task DeliverAsync(IDomainEvent @event)
        {
            foreach (var handler in _handlers[@event.GetType()])
            {
                await handler.HandleAsync(@event);
            }
        }
    }
}