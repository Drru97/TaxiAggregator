using System;
using Microsoft.Extensions.Configuration;

namespace TaxiAggregator.DataAccess.Generic
{
    public class DbFactory<TDbContext> : IDbFactory<TDbContext>, IDisposable where TDbContext : BaseDbContext
    {
        private readonly IConfiguration _configuration;
        private TDbContext _dbContext;

        public DbFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TDbContext Initialize()
        {
            var connectionString = _configuration.GetConnectionString("SqlServer_HistoricalDataDb");

            return _dbContext ??
                   (_dbContext = (TDbContext) Activator.CreateInstance(typeof(TDbContext), connectionString));
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
