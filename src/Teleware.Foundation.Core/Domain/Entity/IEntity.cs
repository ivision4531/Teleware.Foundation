namespace Teleware.Foundation.Domain.Entity
{
    /// <summary>
    /// 表示一个实体
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 获取Id
        /// </summary>
        /// <returns></returns>
        object GetId();
    }

    /// <summary>
    /// 表示一个实体
    /// </summary>
    /// <typeparam name="TId">Id的类型</typeparam>
    public interface IEntity<TId> : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        TId Id { get; set; }
    }
}