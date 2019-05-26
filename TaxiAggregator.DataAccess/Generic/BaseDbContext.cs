using Microsoft.EntityFrameworkCore;

namespace TaxiAggregator.DataAccess.Generic
{
    public class BaseDbContext : DbContext
    {
        private string _connectionString;

        public BaseDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
