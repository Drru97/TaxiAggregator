using System.Threading.Tasks;
using TaxiAggregator.Bolt.Models.Requests;
using TaxiAggregator.Bolt.Models.Responses;

namespace TaxiAggregator.Bolt
{
    public interface IBoltClient
    {
        Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request);
    }
}
