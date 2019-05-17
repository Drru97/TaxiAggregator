using System.Threading.Tasks;
using TaxiAggregator.Bolt.Requests;
using TaxiAggregator.Bolt.Responses;

namespace TaxiAggregator.Bolt
{
    public interface IBoltClient
    {
        Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request);
    }
}
