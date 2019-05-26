using System.Threading.Tasks;
using TaxiAggregator.Domain.Models;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public interface IHistoricalDataService
    {
        Task SaveHistoricalDataAsync(TaxiResponse response);
        Task<HistoricalData> GetHistoricalDataForSimilarRequestAsync(TaxiRequest request);
    }
}
