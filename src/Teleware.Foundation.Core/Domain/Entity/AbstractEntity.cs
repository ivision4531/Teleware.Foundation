using System;

namespace Teleware.Foundation.Domain.Entity
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class AbstractEntity : IEntity<String>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        protected AbstractEntity()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <inheritdoc/>
        public string Id { get; set; }

        /// <inheritdoc/>
        object IEntity.GetId()
        {
            return Id;
        }
    }
}