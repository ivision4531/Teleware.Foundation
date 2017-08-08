using Teleware.Foundation.Domain.Event;

namespace Teleware.Foundation.Domain.Entity
{
    /// <summary>
    /// 表示一个聚合根
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
        /// <summary>
        /// 获取领域事件邮箱
        /// </summary>
        DomainEventPostBox GetEventPostBox();
    }

    /// <summary>
    /// 表示一个聚合根
    /// </summary>
    /// <typeparam name="TId">Id字段类型</typeparam>
    public interface IAggregateRoot<TId> : IEntity<TId>, IAggregateRoot
    {
    }
}