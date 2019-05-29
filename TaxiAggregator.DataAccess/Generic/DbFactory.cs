using System;

namespace TaxiAggregator.DataAccess.Generic
{
    public class DbFactory<TDbContext> : IDbFactory<TDbContext>, IDisposable where TDbContext : BaseDbContext, new()
    {
        private TDbContext _dbContext;

        public TDbContext Initialize()
        {
            return _dbContext ?? (_dbContext = new TDbContext());
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
