using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public interface IRequestFactory
    {
        Uber.Models.Requests.PriceEstimateRequest CreateUberRequest(TaxiRequest request);
        Uklon.Models.Requests.PriceEstimateRequestV2 CreateUklonRequest(TaxiRequest request);
        Bolt.Models.Requests.PriceEstimateRequest CreateBoltRequest(TaxiRequest request);
        Taxi838.Models.Requests.PriceEstimateRequest CreateTaxi838Request(TaxiRequest request);
    }
}
