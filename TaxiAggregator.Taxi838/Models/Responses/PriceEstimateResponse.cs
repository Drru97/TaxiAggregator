using Newtonsoft.Json;

namespace TaxiAggregator.Taxi838.Models.Responses
{
    public class PriceEstimateResponse
    {
        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
