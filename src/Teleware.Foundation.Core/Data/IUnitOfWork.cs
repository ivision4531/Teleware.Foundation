using System;
using System.Threading.Tasks;
using Teleware.Foundation.Data.Exceptions;

namespace Teleware.Foundation.Data
{
    /// <summary>
    /// 表示一系列需要共同提交或回退的工作单元(Unit of work)
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 提交
        /// </summary>
        /// <exception cref="OptimisticConcurrencyException">发生并发冲突</exception>
        void Commit();

        /// <summary>
        /// 提交
        /// </summary>
        /// <exception cref="OptimisticConcurrencyException">发生并发冲突</exception>
        Task CommitAsync();

        /// <summary>
        /// 在工作单元提交时执行一次
        /// </summary>
        event UnitOfWorkCommittedDelegate OnCommittedOnce;

        /// <summary>
        /// 当多个UnitOfWork同时存在时，提交优先级
        /// </summary>
        int Priority { get; }
    }

    /// <summary>
    /// 工作单元提交完成事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>

    public delegate void UnitOfWorkCommittedDelegate(object sender, EventArgs args);
}