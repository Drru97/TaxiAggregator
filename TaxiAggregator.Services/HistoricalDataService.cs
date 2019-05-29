using System;
using System.Threading.Tasks;
using TaxiAggregator.DataAccess;
using TaxiAggregator.DataAccess.Generic;
using TaxiAggregator.Domain.Models;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public class HistoricalDataService : IHistoricalDataService
    {
        private readonly IHistoricalDataRepository _historicalData;
        private readonly IUnitOfWork<TaxiAggregatorContext> _uow;

        public HistoricalDataService(IHistoricalDataRepository historicalData, IUnitOfWork<TaxiAggregatorContext> uow)
        {
            _historicalData = historicalData;
            _uow = uow;
        }

        public async Task SaveHistoricalDataAsync(TaxiResponse response)
        {
            foreach (var trip in response.Details)
            {
                var historicalData = new HistoricalData
                {
                    OriginLatitude = response.Origin.Latitude,
                    OriginLongitude = response.Origin.Longitude,
                    DestinationLatitude = response.Destination.Latitude,
                    DestinationLongitude = response.Destination.Longitude,

                    TaxiService = trip.TaxiService.ToString(),
                    CarType = trip.CarType.ToString(),
                    Distance = trip.Details.Distance,
                    Price = trip.Details.Price.Cost,
                    MinPrice = trip.Details.Price.MinPrice,
                    MaxPrice = trip.Details.Price.MaxPrice,
                    SurgeMultiplier = trip.Details.Price.SurgeMultiplier,

                    OrderDate = DateTime.Now
                };

                await _historicalData.SaveHistoricalDataAsync(historicalData);
            }

            await _uow.CommitAsync();
        }

        public Task<HistoricalData> GetHistoricalDataForSimilarRequestAsync(TaxiRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
