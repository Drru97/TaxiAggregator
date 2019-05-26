using System.Threading.Tasks;

namespace TaxiAggregator.DataAccess.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetByKeyAsync(object key);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
