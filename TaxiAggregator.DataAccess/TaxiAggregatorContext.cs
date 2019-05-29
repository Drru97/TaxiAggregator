using Microsoft.EntityFrameworkCore;
using TaxiAggregator.DataAccess.Generic;
using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.DataAccess
{
    public class TaxiAggregatorContext : BaseDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=tcp:10.0.75.1,1434;Initial Catalog=HistoricalDataDb;User ID=SA;Password=Qwerty12;");
        }

        public DbSet<HistoricalData> StatisticalData { get; set; }
    }
}
