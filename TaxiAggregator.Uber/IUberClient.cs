using System.Threading.Tasks;
using TaxiAggregator.Uber.Models.Requests;
using TaxiAggregator.Uber.Models.Responses;

namespace TaxiAggregator.Uber
{
    public interface IUberClient
    {
        Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request);
        Task<TimeEstimateResponse> EstimateTimeAsync(PriceEstimateRequest request);
    }
}
