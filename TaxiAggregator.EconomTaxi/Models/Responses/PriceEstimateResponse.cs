using Newtonsoft.Json;

namespace TaxiAggregator.EconomTaxi.Models.Responses
{
    public class PriceEstimateResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("cost")]
        public int Cost { get; set; }
    }
}
