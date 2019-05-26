using Microsoft.EntityFrameworkCore;
using TaxiAggregator.DataAccess.Generic;
using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.DataAccess
{
    public class TaxiAggregatorContext : BaseDbContext
    {
        private readonly string _connectionString;
        
        public TaxiAggregatorContext(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<HistoricalData> StatisticalData { get; set; }
    }
}
