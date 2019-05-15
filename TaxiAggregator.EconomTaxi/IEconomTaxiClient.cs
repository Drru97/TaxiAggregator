using System.Threading.Tasks;
using TaxiAggregator.EconomTaxi.Models.Requests;
using TaxiAggregator.EconomTaxi.Models.Responses;

namespace TaxiAggregator.EconomTaxi
{
    public interface IEconomTaxiClient
    {
        Task<SearchStreetResponse> SearchStreetAsync(StreetSearchRequest request);
        Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request);
    }
}
