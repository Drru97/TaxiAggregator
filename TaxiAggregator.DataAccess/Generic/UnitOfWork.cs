using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaxiAggregator.DataAccess.Generic
{
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : BaseDbContext
    {
        private readonly IDbFactory<TDbContext> _dbFactory;
        private TDbContext _dbContext;

        public UnitOfWork(IDbFactory<TDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public TDbContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Initialize());
    }
}
