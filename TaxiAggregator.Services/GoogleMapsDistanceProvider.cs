using System;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public class GoogleMapsDistanceProvider : IDistanceProvider
    {
        private const double MetresInKilometer = 1000d;
        private const int RoundingDigits = 2;

        public async Task<DistanceResponse> GetDistanceAsync(DistanceRequest request)
        {
            var distanceRequest = new DistanceMatrixRequest
            {
                Origins = new[]
                {
                    new Location(request.Origin.Latitude, request.Origin.Longitude)
                },
                Destinations = new[]
                {
                    new Location(request.Destination.Latitude, request.Destination.Longitude)
                },
                TravelMode = TravelMode.Driving,
                Language = Language.Ukrainian,
                Units = Units.Metric,
                Key = ServicesConstants.GOOGLE_MAPS_API_KEY
            };

            var distanceResponse = await GoogleMaps.DistanceMatrix.QueryAsync(distanceRequest);
            if (distanceResponse?.Status != Status.Ok)
            {
                return null;
            }

            var data = distanceResponse.Rows?.First()?.Elements?.First();

            var response = new DistanceResponse
            {
                Duration = data?.Duration?.Value,
                Distance = Math.Round(data.Distance.Value / MetresInKilometer, RoundingDigits)
            };

            return response;
        }
    }
}
