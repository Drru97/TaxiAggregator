using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TaxiAggregator.DataAccess.Generic
{
    public class DbFactory<TDbContext> : IDbFactory<TDbContext>, IDisposable where TDbContext : BaseDbContext
    {
        private TDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public DbFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TDbContext Initialize()
        {
            return _dbContext ?? (_dbContext = (TDbContext) new BaseDbContext(""));
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
