using Ecommerce.Domain.Common;
using ECommerce.Data.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        protected readonly ECommerceContext _context;

        public Repository(ECommerceContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges) =>
       !trackChanges ?
           _context.Set<TEntity>().Where(expression).AsNoTracking() :
           _context.Set<TEntity>().Where(expression);

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync() =>

         await _context.Set<TEntity>().AsNoTracking().ToListAsync();

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool trackChanges) =>
        !trackChanges ?
            _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(expression) :
            _context.Set<TEntity>().FirstOrDefaultAsync(expression);

        public async Task CreateAsync(TEntity entity) =>
        await _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) =>
            _context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) =>
            _context.Set<TEntity>().Remove(entity);


        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null)
                return null;

            return entity;
        }
    }
}
