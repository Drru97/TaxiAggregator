using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public interface IOrderMapper
    {
        TripDetail FromUber(TaxiRequest order, Uber.Models.Responses.PriceEstimateResponse response,
            Uber.Models.Responses.TimeEstimateResponse timeEstimate);

        TripDetail FromUklon(TaxiRequest order, Uklon.Models.Responses.PriceEstimateResponse response, DistanceResponse distance);
        TripDetail FromBolt(TaxiRequest order, Bolt.Models.Responses.PriceEstimateResponse response, DistanceResponse distance);
        TripDetail FromTaxi838(TaxiRequest order, Taxi838.Models.Responses.PriceEstimateResponse response, DistanceResponse distance);
    }
}
