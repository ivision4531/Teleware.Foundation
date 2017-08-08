using System.Collections.Generic;
using System.Threading.Tasks;
using Teleware.Foundation.Domain.Event;

namespace Teleware.Foundation.Domain.Event
{
    /// <summary>
    /// 领域事件邮箱
    /// </summary>
    public class DomainEventPostBox
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        /// <summary>
        /// 投递新领域事件
        /// </summary>
        /// <param name="event">领域事件</param>
        public void Post(IDomainEvent @event)
        {
            _events.Add(@event);
        }

        /// <summary>
        /// 发送所有暂存的领域事件
        /// </summary>
        /// <param name="messenger"><see cref="DomainEventMessenger"/></param>
        public async Task DeliverAllAsync(DomainEventMessenger messenger)
        {
            var events = _events.ToArray();//如果不复制, 将发生事件重复触发问题
            _events.Clear();
            foreach (var @event in events)
            {
                await messenger.DeliverAsync(@event);
            }
        }

        /// <summary>
        /// 暂存的领域事件集合
        /// </summary>
        public IEnumerable<IDomainEvent> Events
        {
            get
            {
                return _events;
            }
        }

        /// <summary>
        /// 清理暂存的领域事件
        /// </summary>
        public void ClearEvents()
        {
            _events.Clear();
        }

        /// <summary>
        /// 转为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Total: " + _events.Count;
        }
    }
}