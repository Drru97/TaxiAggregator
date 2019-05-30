using Microsoft.EntityFrameworkCore;
using TaxiAggregator.DataAccess.Generic;
using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.DataAccess
{
    public class TaxiAggregatorContext : BaseDbContext
    {
        public TaxiAggregatorContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<HistoricalData> StatisticalData { get; set; }
    }
}
