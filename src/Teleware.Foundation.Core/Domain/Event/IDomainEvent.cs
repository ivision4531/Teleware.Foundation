using System;
using Teleware.Foundation.Domain.Entity;

namespace Teleware.Foundation.Domain.Event
{
    /// <summary>
    /// 描述一个领域事件
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// Id
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 事件源
        /// </summary>
        IEntity Source { get; }
    }

    /// <summary>
    /// 领域事件基类
    /// </summary>
    public abstract class AbstractDomainEvent : IDomainEvent
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 事件源
        /// </summary>
        public IEntity Source
        {
            get;
            protected set;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected AbstractDomainEvent(IEntity source)
        {
            Id = Guid.NewGuid().ToString();
            Source = source;
            if (Source == null)
            {
                throw new ArgumentNullException("source", "事件源不能为空");
            }
        }
    }
}