using System.Collections.Generic;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public class RequestFactory : IRequestFactory
    {
        public Uber.Models.Requests.PriceEstimateRequest CreateUberRequest(TaxiRequest request)
        {
            var uber = new Uber.Models.Requests.PriceEstimateRequest
            {
                StartLatitude = request.Origin.Latitude,
                StartLongitude = request.Origin.Longitude,
                EndLatitude = request.Destination.Latitude,
                EndLongitude = request.Destination.Longitude
            };

            return uber;
        }

        public Uklon.Models.Requests.PriceEstimateRequestV2 CreateUklonRequest(TaxiRequest request)
        {
            Uklon.Models.Requests.CarType carType;
            switch (request.CarType)
            {
                case Domain.Models.CarType.Variant:
                    carType = Uklon.Models.Requests.CarType.Wagon;
                    break;
                case Domain.Models.CarType.Economy:
                    carType = Uklon.Models.Requests.CarType.Econom;
                    break;
                case Domain.Models.CarType.Business:
                    carType = Uklon.Models.Requests.CarType.Premium;
                    break;
                case Domain.Models.CarType.Minibus:
                    carType = Uklon.Models.Requests.CarType.Minivan;
                    break;
                default:
                    carType = Uklon.Models.Requests.CarType.Standard;
                    break;
            }

            var uklon = new Uklon.Models.Requests.PriceEstimateRequestV2
            {
                Route = new Uklon.Models.Requests.Route {RoutePoints = new List<Uklon.Models.Requests.Point>()},
                CarType = carType.ToString()
            };

            return uklon;
        }

        public Uklon.Models.Requests.NearestAddressRequest CreateNearestAddressRequest(TaxiRequest request,
            bool fromOrigin = true)
        {
            var uklon = new Uklon.Models.Requests.NearestAddressRequest
            {
                Latitude = fromOrigin ? request.Origin.Latitude : request.Destination.Latitude,
                Longitude = fromOrigin ? request.Origin.Longitude : request.Destination.Longitude
            };

            return uklon;
        }

        public Bolt.Models.Requests.PriceEstimateRequest CreateBoltRequest(TaxiRequest request)
        {
            var bolt = new Bolt.Models.Requests.PriceEstimateRequest
            {
                StartLatitude = request.Origin.Latitude,
                StartLongitude = request.Origin.Longitude,
                EndLatitude = request.Destination.Latitude,
                EndLongitude = request.Destination.Longitude
            };

            return bolt;
        }

        public Taxi838.Models.Requests.PriceEstimateRequest CreateTaxi838Request(TaxiRequest request)
        {
            Taxi838.Models.Requests.CarType carType;
            switch (request.CarType)
            {
                case Domain.Models.CarType.Variant:
                    carType = Taxi838.Models.Requests.CarType.Universal;
                    break;
                case Domain.Models.CarType.Minibus:
                    carType = Taxi838.Models.Requests.CarType.Minibus;
                    break;
                default:
                    carType = Taxi838.Models.Requests.CarType.Standart;
                    break;
            }

            var taxi838 = new Taxi838.Models.Requests.PriceEstimateRequest
            {
                Points = new Dictionary<string, TaxiAggregator.Taxi838.Models.Requests.Point>
                {
                    {
                        "0",
                        new TaxiAggregator.Taxi838.Models.Requests.Point(request.Origin.Latitude,
                            request.Origin.Longitude)
                    },
                    {
                        "1",
                        new TaxiAggregator.Taxi838.Models.Requests.Point(request.Destination.Latitude,
                            request.Destination.Longitude)
                    }
                },
                CarType = carType
            };

            return taxi838;
        }
    }
}
