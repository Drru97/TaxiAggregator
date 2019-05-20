using System.Threading.Tasks;
using TaxiAggregator.Taxi838.Models.Requests;
using TaxiAggregator.Taxi838.Models.Responses;

namespace TaxiAggregator.Taxi838
{
    public interface ITaxi838Client
    {
        Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request);
    }
}
