using System.Threading.Tasks;
using TaxiAggregator.EconomTaxi.Models.Requests;
using TaxiAggregator.EconomTaxi.Models.Responses;

namespace TaxiAggregator.EconomTaxi
{
    public interface IEconomTaxiClient
    {
        Task<StreetSearchResponse> SearchStreetAsync(StreetSearchRequest request);
        Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request);
    }
}
