using System.Threading.Tasks;
using TaxiAggregator.DataAccess.Generic;
using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.DataAccess
{
    public class HistoricalDataRepository : RepositoryBase<TaxiAggregatorContext, HistoricalData>,
        IHistoricalDataRepository
    {
        public HistoricalDataRepository(IDbFactory<TaxiAggregatorContext> dbFactory) : base(dbFactory)
        {
        }

        public async Task SaveHistoricalDataAsync(HistoricalData historicalData)
        {
            await base.AddAsync(historicalData);
        }
    }
}
