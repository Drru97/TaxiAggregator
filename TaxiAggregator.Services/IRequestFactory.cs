using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public interface IRequestFactory
    {
        Uber.Models.Requests.PriceEstimateRequest CreateUberRequest(TaxiRequest request);
        Uklon.Models.Requests.PriceEstimateRequestV2 CreateUklonRequest(TaxiRequest request);

        Uklon.Models.Requests.NearestAddressRequest CreateNearestAddressRequest(TaxiRequest request,
            bool fromOrigin = true);

        Bolt.Models.Requests.PriceEstimateRequest CreateBoltRequest(TaxiRequest request);
        Taxi838.Models.Requests.PriceEstimateRequest CreateTaxi838Request(TaxiRequest request);

        DistanceRequest CreateDistanceRequest(TaxiRequest request);
    }
}
