using System.Collections.Generic;

namespace TaxiAggregator.Taxi838.Models.Requests
{
    public class PriceEstimateRequest
    {
        public Dictionary<string, Point> Points { get; set; }
        public int CityId { get; set; } = 11;
        public CarType CarType { get; set; } = CarType.Standart;
    }
}
