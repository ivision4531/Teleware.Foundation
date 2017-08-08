using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teleware.Foundation.Data.Impl
{
    /// <summary>
    /// 工作单元协调器
    /// </summary>
    /// <remarks>用于同时提交一系列工作单元</remarks>
    public class UnitOFWorkCoordinator : IUnitOfWorkCoordinator
    {
        private readonly List<IUnitOfWork> _uows = new List<IUnitOfWork>();

        /// <summary>
        /// 工作单元
        /// </summary>
        public IEnumerable<IUnitOfWork> UnitOfWorks
        {
            get { return _uows; }
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            foreach (var unitOfWork in _uows)
            {
                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            foreach (var unitOfWork in _uows)
            {
                await unitOfWork.CommitAsync();
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            foreach (var unitOfWork in _uows)
            {
                unitOfWork.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 注册新工作单元
        /// </summary>
        /// <param name="uow"></param>
        public void RegisterUnitOfWork(IUnitOfWork uow)
        {
            _uows.Add(uow);
            _uows.Sort((x, y) => x.Priority - y.Priority);
        }
    }
}