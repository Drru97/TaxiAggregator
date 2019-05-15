using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaxiAggregator.EconomTaxi.Models.Requests
{
    public class RequestData
    {
        [JsonProperty("car_type")]
        public CarType CarType { get; set; }
        [JsonProperty("points")]
        public List<Point> Points { get; set; }
    }
}
