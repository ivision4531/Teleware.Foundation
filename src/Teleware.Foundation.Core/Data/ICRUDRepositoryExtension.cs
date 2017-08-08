using Teleware.Foundation.Assertion;
using Teleware.Foundation.Domain.Entity;
using Teleware.Foundation.Util;

namespace Teleware.Foundation.Data
{
    /// <summary>
    /// 仓储相关扩展
    /// </summary>
    public static class ICRUDRepositoryExtension
    {
        /// <summary>
        /// 根据Id获取特定项，检查Id与返回结果是否为空
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="repo"></param>
        /// <param name="id">主键</param>
        /// <param name="entityName">实体名，打印错误信息用</param>
        /// <param name="resultShouldNotNull">是否检查返回结果不为空</param>
        /// <param name="idShouldNotDefault">是否检查Id不为空</param>
        /// <returns></returns>
        public static TEntity Get<TEntity, TId>(
            this ICRUDRepository<TEntity, TId> repo, TId id,
            string entityName,
            bool resultShouldNotNull = true,
            bool idShouldNotDefault = true)
            where TEntity : class, IAggregateRoot<TId>
        {
            if (idShouldNotDefault)
            {
                id.ShouldNotDefault(entityName + "Id不能为空");
            }
            else
            {
                if (Objects.IsDefault(id))
                {
                    return null;
                }
            }
            var result = repo.Get(id);
            if (resultShouldNotNull)
            {
                result.ShouldNotDefault("无法找到Id: {0} 的{1}", id, entityName);
            }
            return result;
        }
    }
}