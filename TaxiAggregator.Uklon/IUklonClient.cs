using System.Threading.Tasks;
using TaxiAggregator.Uklon.Models.Requests;
using TaxiAggregator.Uklon.Models.Responses;

namespace TaxiAggregator.Uklon
{
    public interface IUklonClient
    {
        Task<StreetSearchResponse> SearchStreetAsync(StreetSearchRequest request);
        Task<PriceEstimateResponse> EstimatePriceAsync(PriceEstimateRequest request);
        Task<NearestAddressResponse> SearchNearestAddressAsync(NearestAddressRequest request);
        Task<PriceEstimateResponse> EstimatePriceV2Async(PriceEstimateRequestV2 request);
    }
}
