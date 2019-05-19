using Newtonsoft.Json;

namespace TaxiAggregator.Uklon.Models.Requests
{
    public class PriceEstimateRequestV2
    {
        [JsonProperty("product_type")]
        public string CarType { get; set; } = "Standard";
        [JsonProperty("route")]
        public Route Route { get; set; }
    }
}
