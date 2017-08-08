using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teleware.Foundation.Data.Exceptions;

namespace Teleware.Foundation.Data
{
    /// <summary>
    /// 表示一个工作单元协调器
    /// </summary>
    public interface IUnitOfWorkCoordinator : IDisposable
    {
        /// <summary>
        /// 已注册的工作单元
        /// </summary>
        IEnumerable<IUnitOfWork> UnitOfWorks { get; }

        /// <summary>
        /// 注册工作单元
        /// </summary>
        /// <param name="uow"></param>
        void RegisterUnitOfWork(IUnitOfWork uow);

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
    }
}