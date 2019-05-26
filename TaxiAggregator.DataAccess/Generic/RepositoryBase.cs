using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaxiAggregator.DataAccess.Generic
{
    public class RepositoryBase<TDbContext, TEntity> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : BaseDbContext
    {
        private TDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(IDbFactory<TDbContext> dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<TEntity> GetByKeyAsync(object key)
        {
            return await _dbSet.FindAsync(key);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await Task.FromResult(_dbSet.Attach(entity));
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            await Task.FromResult(_dbSet.Remove(entity));
        }

        protected IDbFactory<TDbContext> DbFactory { get; private set; }

        protected TDbContext DbContext => _dbContext ?? (_dbContext = DbFactory.Initialize());
    }
}
