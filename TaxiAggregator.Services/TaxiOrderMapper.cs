using System;
using System.Linq;
using TaxiAggregator.Domain.Models;
using TaxiAggregator.Services.Models;

namespace TaxiAggregator.Services
{
    public class TaxiOrderMapper : IOrderMapper
    {
        public TripDetail FromUber(TaxiRequest order, Uber.Models.Responses.PriceEstimateResponse priceEstimate,
            Uber.Models.Responses.TimeEstimateResponse timeEstimate)
        {
            var price = order.CarType == CarType.Business
                ? priceEstimate.Prices.Single(x => x.DisplayName.Equals("UberSelect"))
                : priceEstimate.Prices.Single(x => x.DisplayName.Equals("UberX"));
            var time = order.CarType == CarType.Business
                ? timeEstimate.Times.Single(x => x.DisplayName.Equals("UberSelect"))
                : timeEstimate.Times.Single(x => x.DisplayName.Equals("UberX"));

            var detail = new TripDetail
            {
                CarType = order.CarType,
                TaxiService = TaxiService.Uber,
                Details = new TripData
                {
                    Price = new Price
                    {
                        Cost = (int) ((price.LowEstimate + price.HighEstimate) / 2),
                        MinPrice = (int?) price.LowEstimate,
                        MaxPrice = (int?) price.HighEstimate
                    },
                    Distance = price.Distance,
                    Duration = (int) price.Duration,
                    Seats = 4,
                    PickupTime = (int?) time.Estimate
                }
            };

            return detail;
        }

        public TripDetail FromUklon(TaxiRequest order, Uklon.Models.Responses.PriceEstimateResponse response,
            DistanceResponse distance)
        {
            var detail = new TripDetail
            {
                CarType = order.CarType,
                TaxiService = TaxiService.Uklon,
                Details = new TripData
                {
                    Price = new Price
                    {
                        Cost = response.Cost,
                        MinPrice = response.LowCost,
                        MaxPrice = response.HighCost,
                        SurgeMultiplier = response.CostMultiplier
                    },
                    Distance = response.Distance,
                    Duration = distance.Duration,
                    Seats = order.CarType == CarType.Minibus ? 8 : 4
                }
            };

            return detail;
        }

        public TripDetail FromBolt(TaxiRequest order, Bolt.Models.Responses.PriceEstimateResponse response,
            DistanceResponse distance)
        {
            var price = order.CarType == CarType.Business
                ? response.Data.SearchCategories.Single(x => x.Name.Equals("Comfort"))
                : response.Data.SearchCategories.Single(x => x.Name.Equals("Bolt"));

            var minCost = int.Parse(price.PricePrediction.Trim('₴').Split('–').First());
            var maxCost = int.Parse(price.PricePrediction.Trim('₴').Split('–').Last());
            var avgCost = (minCost + maxCost) / 2;

            var detail = new TripDetail
            {
                CarType = order.CarType,
                TaxiService = TaxiService.Bolt,
                Details = new TripData
                {
                    Price = new Price
                    {
                        MinPrice = minCost,
                        MaxPrice = maxCost,
                        Cost = avgCost,
                        SurgeMultiplier = price.SurgeMultiplier
                    },
                    Distance = distance.Distance,
                    Duration = distance.Duration,
                    PickupTime = price.PickupTime,
                    Seats = 4
                }
            };

            return detail;
        }

        public TripDetail FromTaxi838(TaxiRequest order, Taxi838.Models.Responses.PriceEstimateResponse response,
            DistanceResponse distance)
        {
            var cost = int.Parse(response.Price.Split(' ').First());

            var detail = new TripDetail
            {
                CarType = order.CarType,
                TaxiService = TaxiService.Taxi838,
                Details = new TripData
                {
                    Price = new Price
                    {
                        Cost = cost,
                        MinPrice = cost - new Random().Next(10),
                        MaxPrice = cost + new Random().Next(30)
                    },
                    Distance = distance.Distance,
                    Duration = distance.Duration,
                    Seats = order.CarType == CarType.Minibus ? 8 : 4
                }
            };

            return detail;
        }
    }
}
