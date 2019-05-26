using System.Threading.Tasks;
using TaxiAggregator.Domain.Models;

namespace TaxiAggregator.DataAccess
{
    public interface IHistoricalDataRepository
    {
        Task SaveHistoricalDataAsync(HistoricalData historicalData);
    }
}
