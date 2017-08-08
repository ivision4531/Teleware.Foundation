using System.Threading.Tasks;
using Teleware.Foundation.Domain.Entity;

namespace Teleware.Foundation.Domain
{
    /// <summary>
    /// Id生成器
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IIdGenerator<TEntity>
        where TEntity : IEntity<string>
    {
        /// <summary>
        /// 获取新Id
        /// </summary>
        /// <returns></returns>
        Task<string> NextAsync();

        /// <summary>
        /// 获取新Id
        /// </summary>
        /// <returns></returns>
        string Next();
    }

    /// <summary>
    /// Id生成器扩展方法
    /// </summary>
    public static class IdGeneratorExtensions
    {
        /// <summary>
        /// 为实体分配新Id
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="generator"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string SetId<TEntity>(this IIdGenerator<TEntity> generator, TEntity entity) where TEntity : IEntity<string>
        {
            var id = generator.Next();
            entity.Id = id;
            return id;
        }

        /// <summary>
        /// 为实体分配新Id
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TId">Id类型</typeparam>
        /// <param name="generator"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static async Task<string> SetIdAsync<TEntity, TId>(this IIdGenerator<TEntity> generator, TEntity entity) where TEntity : IEntity<string>
        {
            var id = await generator.NextAsync();
            entity.Id = id;
            return id;
        }
    }
}