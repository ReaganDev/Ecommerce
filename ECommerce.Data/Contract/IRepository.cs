using System.Linq.Expressions;

namespace ECommerce.Data.Contract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool trackChanges);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
    }
}
